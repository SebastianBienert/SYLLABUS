<template>
    <v-container>
        <study-program-form
            @cancel="handleCancel"
            @submit="edit"
            :disciplines="availableDisciplines"
            :initialData="studyProgram"
        ></study-program-form>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import StudyProgramForm from '@/views/studyPrograms/StudyProgramForm.vue';
import axios from 'axios';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';
import FieldOfStudy from '../../models/FieldOfStudy';
@Component({
    components: {
        'study-program-form': StudyProgramForm,
    },
})
export default class EditStudyProgram extends Vue {
    public availableFieldsOfStudies: FieldOfStudy[] = [];
    public studyProgram: StudyProgram = DefaultStudyProgram;

    public async created() {
        this.studyProgram = (await axios.get<StudyProgram>(`/api/StudyProgram/${this.$route.params.id}`)).data;
        const response = await axios.get<FieldOfStudy[]>('/api/FieldOfStudy');
        this.availableFieldsOfStudies = response.data;
    }

    public handleCancel() {
        this.$router.push('/study-programs');
    }

    private async edit(editedEffect: StudyProgram) {
        await axios.put<any>(`/api/StudyProgram/${this.$route.params.id}`, editedEffect);
        this.$router.push('/study-programs');
    }

}
</script>

<style>

</style>