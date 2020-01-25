<template>
  <div class="modal-backdrop">
    <v-container class="modal">
      <v-row align="center" justify="center">
        <v-col cols="1" class="text-center" align-self="center">
          <h1>{{ staticData.header }}</h1>
        </v-col>
      </v-row>
      <v-row v-for="n in list.length" v-bind:key="n">
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="deleteObjFromArray(n - 1)"
            ><v-icon small @click="deleteEffect(item.id)">
              delete
            </v-icon></v-btn
          >
        </v-col>
        <v-col>
          <v-label>{{ list[n - 1] }}</v-label>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="addObjToArray()"
            ><v-icon small @click="deleteObjFromArray(item.id)">
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
          <v-btn class="mr-4" @click="changeList">{{
            $t("submit")
          }}</v-btn>
        </v-col>
        <v-col cols="1">
          <v-btn @click="$emit('closeModal')">{{
            $t("cancel")
          }}</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import axios from "axios";
@Component
export default class EditableList extends Vue {
  @Prop()
  public list!: string[] | string[];
  private strin: string = "";
  @Prop()
  public staticData!: {
    header: string;
    textPlaceholder: string;
  };

  private addObjToArray() {
    if (this.strin !== "") {
      this.list.push(this.strin);
      this.strin = "";
    }
  }

  private deleteObjFromArray(index: number) {
    this.list.splice(index, 1);
  }

  private changeList() {
    this.$emit("changeList", this.list);
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
