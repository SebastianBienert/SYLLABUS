<template>
    <v-container>
        <ministerial-effect-form
            @cancel="handleCancel"
            @submit="edit"
            :disciplines="availableDisciplines"
            :initialData="effect"
        ></ministerial-effect-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import MinisterialEffectForm from '@/views/ministerialEffects/MinisterialEffectForm.vue';
import axios from 'axios';
import Discipline from '../../models/Discipline';
import MinisterialEffect, {DefaultMinisterialEffect} from '@/models/MinisterialEffect';
@Component({
    components: {
        'ministerial-effect-form': MinisterialEffectForm,
    },
})
export default class EditMinisterialEffect extends Vue {
    public availableDisciplines: Discipline[] = [];
    public effect: MinisterialEffect = DefaultMinisterialEffect;

    public async created() {
        this.effect = (await axios.get<MinisterialEffect>(`/api/MinisterialEffect/${this.$route.params.id}`)).data;
        const response = await axios.get<Discipline[]>('/api/Discipline');
        this.availableDisciplines = response.data;
    }

    public handleCancel() {
        this.$router.push('/ministerial-effects');
    }

    private async edit(editedEffect: MinisterialEffect) {
        await axios.put<Discipline[]>(`/api/MinisterialEffect/${this.$route.params.id}`, editedEffect);
        this.$router.push('/ministerial-effects');
    }

}
</script>

<style>

</style>