<template>
    <v-container>
        <ministerial-effect-form
            @cancel="handleCancel"
            @submit="create"
            :disciplines="availableDisciplines"
        ></ministerial-effect-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import MinisterialEffectForm from '@/views/ministerialEffects/MinisterialEffectForm.vue';
import axios from 'axios';
import Discipline from '../../models/Discipline';
import MinisterialEffect from '@/models/MinisterialEffect';

@Component({
    components: {
        'ministerial-effect-form': MinisterialEffectForm,
    },
})
export default class AddMinisterialEffect extends Vue {
    public availableDisciplines: Discipline[] = [];

    public async created() {
        const response = await axios.get<Discipline[]>('/api/Discipline');
        this.availableDisciplines = response.data;
    }
    public handleCancel() {
        this.$router.push('/ministerial-effects');
    }

    private async create(createdEffect: MinisterialEffect) {
        await axios.post<Discipline[]>('/api/MinisterialEffect', createdEffect);
        this.$router.push('/ministerial-effects');
    }

}
</script>

<style>

</style>