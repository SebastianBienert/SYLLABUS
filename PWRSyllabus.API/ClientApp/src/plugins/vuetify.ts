import '@mdi/font/css/materialdesignicons.css';
import Vue from 'vue';
import i18n from '@/plugins/vuei18n';

import Vuetify, {
  VAlert,
  VApp,
  VNavigationDrawer,
  VFooter,
  VList,
  VBtn,
  VIcon,
  VToolbar,
  VDataTable,
  VProgressLinear,
} from 'vuetify/lib';

// vue-cli a-la-carte installation
Vue.use(Vuetify, {
  components: {
    VAlert,
    VApp,
    VNavigationDrawer,
    VFooter,
    VList,
    VBtn,
    VIcon,
    VToolbar,
    VDataTable,
    VProgressLinear,
  },
});

const opts = {
  theme: {
    themes: {
      light: {
        primary: '#009688',
        secondary: '#607d8b',
        accent: '#cddc39',
        error: '#f44336',
        warning: '#ffeb3b',
        info: '#03a9f4',
        success: '#8bc34a',
      },
    },
  },
  lang: {
    t: (key: any, ...params: any) => i18n.t(key, params) as string,
  },
};

export default new Vuetify(opts);
