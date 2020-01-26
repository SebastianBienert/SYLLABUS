<template>
  <div class="modal-backdrop">
    <v-container class="modal">
      <v-tabs>
        <v-tab v-for="course in courses" v-bind:key="course.CourseForm">
          {{ course.CourseForm }}
        </v-tab>
        <v-tab-item v-for="course in courses" v-bind:key="course.CourseForm">
          <ClassForCourse :classes="course.Classes" :courseForm="course.CourseForm"> </ClassForCourse>
        </v-tab-item>
      </v-tabs>
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
import EditableListWithoutButtons from "@/views/subjectCards/EditableListWithoutButtons.vue";
import Course from "@models/Course";
import ClassForCourse from "@/views/subjectCards/ClassForCourse.vue";
@Component({
  components: {
    EditableListWithoutButtons,
    ClassForCourse
  }
})
export default class Curriculum extends Vue {
  @Prop()
  public courses!: Course[] | Course[];
  public copied: Course[] = [];

  public async created() {
    this.copied = this.courses;
  }

  // private deleteObjFromArray(index: number) {
  //   this.copied.splice(index - 1, 1);
  //   console.log(this.copied);
  // }

  private changeList() {
    // let arr: EducationalEffect[] = [];
    // this.copied = arr.concat(this.knowledge).concat(this.competencies).concat(this.skill);
    this.$emit("changeList", this.copied);
  }

  private cancelHandler() {
    //  let arr: EducationalEffect[] = [];
    // this.copied = arr.concat(this.knowledge).concat(this.competencies).concat(this.skill);
    this.$emit("changeList", this.copied);
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
