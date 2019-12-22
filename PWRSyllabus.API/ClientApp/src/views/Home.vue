<template>
  <v-container fluid>
    <v-row align="center" justify="center">        
      <v-col class="text-center" cols="4" align-self="center">
        <v-btn block color="primary" to="/subject-cards">{{$t('mainMenu.subjectCards')}}</v-btn>
      </v-col>
    </v-row>
    <v-row align="center" justify="center"> 
      <v-col class="text-center" cols="4">
        <v-btn block color="primary" to="/trace-matrix">{{$t('mainMenu.trackingMatrix')}}</v-btn>
      </v-col>
    </v-row>
    <v-row align="center" justify="center"> 
      <v-col class="text-center" cols="4">
        <v-btn block color="primary">{{$t('mainMenu.studyPlans')}}</v-btn>
      </v-col>
    </v-row>
    <v-row align="center" justify="center"> 
      <v-col class="text-center" cols="4">
        <v-btn block color="primary">{{$t('mainMenu.ministerialEffects')}}</v-btn>
      </v-col>
    </v-row>

    <v-row align="center" justify="center"> 
      <v-col class="text-right" cols="2">
        <v-btn block color="primary" @click="changeLocale('pl')">{{$t('mainMenu.polish')}}</v-btn>
      </v-col>
      <v-col class="text-left" cols="2">
        <v-btn block color="primary" @click="changeLocale('en')">{{$t('mainMenu.english')}}</v-btn>
      </v-col>
    </v-row>

  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
  components: {
    HelloWorld,
  },
})
export default class Home extends Vue {
  public changeLocale(locale: string) {
    this.$i18n.locale = locale;
  }
}
</script>
