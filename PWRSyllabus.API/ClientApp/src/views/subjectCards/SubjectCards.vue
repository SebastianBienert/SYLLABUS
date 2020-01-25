<template>
  <v-card>
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="search"
        :placeholder="$t('search')"
        single-line
        hide-details
      ></v-text-field>
      <v-col cols="3">
        <v-btn color="primary" to="/add-subject">
          {{ $t("subjectCardsHeaders.newSubject") }}
        </v-btn>
      </v-col>
    </v-card-title>
    <v-data-table
      :loading="loading"
      :headers="headers"
      :items="subjectCards"
      :search="search"
    ></v-data-table>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import axios from "axios";
import SubjectCard from "../../models/SubjectCard";
@Component
export default class SubjectCards extends Vue {
  private search: string = "";
  private subjectCards: any = [];
  private loading: boolean = false;
  get headers() {
    return [
      // {
      //   text: this.$t("subjectCardsHeaders.faculty"),
      //   align: "left",
      //   value: "fieldOfStudy.faculty"
      // },
      // { text: this.$t("subjectCardsHeaders.fieldOfStudy"), value: "fieldOfStudy.name" },
      // { text: this.$t("subjectCardsHeaders.specialization"), value: "specialization" },
      { text: this.$t("subjectCardsHeaders.code"), value: "subjectCode" },
      { text: this.$t("subjectCardsHeaders.subjectName"), value: "nameInPolish" },
      { text: this.$t("subjectCardsHeaders.subjectName"), value: "nameInEnglish" }
    ];
  }
  public async created() {
    this.fetchSubjectCards();
  }
  private async fetchSubjectCards() {
    try {
      const response = await axios.get<SubjectCard[]>("api/SubjectCard");
      this.subjectCards = response.data;
      console.log(this.subjectCards);
    } catch (e) {}
    this.loading = false;
  }
}
</script>
