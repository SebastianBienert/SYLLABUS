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
        <!-- <v-col cols="3">
            <v-btn color="primary" to="/add-study-program">
                {{$t('studyProgramsHeaders.newProgram')}}
            </v-btn>
        </v-col> -->
    </v-row>
    <v-row>
        <v-col cols="12">
            <v-data-table
                :loading="loading"
                :headers="headers"
                :items="subjectCards"
                :search="search"
                show-select
                v-model="selected"
                @input="$emit('selectedItemsChanged', selected)"
            >
                <!-- <template v-slot:item.action="{ item }">
                    <v-icon
                        small
                        class="mr-2"
                        @click="redirectToEdit(item.id)"
                    >
                        edit
                    </v-icon>
                    <v-icon
                        small
                        @click="deleteItem(item)"
                    >
                        delete
                    </v-icon>
                </template>
                <template v-slot:item.discipline="{ item }">
                    {{item.discipline.name}}
                </template> -->
            </v-data-table>
        </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import axios from 'axios';
import SubjectCard from '../../models/SubjectCard';
@Component
export default class SelectSubjectCards extends Vue {
    private search: string = '';
    private subjectCards: SubjectCard[] = [];
    private loading: boolean = false;
    private levels: string[] = [];
    private categories: string[] = [];
    private selected: SubjectCard[] = [];

    get headers() {
      return[
      { text: this.$t('studyProgramsHeaders.faculty'), align: 'left', value: 'subjectCode'},
    //   { text: this.$t('studyProgramsHeaders.fieldOfStudy'), value: 'fieldOfStudy.name' },
    //   { text: this.$t('studyProgramsHeaders.specialization'), value: 'specialization' },
    //   { text: this.$t('studyProgramsHeaders.level'), value: 'level' },
    //   { text: this.$t('studyProgramsHeaders.formOfStudies'), value: 'formOfStudies' },
    //   { text: this.$t('studyProgramsHeaders.language'), value: 'language' },
      { text: '', value: 'action', sortable: false }];
    }

    public async created() {
        this.subjectCards = await this.fetchSubjectCards();
    }

    private async fetchSubjectCards(): Promise<SubjectCard[]> {
        
        const response = await axios.get<SubjectCard[]>('api/SubjectCard');
        const subjectCards = response.data;
        return subjectCards;
    }

    // private redirectToEdit(programId: number): void {
    //     this.$router.push(`edit-study-program/${programId}`);
    // }
}
</script>


