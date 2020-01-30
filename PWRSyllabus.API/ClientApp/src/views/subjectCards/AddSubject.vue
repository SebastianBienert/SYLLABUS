<template>
    <v-container>
        <subject-form
            @cancel="handleCancel"
            @submit="create"
            :fieldsOfStudies="availableFieldsOfStudies"
            :supervisors="availableSupervisors"
        ></subject-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import StudyProgramForm from '@/views/studyPrograms/StudyProgramForm.vue';
import axios from 'axios';
import FieldOfStudy from '../../models/FieldOfStudy';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';
import SubjectCard from '@/models/SubjectCard';
import Employee from '@/models/Employee';
import SubjectForm from './SubjectForm.vue';

@Component({
    components: {
        'subject-form': SubjectForm,
    },
})
export default class AddSubject extends Vue {
    public availableFieldsOfStudies: FieldOfStudy[] = [];
    public availableSupervisors: Employee[] = []

    public async created() {
        const response = await axios.get<FieldOfStudy[]>('/api/FieldOfStudy');
        const supervisorsResponse = await axios.get<Employee[]>('/api/Employee')
        this.availableFieldsOfStudies = response.data;
        this.availableSupervisors = supervisorsResponse.data;
    }
    public handleCancel() {
        this.$router.push('/subject-cards');
    }

    private async create(createdSubject: SubjectCard) {
        await axios.post<any>('/api/SubjectCard', createdSubject);
        this.$router.push('/subject-cards');
    }

}
</script>

<style>

</style>