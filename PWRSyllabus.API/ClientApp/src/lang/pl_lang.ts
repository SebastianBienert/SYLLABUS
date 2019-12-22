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
    },
    traceMatrixHeaders: {
        ministerialEffectCode: 'Kod efektu ministerialnego',
        ministerialEffect: 'Efekt ministerialny',
        educationalEffectCode: 'Kod efektu kształcenia',
        educationalEffect: 'Efekt kształcenia',
    },
};
