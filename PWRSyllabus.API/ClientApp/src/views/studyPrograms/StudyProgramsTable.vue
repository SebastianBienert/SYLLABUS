<template>
  <v-container>
    <v-row>
        <v-col cols="3">
            <v-text-field
                v-model="search"
                append-icon="search"
                :placeholder="$t('search')"
                single-line
                hide-details
            ></v-text-field>
        </v-col>
        <v-col cols="3">
            <v-btn color="primary" to="/add-study-program">
                {{$t('studyProgramsHeaders.newProgram')}}
            </v-btn>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <v-data-table
                :loading="loading"
                :headers="headers"
                :items="studyPrograms"
                :search="search"
            >
                <template v-slot:item.action="{ item }">
                    <v-icon
                        small
                        class="mr-2"
                        @click="redirectToEdit(item.id)"
                    >
                        edit
                    </v-icon>
                    <v-icon
                        small
                        @click="deleteItem(item.id)"
                    >
                        delete
                    </v-icon>
                </template>
                <template v-slot:item.discipline="{ item }">
                    {{item.discipline.name}}
                </template>
            </v-data-table>
        </v-col>
    </v-row>
    
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import axios from 'axios';
import StudyProgram from '../../models/StudyProgram';
import SubjectCard from '../../models/SubjectCard';

@Component
export default class StudyProgramsTable extends Vue {
    private search: string = '';
    private studyPrograms: StudyProgram[] = [];
    private loading: boolean = false;
    private levels: string[] = [];
    private categories: string[] = [];

    get headers() {
      return[
      { text: this.$t('studyProgramsHeaders.faculty'), align: 'left', value: 'faculty'},
      { text: this.$t('studyProgramsHeaders.fieldOfStudy'), value: 'fieldOfStudy.name' },
      { text: this.$t('studyProgramsHeaders.specialization'), value: 'specialization' },
      { text: this.$t('studyProgramsHeaders.level'), value: 'level' },
      { text: this.$t('studyProgramsHeaders.formOfStudies'), value: 'formOfStudies' },
      { text: this.$t('studyProgramsHeaders.language'), value: 'language' },
      { text: '', value: 'action', sortable: false }];
    }

    public async created() {
        this.studyPrograms = await this.fetchStudyPrograms();
    }

    private async fetchStudyPrograms(): Promise<StudyProgram[]> {
        this.loading = true;
        const response = await axios.get<StudyProgram[]>('/api/StudyProgram');
        const studyPrograms = response.data;
        this.loading = false;
        return studyPrograms;
    }

    private redirectToEdit(programId: number): void {
        this.$router.push(`edit-study-program/${programId}`);
    }

    private deleteItem(effectId: number): void {
        const response = axios.delete<StudyProgram[]>(`api/StudyProgram/${effectId}`);
        this.studyPrograms = this.studyPrograms.filter((x) => x.id !== effectId);
    }
}
</script>


