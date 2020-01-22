<template>
  <v-card>
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="search"
        :placeholder="$t('search')"
        single-line
        hide-details
      ></v-text-field>
      <v-col cols="3">
            <v-btn color="primary" to="/add-subject">
                {{$t('subjectCardsHeaders.newSubject')}}
            </v-btn>
        </v-col>
    </v-card-title>
    <v-data-table
        :loading="loading"
        :headers="headers"
        :items="subjectCards"
        :search="search"
    ></v-data-table>
    
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class SubjectCards extends Vue {
    private search: string = '';
    private subjectCards: any = [];
    private loading: boolean = false;
    get headers() {
      return[
      { text: this.$t('subjectCardsHeaders.faculty'), align: 'left', value: 'name'},
      { text: this.$t('subjectCardsHeaders.fieldOfStudy'), value: 'calories' },
      { text: this.$t('subjectCardsHeaders.specialization'), value: 'fat' },
      { text: this.$t('subjectCardsHeaders.code'), value: 'carbs' },
      { text: this.$t('subjectCardsHeaders.subjectName'), value: 'protein' }];
    }

  //   private async fetchSubjectCards() {
  //   try {
  //       // TODO
  //     // const response = await axios.get<Forecast[]>('api/WeatherForecast');
  //     // this.subjectCards = response.data;
  //   } catch (e) {

  //   }
  //   this.loading = false;
  // }

}
</script>


