<template>
  <v-container>
    <v-row>
        <v-col cols="3">
            <v-text-field
                v-model="search"
                append-icon="search"
                label="Search"
                single-line
                hide-details
            ></v-text-field>
        </v-col>
        <v-col cols="3">
            <v-select
            :items="levels"
            label="Poziom"
            ></v-select>
        </v-col>
        <v-col cols="3">
            <v-select
            :items="categories"
            label="Kategoria"
            ></v-select>
        </v-col>
        <v-col cols="3">
            <v-btn color="primary" to="/add-ministerial-effect">
                Nowy efekt
            </v-btn>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <v-data-table
                :loading="loading"
                :headers="headers"
                :items="ministerialEffects"
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
                        @click="deleteItem(item)"
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
import MinisterialEffect from '../../models/MinisterialEffect';
@Component
export default class MinisterialEffectsTable extends Vue {
    private search: string = '';
    private ministerialEffects: MinisterialEffect[] = [];
    private loading: boolean = false;
    private levels: string[] = [];
    private categories: string[] = [];

    get headers() {
      return[
      { text: this.$t('ministerialEffectsHeaders.category'), align: 'left', value: 'category'},
      { text: this.$t('ministerialEffectsHeaders.descriptiveCategory'), value: 'descriptiveCategory' },
      { text: this.$t('ministerialEffectsHeaders.code'), value: 'code' },
      { text: this.$t('ministerialEffectsHeaders.level'), value: 'level' },
      { text: this.$t('ministerialEffectsHeaders.discipline'), value: 'discipline' },
      { text: this.$t('ministerialEffectsHeaders.description'), value: 'description' },
      { text: '', value: 'action', sortable: false }];
    }

    public async created() {
        this.ministerialEffects = await this.fetchMinisterialEffects();
    }

    private async fetchMinisterialEffects(): Promise<MinisterialEffect[]> {
        const response = await axios.get<MinisterialEffect[]>('api/MinisterialEffect');
        const ministerialEffects = response.data;
        return ministerialEffects;
    }

    private redirectToEdit(effectId: number): void {
        this.$router.push(`edit-ministerial-effect/${effectId}`);
    }

}
</script>


