<template>
  <div class="modal-backdrop">
    <v-container class="modal">
      <v-row align="center" justify="center">
        <v-col class="text-center" align-self="center">
          <h1>{{ label }}</h1>
        </v-col>
      </v-row>
      <v-row v-for="n in copied.length" v-bind:key="n">
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="deleteObjFromArray(n)"
            ><v-icon small>
              delete
            </v-icon></v-btn
          >
        </v-col>
        <v-col>
          <v-label>{{ copied[n - 1] }}</v-label>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="1" class="text-center" align-self="center">
          <v-btn rounded @click="addObjToArray()"
            ><v-icon small>
              add
            </v-icon></v-btn
          >
        </v-col>
        <v-col class="text-center" align-self="center">
          <v-text-field
            v-model="strin"
            :placeholder=placeholder
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
          <v-btn @click="cancelHandler">{{
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
  private copied: string[] = [];
  private strin: string = "";
  @Prop()
  label!: string | string;
  @Prop()
  placeholder!: string | string;


  private addObjToArray() {
    if (this.strin !== "") {
      this.copied.push(this.strin);
      this.strin = "";
    }
  }

public async created() {
       this.copied = this.list;
    }

  private deleteObjFromArray(index: number) {
    this.copied.splice(index-1, 1);
    console.log(this.copied);
  }

  private changeList() {
    this.$emit("changeList", this.copied);
  }

  private cancelHandler() {
    this.copied = this.list;
    this.$emit('closeModal');
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
