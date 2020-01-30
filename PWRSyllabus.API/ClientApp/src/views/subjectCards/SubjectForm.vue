<template>
  <v-form>
    <v-container fluid>
      <v-row>
        <v-col cols="3">
          <v-text-field
            v-model="subjectCard.nameInPolish"
            :label="$t('subjectCardHeaders.nameInPolish')"
            :placeholder="$t('subjectCardHeaders.nameInPolish')"
            required
          ></v-text-field>

          <v-text-field
            v-model="subjectCard.nameInEnglish"
            :label="$t('subjectCardHeaders.nameInEnglish')"
            :placeholder="$t('subjectCardHeaders.nameInEnglish')"
            required
          ></v-text-field>

          <v-text-field
            v-model="subjectCard.subjectCode"
            :label="$t('subjectCardHeaders.subjectCode')"
            :placeholder="$t('subjectCardHeaders.subjectCode')"
            required
          ></v-text-field>

          <v-select
            v-model="subjectCard.supervisor"
            :label="$t('subjectCardHeaders.supervisor')"
            :placeholder="$t('subjectCardHeaders.supervisor')"
            :items="supervisors"
            return-object
            required
          >
            <template slot="selection" slot-scope="data">
              {{ data.item.firstName }} {{ data.item.lastName }}
            </template>
            <template slot="item" slot-scope="data">
              {{ data.item.firstName }} {{ data.item.lastName }}
            </template>
          </v-select>

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
        <v-col cols="1"></v-col>
        <v-col cols="3">
          <v-radio-group
            v-model="subjectCard.formOfStudies"
            :label="$t('subjectCardHeaders.formOfStudies')"
          >
            <v-radio
              :label="$t('subjectCardHeaders.fullTime')"
              :value="'Stacjonarne'"
            ></v-radio>
            <v-radio
              :label="$t('subjectCardHeaders.partTime')"
              :value="'Niestacjonarne'"
            ></v-radio>
          </v-radio-group>
          <v-radio-group
            v-model="subjectCard.isGroupOfCourses"
            :label="$t('subjectCardHeaders.courseGroup')"
          >
            <v-radio
              :label="$t('subjectCardHeaders.yes')"
              :value="true"
            ></v-radio>
            <v-radio
              :label="$t('subjectCardHeaders.no')"
              :value="false"
            ></v-radio>
          </v-radio-group>
          <v-radio-group
            v-model="subjectCard.subjectType"
            :label="$t('subjectCardHeaders.subjectType')"
          >
            <v-radio
              :label="$t('subjectCardHeaders.obligatory')"
              :value="'Obligatory'"
            ></v-radio>
            <v-radio
              :label="$t('subjectCardHeaders.optional')"
              :value="'Optional'"
            ></v-radio>
            <v-radio
              :label="$t('subjectCardHeaders.universityWide')"
              :value="'UniversityWide'"
            ></v-radio>
          </v-radio-group>
        </v-col>
        <v-col cols="3">
          <v-dialog v-model="prerequisitesModalOpen" persistent max-width="290">
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
                $t("subjectCardHeaders.prerequisites")
              }}</v-btn>
            </template>
            <EditableList
              v-on:changeList="updateprerequisites($event)"
              v-on:closeModal="closeprerequisitesModal($event)"
              :list="[...subjectCard.prerequisites]"
              :label="$t('subjectCardHeaders.prerequisites')"
              :placeholder="$t('subjectCardHeaders.newPrerequisite')"
            ></EditableList>
          </v-dialog>
          <v-dialog v-model="objectivitiesModalOpen" persistent max-width="290">
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
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

          <v-dialog
            v-model="educationalEffectsModalOpen"
            persistent
            max-width="290"
          >
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
                $t("subjectCardHeaders.educationalEffects")
              }}</v-btn>
            </template>
            <!-- :list="[...subjectCard.educationalEffects]" !!! -->
            <EducationalEffects
              v-on:changeList="updateceducationalEffects($event)"
              v-on:closeModal="closeeducationalEffectsmModal($event)"
              :list="[...subjectCard.educationalEffects]"
              :label="$t('subjectCardHeaders.educationalEffects')"
              :placeholder="$t('subjectCardHeaders.educationalEffects')"
            ></EducationalEffects>
          </v-dialog>

          <v-dialog v-model="teachingToolsModalOpen" persistent max-width="290">
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
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
          <v-dialog
            v-model="primaryLiteratureModalOpen"
            persistent
            max-width="290"
          >
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
                $t("subjectCardHeaders.primaryLiterature")
              }}</v-btn>
            </template>
            <EditableList
              v-on:changeList="updateprimaryLiterature($event)"
              v-on:closeModal="closeprimaryLiteratureModal($event)"
              :list="[...subjectCard.primaryLiterature]"
              :label="$t('subjectCardHeaders.primaryLiterature')"
              :placeholder="$t('subjectCardHeaders.primaryLiterature')"
            ></EditableList>
          </v-dialog>
          <v-dialog
            v-model="secondaryLiteratureModalOpen"
            persistent
            max-width="290"
          >
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
                $t("subjectCardHeaders.secondaryLiterature")
              }}</v-btn>
            </template>
            <EditableList
              v-on:changeList="updatesecondaryLiterature($event)"
              v-on:closeModal="closesecondaryLiteratureModal($event)"
              :list="[...subjectCard.secondaryLiterature]"
              :label="$t('subjectCardHeaders.secondaryLiterature')"
              :placeholder="$t('subjectCardHeaders.secondaryLiterature')"
            ></EditableList>
          </v-dialog>
          <v-dialog v-model="scheduleModalOpen" persistent max-width="290">
            <template v-slot:activator="{ on }">
              <v-btn block color="primary" class="mt-4" dark v-on="on">{{
                $t("subjectCardHeaders.schedule")
              }}</v-btn>
            </template>
            <CoursesTable
              v-on:changeList="updateschedule($event)"
              v-on:closeModal="closescheduleModal($event)"
              :courses="[...subjectCard.courses]"
              :label="$t('subjectCardHeaders.schedule')"
              :placeholder="$t('subjectCardHeaders.schedule')"
            ></CoursesTable>
          </v-dialog>
          <v-dialog v-model="curriculumModalOpen" persistent max-width="290">
            <template v-slot:activator="{ on }">
              <v-btn
                block
                color="primary"
                class="mt-4"
                v-on="on"
                :disabled="
                  subjectCard.courses === undefined ||
                    subjectCard.courses.length === 0
                "
                >{{ $t("subjectCardHeaders.curriculum") }}</v-btn
              >
            </template>
            <Curriculum
              v-on:changeList="updatecurriculum($event)"
              v-on:closeModal="closecurriculumeModal($event)"
              :courses="[...subjectCard.courses]"
            ></Curriculum>
          </v-dialog>

          <!-- <v-btn block color="primary" class="mt-4">{{
            $t("subjectCardHeaders.trackingMatrix")
          }}</v-btn> -->
        </v-col>
      </v-row>
    </v-container>
    <v-btn class="mr-4" @click="$emit('submit', subjectCard)">{{
      $t("submit")
    }}</v-btn>
    <v-btn @click="$emit('cancel')">{{ $t("cancel") }}</v-btn>
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
import EducationalEffect from "@/models/EducationalEffect";
import CoursesTable from "@/views/subjectCards/CoursesTable.vue";
import Curriculum from "@/views/subjectCards/Curriculum.vue";
import { Course } from "@/models/Course";

