export default {
    $vuetify: {
        close: 'Zamknij',
        dataIterator: {
          noResultsText: 'Nie znaleziono danych odpowiadających wyszukiwaniu',
          loadingText: 'Wczytywanie danych...',
        },
        dataTable: {
          itemsPerPageText: 'Wierszy na stronie:',
          ariaLabel: {
            sortDescending: ': Sortowanie malejąco. Kliknij aby zmienić.',
            sortAscending: ': Sortowanie rosnąco. Kliknij aby zmienić.',
            sortNone: ': Bez sortowania. Kliknij aby posortować rosnąco.',
          },
          sortBy: 'Sortuj według',
        },
        dataFooter: {
          itemsPerPageText: 'Pozycji na stronie:',
          itemsPerPageAll: 'Wszystkie',
          nextPage: 'Nastęna strona',
          prevPage: 'Poprzednia strona',
          firstPage: 'Pierwsza strona',
          lastPage: 'Ostatnia strona',
          pageText: '{0}-{1} z {2}',
        },
        datePicker: {
          itemsSelected: '{0} dat(y)',
        },
        noDataText: 'Brak danych',
        carousel: {
          prev: 'Poprzedni obraz',
          next: 'Następny obraz',
          ariaLabel: {
            delimiter: 'Carousel slide {0} of {1}',
          },
        },
        calendar: {
          moreEvents: '{0} więcej',
        },
        fileInput: {
          counter: 'Liczba plików: {0}',
          counterSize: 'Liczba plików: {0} (łącznie {1})',
        },
        timePicker: {
          am: 'AM',
          pm: 'PM',
        },
    },
    submit: 'Zapisz',
    cancel: 'Anuluj',
    search: 'Szukaj',
    edit: 'Edytuj',
    header: 'System wspomagajacy tworzenie i modyfikowanie programów studiów',
    mainMenu: {
        subjectCards: 'Karty przedmiotów',
        trackingMatrix: 'Macierz śladowania',
        studyPlans: 'Plany/Programy studiów',
        ministerialEffects: 'Ministerialne efekty kształcenia',
        polish: 'Polski',
        english: 'Angielski',
    },
    subjectCardsHeaders: {
        faculty: 'Wydział',
        fieldOfStudy: 'Kierunek',
        specialization: 'Specjalizacja',
        code: 'Kod',
        subjectName: 'Nazwa przedmiotu',
        newSubject: 'Nowy przedmiot'
    },
    traceMatrixHeaders: {
        ministerialEffectCode: 'Kod efektu ministerialnego',
        ministerialEffect: 'Efekt ministerialny',
        educationalEffectCode: 'Kod efektu kształcenia',
        educationalEffect: 'Efekt kształcenia',
    },
    ministerialEffectsHeaders: {
      category: 'Kategoria',
      descriptiveCategory: 'Kategoria opisowa',
      code: 'Kod',
      level: 'Poziom',
      discipline: 'Dyscyplina',
      description: 'Opis',
      addEffect: 'Nowy efekt'
    },
    studyProgramsHeaders: {
      faculty: 'Wydział',
      fieldOfStudy: 'Kierunek',
      specialization: 'Specjalizacja',
      level: 'Poziom',
      language: 'Język',
      formOfStudies: 'Forma studiów',
      newProgram: 'Nowy program',
      selectSubjectCards: 'Wybierz karty przedmiotów',
      searchAndSelectSubjectCards: 'Wyszukaj i wybierz karty przedmiotów',
      select: 'Wybierz',
      subjectCode: 'Kod kursu',
      name: 'Nazwa'
    },
    subjectCardHeaders: {
      nameInPolish: 'Nazwa w języku polskim',
      nameInEnglish: 'Nazwa w języku angielskim',
      subjectCode: 'Kod przedmiotu',
      fieldOfStudy: 'Kierunek',
      specialization: 'Specjalność',
      level: 'Stopień studiów',
      formOfStudies: 'Forma studiów',
      courseGroup: 'Grupa kursów',
      subjectType: 'Rodzaj przedmiotu',
      prerequisites: 'Wymagania wstępne',
      objectivities: 'Cele przedmiotu',
      teachingTools: 'Narzędzia dydaktyczne',
      literature: 'Literatura',
      supervisor: 'Opiekun przedmiotu',

    }
};
