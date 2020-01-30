<template>
  <div class="modal-backdrop">
    <v-container class="modal">
      <template>
        <v-row align="center" justify="center">
        <v-col class="text-center" align-self="center">
          <h1>{{ $t("subjectCardHeaders.schedule") }}</h1>
        </v-col>
      </v-row>
        <v-row>
          <v-col v-for="course in copied" v-bind:key="course.CourseForm">
            <v-row>
              <v-col>
                <v-checkbox
                  v-model="course.isSelected"
                  :label="course.CourseForm"
                ></v-checkbox>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  v-model.number="course.ZZU"
                  type="number"
                  min="0"
                  :label="$t('subjectCardHeaders.ZZU')"
                  :disabled="!course.isSelected"
                >
                </v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  v-model.number="course.CNPS"
                  type="number"
                  min="0"
                  :label="$t('subjectCardHeaders.CNPS')"
                  :disabled="!course.isSelected"
                >
                </v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-radio-group
                  v-model="course.FormOfCrediting"
                  :label="$t('subjectCardHeaders.formOfStudies')"
                  :disabled="!course.isSelected"
                >
                  <v-radio
                    :label="$t('subjectCardHeaders.examination')"
                    :value="'Examination'"
                  ></v-radio>
                  <v-radio
                    :label="$t('subjectCardHeaders.creditingWithGrade')"
                    :value="'CreditingWithGrade'"
                  ></v-radio>
                </v-radio-group>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  v-model.number="course.ECTS"
                  type="number"
                  min="0"
                  :label="$t('subjectCardHeaders.ECTS')"
                  :disabled="!course.isSelected"
                >
                </v-text-field>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </template>
      <v-row>
        <v-col cols="1">
          <v-btn class="mr-4" @click="changeList">{{ $t("submit") }}</v-btn>
        </v-col>
        <v-col cols="1">
          <v-btn @click="cancelHandler">{{ $t("cancel") }}</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import axios from "axios";
import { Course } from "@/models/Course";
@Component
export default class CoursesTable extends Vue {
  @Prop()
  public courses!: Course[] | Course[];
  private copied: Course[] = [];
  private originalPrepared: Course[] = [];
  private allForms: string[] = ["Lecture", "Seminar", "Laboratory", "Class", "Project"];

  public async created() {
    this.allForms.forEach(form => {
      const corresponding = this.courses.find(v => v.CourseForm == form);
      this.originalPrepared.push({
        id:  corresponding && corresponding.id || 0,
        ECTS: corresponding && corresponding.ECTS || 0,
        ZZU: corresponding && corresponding.ZZU || 0,
        CNPS: corresponding && corresponding.CNPS || 0,
        CourseForm: form,
        FormOfCrediting: corresponding && corresponding.FormOfCrediting || "",
        isSelected: corresponding && true || false,
        Classes: []
      });
      this.copied = this.originalPrepared;
    });
  }
  private changeList() {
    this.$emit("changeList", this.copied);
  }

  private cancelHandler() {
    this.$emit("closeModal");
  }
}
</script>
<style>
.test {
  background-color: whitesmoke;
}

.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #ffffff;
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
}
</style>
