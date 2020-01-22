<template>
    <v-container>
        <subject-form
            @cancel="handleCancel"
            @submit="create"
            :fieldsOfStudies="availableFieldsOfStudies"
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
import SubjectForm from './SubjectForm.vue';

@Component({
    components: {
        'subject-form': SubjectForm,
    },
})
export default class AddSubject extends Vue {
    public availableFieldsOfStudies: FieldOfStudy[] = [];

    public async created() {
        const response = await axios.get<FieldOfStudy[]>('/api/FieldOfStudy');
        this.availableFieldsOfStudies = response.data;
    }
    public handleCancel() {
        this.$router.push('/study-programs');
    }

    private async create(createdSubject: SubjectCard) {
        await axios.post<any>('/api/StudyProgram', createdSubject);
        console.log(createdSubject)
        // this.$router.push('/study-programs');
    }

}
</script>

<style>

</style>