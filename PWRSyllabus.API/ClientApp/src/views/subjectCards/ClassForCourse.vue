<template>
  <v-container style="max-height: 400px"
        class="overflow-y-auto">
    <v-row align="center" justify="center">
      <v-col class="text-center" align-self="center">
        <h1>{{ label }}</h1>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="2" class="text-center" align-self="center"> </v-col>
      <v-col cols="2" class="text-center" align-self="center">
        <v-label>Number</v-label>
      </v-col>
      <v-col cols="4" class="text-left" align-self="center">
        <v-label>Description</v-label>
      </v-col>
      <v-col cols="1" class="text-left" align-self="center">
        <v-label>Hours</v-label>
      </v-col>
    </v-row>
    <v-row v-for="n in copied.length" v-bind:key="n">
      <v-col cols="2" class="text-center" align-self="center">
        <v-btn rounded @click="deleteObjFromArray(n)"
          ><v-icon small>
            delete
          </v-icon></v-btn
        >
      </v-col>
      <v-col cols="2" class="text-center" align-self="center">
        <v-label>{{ courseForm }} {{ copied[n - 1].ClassNumber }}</v-label>
      </v-col>
      <v-col cols="4" class="text-left" align-self="center">
        <v-label>{{ copied[n - 1].Description }}</v-label>
      </v-col>
      <v-col cols="1" class="text-left" align-self="center">
        <v-label>{{ copied[n - 1].Hours }}</v-label>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="2" class="text-center" align-self="center">
        <v-btn rounded @click="addObjToArray()"
          ><v-icon small>
            add
          </v-icon></v-btn
        >
      </v-col>
      <v-col cols="2" class="text-center" align-self="center">
        <v-label>{{ courseForm }} {{ copied.length + 1 }}</v-label>
      </v-col>
      <v-col cols="4" class="text-center" align-self="center">
        <v-text-field
          v-model="description"
          :placeholder="placeholder"
          required
        ></v-text-field>
      </v-col>
      <v-col cols="1" class="text-center" align-self="center">
        <v-text-field
          v-model.number="hours"
          type="number"
          :placeholder="placeholder"
          required
        ></v-text-field>
      </v-col>
    </v-row>
  </v-container>
</template>
<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import axios from "axios";
import EducationalEffect from "@/models/EducationalEffect";
import Class from "@/models/Class";
@Component
export default class ClassForCourse extends Vue {
  @Prop()
  public classes!: Class[] | Class[];

  @Prop()
  public courseForm!: string | string;

  private copied: Class[] = [];
  private description: string = "";
  private hours: number = 0;
  @Prop()
  label!: string | string;
  @Prop()
  placeholder!: string | string;
  @Prop()
  eduEffectCodeStart!: string | string;

  private addObjToArray() {
    if (this.description !== "" && this.hours !== 0) {
      const codeC = this.copied.length + 1;
      this.copied.push({
        Hours: this.hours,
        Description: this.description,
        ClassNumber: codeC
      } as Class);
      this.description = "";
      this.hours = 0;
    }
  }

  // ClassNumber: number;
  //   Description: string;
  //   Hours: number;

  public async created() {
    console.log(this.classes);
    this.copied = this.classes;
    console.log(this.copied);
  }

  private deleteObjFromArray(index: number) {
    this.copied.splice(index - 1, 1);
    this.reiterateCodeIndex();
  }
  reiterateCodeIndex() {
    let cop = [];
    for (let i = 0; i < this.copied.length; i++) {
      this.copied[i].ClassNumber = i + 1;
    }
  }

  private changeList() {
    this.$emit("changeList", this.copied);
  }

  private cancelHandler() {
    this.copied = this.classes;
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
