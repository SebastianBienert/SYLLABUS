<template>
    <v-container>
        <study-program-form
            @cancel="handleCancel"
            @submit="create"
            :fieldsOfStudies="availableFieldsOfStudies"
        ></study-program-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import StudyProgramForm from '@/views/studyPrograms/StudyProgramForm.vue';
import axios from 'axios';
import FieldOfStudy from '../../models/FieldOfStudy';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';

@Component({
    components: {
        'study-program-form': StudyProgramForm,
    },
})
export default class AddStudyProgram extends Vue {
    public availableFieldsOfStudies: FieldOfStudy[] = [];

    public async created() {
        const response = await axios.get<FieldOfStudy[]>('/api/FieldOfStudy');
        this.availableFieldsOfStudies = response.data;
    }
    public handleCancel() {
        this.$router.push('/study-programs');
    }

    private async create(createdStudyProgram: StudyProgram) {
        await axios.post<any>('/api/StudyProgram', createdStudyProgram);
        this.$router.push('/study-programs');
    }

}
</script>

<style>

</style>