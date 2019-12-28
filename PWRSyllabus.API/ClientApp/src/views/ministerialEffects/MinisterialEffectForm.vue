<template>
    <form>
    <v-text-field
        v-model="effect.code"
        :label="$t('ministerialEffectsHeaders.code')"
        :placeholder="$t('ministerialEffectsHeaders.code')"
        required
    ></v-text-field>
    <v-select
        :label="$t('ministerialEffectsHeaders.discipline')"
        :placeholder="$t('ministerialEffectsHeaders.discipline')"
        :items="disciplines"
        item-text="name"
        return-object
        required
    ></v-select>
    <v-text-field
        v-model="effect.category"
        :label="$t('ministerialEffectsHeaders.category')"
        :placeholder="$t('ministerialEffectsHeaders.category')"
        required
    ></v-text-field>
    <v-text-field
        v-model="effect.descriptiveCategory"
        :label="$t('ministerialEffectsHeaders.descriptiveCategory')"
        :placeholder="$t('ministerialEffectsHeaders.descriptiveCategory')"
        required
    ></v-text-field>
    <v-text-field
        v-model="effect.level"
        :label="$t('ministerialEffectsHeaders.level')"
        :placeholder="$t('ministerialEffectsHeaders.level')"
        required
    ></v-text-field>
    <v-textarea
        v-model="effect.description"
        :label="$t('ministerialEffectsHeaders.description')"
        :placeholder="$t('ministerialEffectsHeaders.description')"
    ></v-textarea>
    <v-btn class="mr-4" @click="$emit('submit', effect)">{{$t('submit')}}</v-btn>
    <v-btn @click="$emit('cancel')">{{$t('cancel')}}</v-btn>
  </form>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';
import MinisterialEffect, {DefaultMinisterialEffect} from '@/models/MinisterialEffect';
import axios from 'axios';
import Discipline from '@/models/Discipline';

@Component
export default class MinisterialEffectForm extends Vue {
    public effect: MinisterialEffect = DefaultMinisterialEffect;

    @Prop()
    public disciplines!: Discipline[];

    @Prop()
    public initialData: MinisterialEffect | undefined;

    // mounted(){
    //     if(this.initialData){
    //         this.effect = {...this.initialData};
    //     }
    // }

    // TO TAK RACZEJ NIE POWINNO SIE ROBIC ALE NAJPROSCIEJ WYSZLO
    @Watch('initialData')
    public seedData(initialData: MinisterialEffect) {
        if (initialData) {
            this.effect = {...this.initialData as MinisterialEffect};
        }
    }

}
</script>

<style>

</style>