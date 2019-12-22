import VueI18n from 'vue-i18n';
import Vue from 'vue';
import pl_lang from '@/lang/pl_lang';
import en_lang from '@/lang/en_lang';

Vue.use(VueI18n);

const messages = {
    en: en_lang,
    pl: pl_lang,
};

const i18n = new VueI18n({
    locale: 'en',
    messages,
});

export default i18n;
