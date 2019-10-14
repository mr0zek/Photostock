# PhotoStock (Wzorce architektoniczne dla architektów i projektantów – ćwiczenia praktyczne

## Opis domeny

Będziesz tworzył system będący częścią ogólno-światowego portalu (PhotoStock) do handlu zdjęciami. Portal obsługuje zarówno artystów, którzy mogą sprzedawać swoje zdjęcia, jak i grafików który te zdjęcia kupują. W momencie kiedy kupujący zaakceptuje swoja decyzje staje się właścicielem praw autorskich.
Wymagania ogólne

### Wymagania ogólne
System powinien pozwolić artystom na dodawanie i zarządzanie zdjęciami w katalogu poprzez stronę www.  
Katalog ten powinien być dostępny również dla grafików którzy będą z niego wybierać zdjęcia z składać zamówienie również przez stronę www. 
Proces kompletowania zamówienia może trwać wiele dni. Dla zaakceptowanych zamówień system pobiera opłatę w formie kredytów z konta prepaid. Konto może zostać zasilone przelewem.  Informacje o przelewach są importowane z banku przez dedykowane API. Jest to realizowane 3 razy dziennie. 
Dla zamówień w pełni opłaconych system wystawia fakturę i zleca wysyłkę zdjęć w formie papierowej. 
Graficy są informowani mailowo o zrealizowanej wysyłce zdjęć.

### Wymagania szczegółowe
Wymagania szczegółowe ( strona kupująca )
Zakres prac będzie dotyczył obsługi zamówień strony kupującej. Kupujący będzie miał możliwość wstępnej rezerwacji zdjęć

#### 1. 
Klienci mogą dodawać zdjęcia do zamówienia z katalogu. Kilkukrotne dodanie do zamówienia tego samego zdjęcia nie ma sensu. 
System uniemożliwia również kilkakrotny zakup (różne zamówienia) tego samego zdjęcia przez jednego użytkownika.

#### 2. 
Klienci mogą poddać zamówienie zmianom zanim ostatecznie jest zatwierdzą. Zamówienie nie jest wiążące do momentu zatwierdzenia. Jest w zasadzie wstępną rezerwacją produktów.
W trakcie pracy nad rezerwacją ceny zdjęć mogą ulec zmianie. Zasada jest taka, że klient zawsze rezerwuje produkty po cenach aktualnie obowiązujących w systemie (a nie takich jakie widział), ale musi również widzieć ceny jakie zostaną zastosowane. 
Klienci przed zatwierdzeniem rezerwacji muszą zobaczyć aktualną ofertę do zamówienia jaką zaproponuje mu system.  Oferta powinna zawierać produkty wraz z aktualnymi cenami (a w przyszłości również z aktualnie obowiązującymi promocjami).  
Może zajść sytuacja gdy dzieło jest już niedostępne (np. z powodu usunięcia z katalogu). Oczywiście klient powinien widzieć taki produkt, ale jako nieaktywny.
Oferta nie jest zobowiązująca, klient może zatwierdzić lub odrzucić taką ofertę. Zatwierdzając ofertę dokonujemy formalnego zakupu. Jeżeli oferta, którą widział klient jest inna niż obowiązująca oferta, to nie może dojść do zakupu a klient powinien wówczas zobaczyć nową ofertę. 

#### 3.
Gdy klient zatwierdza zamówienie (ofertę) to wówczas system nie zezwala na zakupy jeżeli klient nie posiada dostatecznej ilości pieniędzy (konto jest doładowane w formie prepaid przez zewnętrzny system).

#### 4. 
System powinien przechowywać podpisaną cyfrowo historię zakupów klienta (co, kiedy i za ile) jako ew. dowód w postępowaniu sądowym. Dla każdego zakupu powinien być generowany fakt zakupu,  który odzwierciedla ceny z oferty i nie podlega już zmianom gdy zmieniają się ceny katalogowe i rabaty.
#### 5. 
Podczas zakupu sprawdzamy czy klient posiada dostateczną ilość środków (credit). Jeżeli nie, to nie może dokonać zakupu, chyba, że jest klientem VIP, wówczas udzielamy mu kredytu, chyba, że przekroczył limit kredytów. Jeżeli klient posiada dostateczną ilość środków (wg powyższych reguł) to pobieramy opłatę i odnotowujemy fakt płatności.

### Zatwierdzanie oferty - wymagania szczegółowe

Oferta nie jest zobowiązująca, klient może zatwierdzić lub odrzucić taką ofertę. 
Zatwierdzając ofertę dokonujemy formalnego zakupu. Jeżeli oferta, którą widział klient jest inna niż obowiązująca oferta, 
to nie może dojść do zakupu a klient powinien wówczas zobaczyć nową ofertę. 

Gdy klient zatwierdza zamówienie (ofertę) to wówczas system nie zezwala na zakupy jeżeli klient nie posiada dostatecznej ilości pieniędzy 
(konto jest doładowane w formie prepaid przez zewnętrzny system). Jeżeli różnica pomiędzy oferta zaakceptowaną a ofertą aktualną 
nie jest większa niż 5% to pozwalamy na zakup towarów o cenie jakie zaakceptował klient.

System powinien przechowywać podpisaną cyfrowo historię zakupów klienta (co, kiedy i za ile) jako ew. dowód w postępowaniu sądowym. 
Dla każdego zakupu powinien być generowany fakt zakupu,  który odzwierciedla ceny z oferty i nie podlega 
już zmianom gdy zmieniają się ceny katalogowe i rabaty.

Podczas zakupu sprawdzamy czy klient posiada dostateczną ilość środków (credit). Jeżeli nie, to nie może dokonać zakupu, chyba, że jest 
klientem VIP, wówczas udzielamy mu kredytu, chyba, że przekroczył limit kredytów. Jeżeli klient posiada dostateczną ilość 
środków (wg powyższych reguł) to pobieramy opłatę i odnotowujemy fakt płatności.

Pytania pomocnicze:
•	Jak zrealizować pobranie danych o kliencie ?
•	Kiedy dwie oferty są takie same ?

