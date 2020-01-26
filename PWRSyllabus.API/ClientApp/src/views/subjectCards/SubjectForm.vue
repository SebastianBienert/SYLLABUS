<template>
  <v-form>
    <v-container fluid>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-text-field
            v-model="subjectCard.nameInPolish"
            :label="$t('subjectCardHeaders.nameInPolish')"
            :placeholder="$t('subjectCardHeaders.nameInPolish')"
            required
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-text-field
            v-model="subjectCard.nameInEnglish"
            :label="$t('subjectCardHeaders.nameInEnglish')"
            :placeholder="$t('subjectCardHeaders.nameInEnglish')"
            required
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-text-field
            v-model="subjectCard.subjectCode"
            :label="$t('subjectCardHeaders.subjectCode')"
            :placeholder="$t('subjectCardHeaders.subjectCode')"
            required
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-select
            v-model="subjectCard.supervisor"
            :label="$t('subjectCardHeaders.supervisor')"
            :placeholder="$t('subjectCardHeaders.supervisor')"
            :items="supervisors"
            item-text="firstName"
            return-object
            required
          ></v-select>
        </v-col>
      </v-row>
      <v-dialog v-model="prerequisitesModalOpen" persistent max-width="290">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark v-on="on">{{
            $t("subjectCardHeaders.prerequisites")
          }}</v-btn>
        </template>
        <EditableList
          v-on:changeList="updateprerequisites($event)"
          v-on:closeModal="closeprerequisitesModal($event)"
          :list="[...subjectCard.prerequisites]"
          :label="$t('subjectCardHeaders.prerequisites')"
          :placeholder="$t('subjectCardHeaders.prerequisites')"
        ></EditableList>
      </v-dialog>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-radio-group
            v-model="subjectCard.level"
            :label="$t('subjectCardHeaders.level')"
          >
            <v-radio
              v-for="n in 3"
              :key="n"
              :label="`${n} stopień`"
              :value="n"
            ></v-radio>
          </v-radio-group>
        </v-col>
      </v-row>
      <v-radio-group
        v-model="subjectCard.formOfStudies"
        :label="$t('subjectCardHeaders.formOfStudies')"
      >
        <v-radio :label="'Stacjonarne'" :value="'Stacjonarne'"></v-radio>
        <v-radio :label="'Niestacjonarne'" :value="'Niestacjonarne'"></v-radio>
      </v-radio-group>
      <v-radio-group
        v-model="subjectCard.isGroupOfCourses"
        :label="$t('subjectCardHeaders.courseGroup')"
      >
        <v-radio :label="'Tak'" :value="true"></v-radio>
        <v-radio :label="'Nie'" :value="false"></v-radio>
      </v-radio-group>
      <v-radio-group
        v-model="subjectCard.subjectType"
        :label="$t('subjectCardHeaders.subjectType')"
      >
        <v-radio :label="'Obowiązkowy'" :value="'Obligatory'"></v-radio>
        <v-radio :label="'Wybieralny'" :value="'Optional'"></v-radio>
        <v-radio
          :label="'Ogólnouczelniany'"
          :value="'UniversityWide'"
        ></v-radio>
      </v-radio-group>
      <v-dialog v-model="objectivitiesModalOpen" persistent max-width="290">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark v-on="on">{{
            $t("subjectCardHeaders.objectivities")
          }}</v-btn>
        </template>
        <EditableList
          v-on:changeList="updateObjectivities($event)"
          v-on:closeModal="closeObjectivitiesModal($event)"
          :list="[...subjectCard.objectivities]"
          :label="$t('subjectCardHeaders.objectivities')"
          :placeholder="$t('subjectCardHeaders.newObjectivity')"
        ></EditableList>
      </v-dialog>
      <v-row align="start" justify="start">
        <v-dialog v-model="educationalEffectsModalOpen" persistent max-width="290">
          <template v-slot:activator="{ on }">
            <v-btn color="primary" dark v-on="on">{{
              $t("subjectCardHeaders.educationalEffects")
            }}</v-btn>
          </template>
          <!-- :list="[...subjectCard.educationalEffects]" !!! -->
          <EducationalEffects
            v-on:changeList="updateceducationalEffects($event)"
            v-on:closeModal="closeeducationalEffectsmModal($event)"
            :list="subjectCard.educationalEffects.map(x => Object.assign({}, x))"
            :label="$t('subjectCardHeaders.educationalEffects')"
            :placeholder="$t('subjectCardHeaders.educationalEffects')"
          ></EducationalEffects>
        </v-dialog>
      </v-row>
      <v-row align="start" justify="start">
        <v-dialog v-model="teachingToolsModalOpen" persistent max-width="290">
          <template v-slot:activator="{ on }">
            <v-btn color="primary" dark v-on="on">{{
              $t("subjectCardHeaders.teachingTools")
            }}</v-btn>
          </template>
          <EditableList
            v-on:changeList="updateTeachingTools($event)"
            v-on:closeModal="closeteachingToolsModal($event)"
            :list="[...subjectCard.teachingTools]"
            :label="$t('subjectCardHeaders.teachingTools')"
            :placeholder="$t('subjectCardHeaders.teachingTools')"
          ></EditableList>
        </v-dialog>
      </v-row>
      <v-dialog v-model="literatureModalOpen" persistent max-width="290">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark v-on="on">{{
            $t("subjectCardHeaders.literature")
          }}</v-btn>
        </template>
        <EditableList
          v-on:changeList="updateliterature($event)"
          v-on:closeModal="closeliteratureModal($event)"
          :list="[...subjectCard.literature]"
          :label="$t('subjectCardHeaders.literature')"
          :placeholder="$t('subjectCardHeaders.literature')"
        ></EditableList>
      </v-dialog>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="start">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.subjectSchedule")
          }}</v-btn>
        </v-col>
      </v-row>
      <v-dialog v-model="curriculumModalOpen" persistent max-width="290">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark v-on="on">{{
            $t("subjectCardHeaders.curriculum")
          }}</v-btn>
        </template>
        <CoursesTable
          v-on:changeList="updatecurriculum($event)"
          v-on:closeModal="closecurriculumModal($event)"
          :courses="[...subjectCard.courses]"
          :label="$t('subjectCardHeaders.curriculum')"
          :placeholder="$t('subjectCardHeaders.curriculum')"
        ></CoursesTable>
      </v-dialog>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.trackingMatrix")
          }}</v-btn>
        </v-col>
      </v-row>
    </v-container>
    <v-btn class="mr-4" @click="$emit('submit', subjectCard)">{{
      $t("submit")
    }}</v-btn>
    <v-btn @click="test()">{{ $t("cancel") }}</v-btn>
  </v-form>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from "vue-property-decorator";
