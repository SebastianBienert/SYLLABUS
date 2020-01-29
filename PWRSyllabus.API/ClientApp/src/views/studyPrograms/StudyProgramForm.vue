<template>
    <form>
    <v-select
        v-model="studyProgram.fieldOfStudy"
        :label="$t('studyProgramsHeaders.fieldOfStudy')"
        :placeholder="$t('studyProgramsHeaders.fieldOfStudy')"
        :items="fieldsOfStudies"
        item-text="name"
        return-object
        required
    ></v-select>
    <v-text-field
    disabled
        v-model="studyProgram.fieldOfStudy.specialization"
        :label="$t('studyProgramsHeaders.specialization')"
        :placeholder="$t('studyProgramsHeaders.specialization')"
        required
    ></v-text-field>
    <v-text-field
    disabled
        v-model="studyProgram.fieldOfStudy.faculty"
        :label="$t('studyProgramsHeaders.faculty')"
        :placeholder="$t('studyProgramsHeaders.faculty')"
        required
    ></v-text-field>
    <v-select
        v-model="studyProgram.level"
        :label="$t('studyProgramsHeaders.level')"
        :placeholder="$t('studyProgramsHeaders.level')"
        :items="availableLevels"
        item-text="name"
        return-object
        required
    ></v-select>
    <!-- <v-text-field
        v-model="studyProgram.level"
        :label="$t('studyProgramsHeaders.level')"
        :placeholder="$t('studyProgramsHeaders.level')"
        required
    ></v-text-field> -->
    <v-select
        v-model="studyProgram.language"
        :label="$t('studyProgramsHeaders.language')"
        :placeholder="$t('studyProgramsHeaders.language')"
        :items="availableLanguages"
        item-text="name"
        return-object
        required
    ></v-select>
    <!-- <v-text-field
        v-model="studyProgram.language"
        :label="$t('studyProgramsHeaders.language')"
        :placeholder="$t('studyProgramsHeaders.language')"
        required
    ></v-text-field> -->
    <v-select
        v-model="studyProgram.formOfStudies"
        :label="$t('studyProgramsHeaders.formOfStudies')"
        :placeholder="$t('studyProgramsHeaders.formOfStudies')"
        :items="availableFormsOfStudy"
        item-text="name"
        return-object
        required
    ></v-select>
    
    <v-dialog v-model="dialog" persistent max-width="600">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark v-on="on">{{$t('studyProgramsHeaders.selectSubjectCards')}}</v-btn>
        </template>
        <v-card>
            <v-card-title class="headline">{{$t('studyProgramsHeaders.searchAndSelectSubjectCards')}}</v-card-title>
            <select-subject-cards 
                @selectedItemsChanged="handleItemsChange" 
                :initialSubjectCards="studyProgram.subjectCards">
            </select-subject-cards>          
            <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="green darken-1" text @click="dialog = false">{{$t('studyProgramsHeaders.select')}}</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

    <v-btn class="mr-4" @click="$emit('submit', studyProgram)">{{$t('submit')}}</v-btn>
    <v-btn @click="$emit('cancel')">{{$t('cancel')}}</v-btn>
    </form>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';
import axios from 'axios';
import FieldOfStudy from '@/models/FieldOfStudy';
import SubjectCard from '../../models/SubjectCard';
import SelectSubjectCards from '@/views/studyPrograms/SelectSubjectCards.vue';

@Component({
  components: {
    SelectSubjectCards,
  }
})
export default class StudyProgramForm extends Vue {
    public studyProgram: StudyProgram = DefaultStudyProgram;
    private dialog: boolean = false;
    private availableLevels: string[] = ["6", "7"];
    private availableLanguages: string[] = ["polski", "angielski"];
    private availableFormsOfStudy: string[] = ["stacjonarne", "niestacjonarne"];

    @Prop()
    public fieldsOfStudies!: FieldOfStudy[];

    @Prop()
    public initialData: StudyProgram | undefined;

    @Watch('initialData')
    public seedData(initialData: StudyProgram) {
        if (initialData) {
            this.studyProgram = {...this.initialData as StudyProgram};
        }
    }

    public handleItemsChange(params: SubjectCard[]) {
        this.studyProgram.subjectCards = params;
    }
}
</script>

<style>

</style>