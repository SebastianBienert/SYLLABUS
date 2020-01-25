<template>
  <div class="modal-backdrop">
    <v-container class="modal">
      <v-row v-for="n in objectivities.length" v-bind:key="n">
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="deleteObjFromArray(n - 1)"
            ><v-icon small @click="deleteEffect(item.id)">
              delete
            </v-icon></v-btn
          >
        </v-col>
        <v-col>
          <v-label>{{ objectivities[n - 1] }}</v-label>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="addObjToArray()"
            ><v-icon small @click="deleteEffect(item.id)">
              add
            </v-icon></v-btn
          >
        </v-col>
        <v-col class="text-center" align-self="center">
          <v-text-field
            v-model="strin"
            :placeholder="'New objectivity'"
            required
          ></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col cols="1">
          <v-btn class="mr-4" @click="changeObjectivities">{{
            $t("submit")
          }}</v-btn>
        </v-col>
        <v-col cols="1">
          <v-btn @click="$emit('cancel')">{{ $t("cancel") }}</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import axios from "axios";
@Component
export default class Objectivities extends Vue {
  private objectivities: string[] = ["test", "tess"];
  private strin: string = "";

  private addObjToArray() {
    if (this.strin !== "") {
      this.objectivities.push(this.strin);
      this.strin = "";
    }
  }

  private deleteObjFromArray(index: number) {
    this.objectivities.splice(index, 1);
    console.log(this.objectivities);
  }

  private changeObjectivities() {
    this.$emit("changeObjectivities", this.objectivities);
    this.$emit("close", true);
    console.log(this.objectivities);
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

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  border-bottom: 1px solid #eeeeee;
  color: #4aae9b;
  justify-content: space-between;
}

.modal-footer {
  border-top: 1px solid #eeeeee;
  justify-content: flex-end;
}

.modal-body {
  position: relative;
  padding: 20px 10px;
}

.btn-close {
  border: none;
  font-size: 20px;
  padding: 20px;
  cursor: pointer;
  font-weight: bold;
  color: #4aae9b;
  background: transparent;
}

.btn-green {
  color: white;
  background: #4aae9b;
  border: 1px solid #4aae9b;
  border-radius: 2px;
}
</style>