@Component({
  components: {
    EditableList,
    CoursesTable,
    EducationalEffects,
    Curriculum
  }
})
export default class SubjectForm extends Vue {
  public subjectCard: SubjectCard = DefaultSubjectCard;
  private objectivitiesModalOpen = false;
  private teachingToolsModalOpen = false;
  private prerequisitesModalOpen = false;
  private primaryLiteratureModalOpen = false;
  private secondaryLiteratureModalOpen = false;
  private scheduleModalOpen = false;
  private educationalEffectsModalOpen = false;
  private curriculumModalOpen = false;

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
      console.log(this.subjectCard);
    }
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

  private updateprimaryLiterature(updatedliterature: string[]) {
    this.subjectCard.primaryLiterature = updatedliterature;
    this.primaryLiteratureModalOpen = false;
  }

  private closeprimaryLiteratureModal() {
    this.primaryLiteratureModalOpen = false;
  }

  private updatesecondaryLiterature(updatedliterature: string[]) {
    this.subjectCard.secondaryLiterature = updatedliterature;
    this.secondaryLiteratureModalOpen = false;
  }

  private closesecondaryLiteratureModal() {
    this.secondaryLiteratureModalOpen = false;
  }

  private updateschedule(updatedschedule: Course[]) {
    this.subjectCard.courses = updatedschedule.filter(x => x.isSelected);
    console.log(this.subjectCard.courses);
    this.scheduleModalOpen = false;
  }

  private closescheduleModal() {
    this.scheduleModalOpen = false;
  }

  private updateceducationalEffects(
    updatededucationalEffects: EducationalEffect[]
  ) {
    console.log(updatededucationalEffects);
    this.subjectCard.educationalEffects = updatededucationalEffects;
    this.educationalEffectsModalOpen = false;
  }

  private closeeducationalEffectsmModal() {
    this.educationalEffectsModalOpen = false;
  }

  private updatecurriculum(updatedcurriculum: Course[]) {
    this.subjectCard.courses = updatedcurriculum;
    this.curriculumModalOpen = false;
  }

  private closecurriculumeModal() {
    this.curriculumModalOpen = false;
  }
}
</script>
