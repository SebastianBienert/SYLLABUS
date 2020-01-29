<template>
    <v-container>
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
          <v-row>
          <v-col cols="2">
            <v-label>{{ copied[n - 1].code }}</v-label>
          </v-col >
          <v-col cols="2">
            <v-label>{{ copied[n - 1].description }}</v-label>
          </v-col>
          </v-row>
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

    </v-container>
</template>
<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import axios from "axios";
import EducationalEffect from '@/models/EducationalEffect';
@Component
export default class EditableList extends Vue {
  @Prop()
  public list!: EducationalEffect[] | EducationalEffect[];

  private copied: EducationalEffect[] = [];
  private strin: string = "";
  @Prop()
  label!: string | string;
  @Prop()
  placeholder!: string | string;
  @Prop()
  eduEffectCodeStart!: string | string;


  private addObjToArray() {
    if (this.strin !== "") {
      const codeC = this.copied.length + 1;
      this.copied.push({code: this.eduEffectCodeStart + codeC, description: this.strin} as EducationalEffect);
      this.strin = "";
    }
  }

public async created() {
       this.copied = this.list;
    }

  private deleteObjFromArray(index: number) {
    this.copied.splice(index-1, 1);
    this.reiterateCodeIndex();
  }
  reiterateCodeIndex() {
    let cop = [];
    for(let i = 0; i < this.copied.length; i++) {
      this.copied[i].code = this.eduEffectCodeStart + (i+1);
    }

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
