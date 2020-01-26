<template>
  <div class="modal-backdrop">
    <v-container class="modal">
    <v-row align="center" justify="center">
        <v-col class="text-center" align-self="center">
          <h1>{{ $t('subjectCardHeaders.educationalEffects') }}</h1>
        </v-col>
      </v-row>
      <v-tabs>
        <v-tab>
          Z zakresu wiedzy
        </v-tab>
        <v-tab>
          Z zakresu umiejętności
        </v-tab>
        <v-tab>
          Z zakresu kompetencji społecznych
        </v-tab>

        <v-tab-item>
          <EditableListWithoutButtons
            :list="knowledge"
            eduEffectCodeStart="PEK_W"
          ></EditableListWithoutButtons>
        </v-tab-item>
        <v-tab-item>
          <EditableListWithoutButtons
            :list="skill"
            eduEffectCodeStart="PEK_U"
          ></EditableListWithoutButtons>
        </v-tab-item>
        <v-tab-item>
          <EditableListWithoutButtons
            :list="competencies"
            eduEffectCodeStart="PEK_K"
          ></EditableListWithoutButtons>
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
import EducationalEffect from '@models/EducationalEffect';
@Component({
  components: {
    EditableListWithoutButtons
  }
})
export default class EducationalEffects extends Vue {
  @Prop()
  public list!: EducationalEffect[] | EducationalEffect[];
  public knowledge: EducationalEffect[] = this.list.filter( obj => obj.code.substring(0, 5) === "PEK_W");
  public skill: EducationalEffect[] = this.list.filter( obj => obj.code.substring(0, 5) === "PEK_U");
  public competencies: EducationalEffect[] = this.list.filter( obj => obj.code.substring(0, 5) === "PEK_K");
  private copied: EducationalEffect[] = [];
  // private strin: string = "";
  // @Prop()
  // label!: string | string;
  // @Prop()
  // placeholder!: string | string;

  // private addObjToArray() {
  //   if (this.strin !== "") {
  //     this.copied.push(this.strin);
  //     this.strin = "";
  //   }
  // }

  public async created() {
    this.copied = this.list;
  }

  // private deleteObjFromArray(index: number) {
  //   this.copied.splice(index - 1, 1);
  //   console.log(this.copied);
  // }

  private changeList() {
    let arr: EducationalEffect[] = [];
    this.copied = arr.concat(this.knowledge).concat(this.competencies).concat(this.skill);
    this.$emit("changeList", this.copied);
  }

  private cancelHandler() {
     let arr: EducationalEffect[] = [];
    this.copied = arr.concat(this.knowledge).concat(this.competencies).concat(this.skill);
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
