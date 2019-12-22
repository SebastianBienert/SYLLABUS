<template>
  <v-card>
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="search"
        label="Search"
        single-line
        hide-details
      ></v-text-field>
    </v-card-title>
    <v-data-table
        :loading="loading"
        :headers="headers"
        :items="matrix"
        :search="search"
    ></v-data-table>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class TraceMatrix extends Vue {
    private search: string = '';
    private matrix: any = [];
    private loading: boolean = false;

    private get headers() {
      return [
        { text: this.$t('traceMatrixHeaders.ministerialEffectCode'), align: 'left', value: 'name'},
        { text: this.$t('traceMatrixHeaders.ministerialEffect'), value: 'calories' },
        { text: this.$t('traceMatrixHeaders.educationalEffectCode'), value: 'fat' },
        { text: this.$t('traceMatrixHeaders.educationalEffect'), value: 'carbs' },
      ];
    }

  //   private async fetchMatrix() {
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


