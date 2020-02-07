<template>
  <v-app>

    <v-navigation-drawer dark color="primary" persistent :mini-variant="miniVariant" :clipped="clipped" v-model="drawer" enable-resize-watcher fixed app>
      <v-list>
        <v-list-item value="true" v-for="(item, i) in items" :key="i" :to="item.link">
          <v-list-item-action>
            <v-icon v-html="item.icon"></v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title"></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app :clipped-left="clipped" class="white--text" color="primary" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-btn class="d-none d-lg-flex" icon @click.stop="miniVariant = !miniVariant">
        <v-icon v-html="miniVariant ? 'chevron_right' : 'chevron_left'"></v-icon>
      </v-btn>
      <v-btn class="d-none d-lg-flex" icon @click.stop="clipped = !clipped">
        <v-icon>web</v-icon>
      </v-btn>
      <v-toolbar-title v-text="title"></v-toolbar-title>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-content>
      <router-view/>
    </v-content>

  </v-app>
</template>

<script lang="ts">
import HelloWorld from '@/components/HelloWorld.vue';
import SelectSubjectCards from '@/views/studyPrograms/SelectSubjectCards.vue';
import { Component, Vue } from 'vue-property-decorator';

@Component({
  components: { HelloWorld, SelectSubjectCards },
})
export default class App extends Vue {
  private clipped: boolean = true;
  private drawer: boolean = true;
  private miniVariant: boolean = false;
  private right: boolean = true;

  get items() {
    return [
      { title: 'Menu', icon: 'home', link: '/' },
      { title: this.$t('mainMenu.studyPlans'), icon: 'mdi-briefcase', link: '/study-programs' },
      { title: this.$t('mainMenu.ministerialEffects'), icon: 'mdi-meditation', link: '/ministerial-effects' },
      { title: this.$t('mainMenu.subjectCards'), icon: 'mdi-cards-playing-outline', link: '/subject-cards' },
      { title: this.$t('mainMenu.trackingMatrix'), icon: 'mdi-sunglasses', link: '/trace-matrix' }
    ];
  }

  private get title() {
    return this.$t('header');
  }

  private getTitleFromTranslation(title: string) {
    return this.$t(title);
  }

}
</script>

<style>

th{
  white-space: nowrap;
}

.table--action{
  white-space: nowrap;
}

</style>
