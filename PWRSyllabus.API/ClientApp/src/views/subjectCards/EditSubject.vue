<template>
    <v-container>
        <subject-form
            @cancel="handleCancel"
            @submit="edit"
            :fieldsOfStudies="availableFieldsOfStudies"
            :supervisors="availableSupervisors"
            :initial-data="subjectCard"
        ></subject-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import StudyProgramForm from '@/views/studyPrograms/StudyProgramForm.vue';
import axios from 'axios';
import FieldOfStudy from '../../models/FieldOfStudy';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';
import {SubjectCard, DefaultSubjectCard} from '@/models/SubjectCard';
import Employee from '@/models/Employee';
import SubjectForm from './SubjectForm.vue';

@Component({
    components: {
        'subject-form': SubjectForm,
    },
})
export default class EditSubject extends Vue {
    public availableFieldsOfStudies: FieldOfStudy[] = [];
    public availableSupervisors: Employee[] = [];
    public subjectCard = DefaultSubjectCard;

    public async created() {
        const response = await axios.get<FieldOfStudy[]>('/api/FieldOfStudy');
        const supervisorsResponse = await axios.get<Employee[]>('/api/Employee')
        this.availableFieldsOfStudies = response.data;
        this.availableSupervisors = supervisorsResponse.data;
        this.subjectCard = (await axios.get<SubjectCard>(`/api/SubjectCard/${this.$route.params.id}`)).data;
    }
    public handleCancel() {
        this.$router.push('/study-programs');
    }

    private async create(createdSubject: SubjectCard) {
        await axios.post<any>('/api/SubjectCard', createdSubject);
        console.log(createdSubject)
        this.$router.push('/study-programs');
    }

    private async edit(editedSubjectCard: SubjectCard) {
        console.log('dupa romana');
        await axios.put<any>(`/api/SubjectCard/${this.$route.params.id}`, editedSubjectCard);
        this.$router.push('/subject-cards');
    }

}
</script>

<style>

</style>