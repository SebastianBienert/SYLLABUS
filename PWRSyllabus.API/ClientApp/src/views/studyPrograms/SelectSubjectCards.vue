<template>
  <v-container>
    <v-row>
        <v-col cols="12">
            <v-text-field
                v-model="search"
                append-icon="search"
                :placeholder="$t('search')"
                single-line
                hide-details
            ></v-text-field>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <v-data-table
                :loading="loading"
                :headers="headers"
                :items="subjectCards"
                :search="search"
                show-select
                v-model="initialSubjectCards"
                @input="$emit('selectedItemsChanged', initialSubjectCards)"
            >
            </v-data-table>
        </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';
import axios from 'axios';
import SubjectCard from '../../models/SubjectCard';
@Component
export default class SelectSubjectCards extends Vue {
    private search: string = '';
    private subjectCards: SubjectCard[] = [];
    private loading: boolean = false;
    private levels: string[] = [];
    private categories: string[] = [];

    get headers() {
      return[
      { text: this.$t('studyProgramsHeaders.subjectCode'), align: 'left', value: 'subjectCode'},
      { text: this.$t('studyProgramsHeaders.name'), align: 'left', value: 'nameInPolish'},
      { text: '', value: 'action', sortable: false }];
    }

    @Prop()
    public initialSubjectCards: SubjectCard[] | undefined = [];

    public async created() {
        this.subjectCards = await this.fetchSubjectCards();
    }

    private async fetchSubjectCards(): Promise<SubjectCard[]> {
        
        const response = await axios.get<SubjectCard[]>('/api/SubjectCard');
        const subjectCards = response.data;
        return subjectCards;
    }

    // private redirectToEdit(programId: number): void {
    //     this.$router.push(`edit-study-program/${programId}`);
    // }
}
</script>


