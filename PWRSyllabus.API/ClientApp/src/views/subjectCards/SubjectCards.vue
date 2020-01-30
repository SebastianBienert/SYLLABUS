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
    >
      <template v-slot:item.action="{ item }">
        <div class="table--action">
          <v-icon small class="mr-2" @click="redirectToEdit(item.id)"
            >edit</v-icon
          >
          <v-icon small @click="deleteEffect(item.id)">
            delete
          </v-icon>
          <v-icon small @click="fetchPDF(item.id, item.subjectCode)">
            picture_as_pdf
          </v-icon>
        </div>
      </template>
    </v-data-table>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import axios from "axios";
import SubjectCard from "../../models/SubjectCard";
@Component
export default class SubjectCards extends Vue {
  private search: string = "";
  private subjectCards: SubjectCard[] = [];
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
      {
        text: this.$t("subjectCardHeaders.nameInPolish"),
        value: "nameInPolish"
      },
      {
        text: this.$t("subjectCardHeaders.nameInEnglish"),
        value: "nameInEnglish"
      },
      { text: "", value: "action", sortable: false }
    ];
  }
  public async created() {
    this.fetchSubjectCards();
  }

  private async fetchPDF(subjectCardId: number, subjectCardCode: string) {
    this.loading = true;
    try {
      const response = await axios.get(`api/SubjectCard/${subjectCardId}/pdf`, {
        responseType: "blob"
      });
      const url = window.URL.createObjectURL(new Blob([response.data]));
      const link = document.createElement("a");
      link.href = url;
      link.setAttribute("download", `SubjectCard_${subjectCardCode}.pdf`);
      document.body.appendChild(link);
      link.click();
    } catch (e) {
    } finally {
      this.loading = false;
    }
  }

  private async fetchSubjectCards() {
    this.loading = true;
    try {
      const response = await axios.get<SubjectCard[]>("api/SubjectCard");
      this.subjectCards = response.data;
      console.log(this.subjectCards);
    } catch (e) {
    } finally {
      this.loading = false;
    }
  }

  private redirectToEdit(subjectCardId: number): void {
    this.$router.push(`edit-subject/${subjectCardId}`);
  }

  private deleteEffect(effectId: number): void {
    const response = axios.delete<SubjectCard[]>(`api/SubjectCard/${effectId}`);
    this.subjectCards = this.subjectCards.filter(x => x.id !== effectId);
  }
}
</script>
