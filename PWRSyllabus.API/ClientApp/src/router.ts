import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/counter',
      name: 'counter',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "counter" */ './views/Counter.vue'),
    },
    {
      path: '/fetch-data',
      name: 'fetch-data',
      component: () => import('./views/FetchData.vue'),
    },
    {
      path: '/subject-cards',
      name: 'subject-cards',
      component: () => import('./views/subjectCards/SubjectCards.vue'),
    },
    {
      path: '/trace-matrix',
      name: 'trace-matrix',
      component: () => import('./views/traceMatrix/TraceMatrixTable.vue'),
    },
    {
      path: '/ministerial-effects',
      name: 'ministerial-effects',
      component: () => import('./views/ministerialEffects/MinisterialEffectsTable.vue'),
    },
    {
      path: '/add-ministerial-effect',
      name: 'add-ministerial-effect',
      component: () => import('./views/ministerialEffects/AddMinisterialEffect.vue'),
    },
    {
      path: '/edit-ministerial-effect/:id',
      name: 'edit-ministerial-effect',
      component: () => import('./views/ministerialEffects/EditMinisterialEffect.vue'),
    },
    {
      path: '/study-programs',
      name: 'study-programs',
      component: () => import('./views/studyPrograms/StudyProgramsTable.vue'),
    },
    {
      path: '/add-study-program',
      name: 'add-study-program',
      component: () => import('./views/studyPrograms/AddStudyProgram.vue'),
    },
    {
      path: '/edit-study-program/:id',
      name: 'edit-study-program',
      component: () => import('./views/studyPrograms/EditStudyProgram.vue'),
    }
  ],
});