import { SubjectCard, DefaultSubjectCard } from "@/models/SubjectCard";
import axios from "axios";
import FieldOfStudy from "@/models/FieldOfStudy";
import Employee from "../../models/Employee";
import EditableList from "@/views/subjectCards/EditableList.vue";
import EducationalEffects from "@/views/subjectCards/EducationalEffects.vue";
import EducationalEffect from '@models/EducationalEffect';
import CoursesTable from "@/views/subjectCards/CoursesTable.vue";

import { Course } from "@/models/Course";

@Component({
  components: {
    EditableList,
    CoursesTable,
    EducationalEffects
  }
})
export default class SubjectForm extends Vue {
  public subjectCard: SubjectCard = DefaultSubjectCard;
  private objectivitiesModalOpen = false;
  private teachingToolsModalOpen = false;
  private prerequisitesModalOpen = false;
  private literatureModalOpen = false;
  private curriculumModalOpen = false;
  private educationalEffectsModalOpen = false;

  private testey = [{code: "PEK_W", description: "DUPADUP", id: 0}];

  @Prop()
  public fieldsOfStudies!: FieldOfStudy[];

  @Prop()
  public supervisors!: Employee[];

  @Prop()
  public initialData: SubjectCard | undefined;

  @Watch("initialData")
  public seedData(initialData: SubjectCard) {
    if (initialData) {
      this.subjectCard = { ...(this.initialData as SubjectCard) };
    }
  }

  public test() {
    console.log(this.subjectCard.educationalEffects);
  }

  private updateObjectivities(updatedObjectivities: string[]) {
    this.subjectCard.objectivities = updatedObjectivities;
    this.objectivitiesModalOpen = false;
  }

  private closeObjectivitiesModal() {
    this.objectivitiesModalOpen = false;
  }

  private updateTeachingTools(updatedTeachingTools: string[]) {
    this.subjectCard.teachingTools = updatedTeachingTools;
    this.teachingToolsModalOpen = false;
  }

  private closeteachingToolsModal() {
    this.teachingToolsModalOpen = false;
  }

  private updateprerequisites(updatedprerequisites: string[]) {
    this.subjectCard.prerequisites = updatedprerequisites;
    this.prerequisitesModalOpen = false;
  }

  private closeprerequisitesModal() {
    this.prerequisitesModalOpen = false;
  }

  private updateliterature(updatedliterature: string[]) {
    this.subjectCard.literature = updatedliterature;
    this.literatureModalOpen = false;
  }

  private closeliteratureModal() {
    this.literatureModalOpen = false;
  }

  private updatecurriculum(updatedcurriculum: Course[]) {
    this.subjectCard.courses = updatedcurriculum;
    this.curriculumModalOpen = false;
  }

  private closecurriculumModal() {
    this.curriculumModalOpen = false;
  }

  private updateceducationalEffects(updatededucationalEffects: EducationalEffect[]) {
    console.log(updatededucationalEffects);
    this.subjectCard.educationalEffects = updatededucationalEffects;
    this.educationalEffectsModalOpen = false;
  }

  private closeeducationalEffectsmModal() {
    this.educationalEffectsModalOpen = false;
  }
}
</script>
