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
import {TraceMatrix, MatrixRow} from '@/models/TraceMatrix';

@Component
export default class TraceMatrixTable extends Vue {
    private search: string = '';
    private matrix: MatrixRow[] = [];
    private loading: boolean = false;

    public async created() {
        this.loading = true;
        this.matrix = await this.fetchTraceMatrix();
        this.loading = false;
    }

    private get headers() {
      return [
        { text: this.$t('traceMatrixHeaders.ministerialEffectCode'), align: 'left', value: 'ministerialEffectCode'},
        { text: this.$t('traceMatrixHeaders.ministerialEffect'), value: 'ministerialEffectDescription' },
        { text: this.$t('traceMatrixHeaders.educationalEffectCode'), value: 'educationalEffectCode' },
        { text: this.$t('traceMatrixHeaders.educationalEffect'), value: 'educationalEffectDescription' },
      ];
    }

    private async fetchTraceMatrix(): Promise<MatrixRow[]> {
        const response = await axios.get<TraceMatrix>('api/TraceMatrix');
        const traceMatrix = response.data;
        return traceMatrix.rows;
    }

}
</script>


