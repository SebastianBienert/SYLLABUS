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
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-text-field
            v-model="subjectCard.prerequisites"
            :label="$t('subjectCardHeaders.prerequisites')"
            :placeholder="$t('subjectCardHeaders.prerequisites')"
            required
          ></v-text-field>
        </v-col>
      </v-row>
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
      <v-row align="start" justify="start">

            <v-col cols="4">
                <v-btn block color="primary" @click="objectivitiesModalOpen = true">{{
                  $t("subjectCardHeaders.objectivities")
                }}</v-btn>
            </v-col>

          <EditableList v-show="objectivitiesModalOpen"
            v-on:changeList="updateObjectivities($event)"
            v-on:closeModal="closeObjectivitiesModal($event)"
            :list="subjectCard.objectivities"
            :staticData="{header: 'pies', textPlaceholder: 'pies2'}"
          ></EditableList>

      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.educationalEffect")
          }}</v-btn>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.teachingTools")
          }}</v-btn>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.literature")
          }}</v-btn>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.subjectSchedule")
          }}</v-btn>
        </v-col>
      </v-row>
      <v-row align="start" justify="start">
        <v-col class="text-center" cols="4" align-self="center">
          <v-btn block color="primary">{{
            $t("subjectCardHeaders.curriculum")
          }}</v-btn>
        </v-col>
      </v-row>
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
import {SubjectCard, DefaultSubjectCard} from "@/models/SubjectCard";
import axios from "axios";
import FieldOfStudy from "@/models/FieldOfStudy";
import Employee from "../../models/Employee";
import EditableList from "@/views/subjectCards/EditableList.vue";

@Component({
  components: {
    EditableList
  }
})
export default class SubjectForm extends Vue {
  public subjectCard: SubjectCard = DefaultSubjectCard;
  private objectivitiesModalOpen = false;

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
    console.log(this.subjectCard);
  }

  private updateObjectivities(updatedObjectivities: string[]) {
    this.subjectCard.objectivities = updatedObjectivities;
    this.objectivitiesModalOpen = false;
  }

  private closeObjectivitiesModal() {
    this.objectivitiesModalOpen = false;
  }
}
</script>
