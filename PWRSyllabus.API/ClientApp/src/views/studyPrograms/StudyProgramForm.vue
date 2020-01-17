<template>
    <form>
    <v-text-field
        v-model="studyProgram.faculty"
        :label="$t('studyProgramsHeaders.faculty')"
        :placeholder="$t('studyProgramsHeaders.faculty')"
        required
    ></v-text-field>
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
        v-model="studyProgram.specialization"
        :label="$t('studyProgramsHeaders.specialization')"
        :placeholder="$t('studyProgramsHeaders.specialization')"
        required
    ></v-text-field>
    <v-text-field
        v-model="studyProgram.level"
        :label="$t('studyProgramsHeaders.level')"
        :placeholder="$t('studyProgramsHeaders.level')"
        required
    ></v-text-field>
    <v-text-field
        v-model="studyProgram.language"
        :label="$t('studyProgramsHeaders.language')"
        :placeholder="$t('studyProgramsHeaders.language')"
        required
    ></v-text-field>
    <v-text-field
        v-model="studyProgram.formOfStudies"
        :label="$t('studyProgramsHeaders.formOfStudies')"
        :placeholder="$t('studyProgramsHeaders.formOfStudies')"
    ></v-text-field>
    <v-btn class="mr-4" @click="$emit('submit', studyProgram)">{{$t('submit')}}</v-btn>
    <v-btn @click="$emit('cancel')">{{$t('cancel')}}</v-btn>
  </form>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';
import StudyProgram, {DefaultStudyProgram} from '@/models/StudyProgram';
import axios from 'axios';
import FieldOfStudy from '@/models/FieldOfStudy';

@Component
export default class StudyProgramForm extends Vue {
    public studyProgram: any = {};

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

}
</script>

<style>

</style>