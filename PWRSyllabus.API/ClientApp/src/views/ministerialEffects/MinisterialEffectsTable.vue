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
            <v-select
                v-model="selectedLevel"
                :items="levels"
                :label="$t('ministerialEffectsHeaders.level')"
                clearable
            ></v-select>
        </v-col>
        <v-col cols="3">
            <v-select
                v-model="selectedCategory"
                :items="categories"
                :label="$t('ministerialEffectsHeaders.category')"
                clearable
            ></v-select>
        </v-col>
        <v-col cols="3">
            <v-btn color="primary" to="/add-ministerial-effect">
                {{$t('ministerialEffectsHeaders.addEffect')}}
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
                        @click="deleteEffect(item.id)"
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


    get headers() {
      return[
      { text: this.$t('ministerialEffectsHeaders.category'), align: 'left', value: 'category',
        filter: this.filterCategory},
      { text: this.$t('ministerialEffectsHeaders.descriptiveCategory'), value: 'descriptiveCategory' },
      { text: this.$t('ministerialEffectsHeaders.code'), value: 'code' },
      { text: this.$t('ministerialEffectsHeaders.level'), value: 'level', filter: this.filterLevel },
      { text: this.$t('ministerialEffectsHeaders.discipline'), value: 'discipline' },
      { text: this.$t('ministerialEffectsHeaders.description'), value: 'description' },
      { text: '', value: 'action', sortable: false }];
    }
    private search: string = '';
    private ministerialEffects: MinisterialEffect[] = [];
    private loading: boolean = false;
    private levels: string[] = [];
    private selectedLevel: string = '';
    private categories: string[] = [];
    private selectedCategory: string = '';

    public async created() {
        this.ministerialEffects = await this.fetchMinisterialEffects();
        this.levels = [...new Set(this.ministerialEffects.map((x) => x.level))];
        this.categories = [...new Set(this.ministerialEffects.map((x) => x.category))];
    }

    private filterCategory(value: any, search: string | null, item: any): boolean {
        if (!this.selectedCategory) {
            return true;
        }
        return this.selectedCategory === value;
    }

    private filterLevel(value: any, search: string | null, item: any): boolean {
        if (!this.selectedLevel) {
            return true;
        }
        return this.selectedLevel === value;
    }

    private async fetchMinisterialEffects(): Promise<MinisterialEffect[]> {
        const response = await axios.get<MinisterialEffect[]>('api/MinisterialEffect');
        const ministerialEffects = response.data;
        return ministerialEffects;
    }

    private redirectToEdit(effectId: number): void {
        this.$router.push(`edit-ministerial-effect/${effectId}`);
    }

    private deleteEffect(effectId: number): void {
        const response = axios.delete<MinisterialEffect[]>(`api/MinisterialEffect/${effectId}`);
        this.ministerialEffects = this.ministerialEffects.filter((x) => x.id !== effectId);
    }

}
</script>


