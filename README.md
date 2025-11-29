Struktura projektu:
- Tests - testy zarówno UI + klasa BaseTest jak i API
- TestData - dane testowe (loginy i hasła, URLe, body do requestów po API)
- Reports - plik konfiguracyjny raportów Allure
- PageObjects - klasy odwzorowujące strony HTML
- DTO - klasy do przenoszenia danych

Opis testów:
LoginTest - klasa zawiera pozytywny i negatywne scenariusze logowania
AddToCartTest - dodanie jednego produktu do koszyka i weryfikacja zawartości oraz możliwości wykonania dalszych akcji
ShoppingTest - zakup dwóch produktów, weryfikacja poprawności zamówienia, przejscie do końca procesu
ApiTests - testy: pobierania, utwozenie lub aktualizacji, usunięcia użytkownika oraz autoryzacji request

Dobór narzędzi (Selenium Webdriver, RestSharp, Allure, Nunit) wynikał głównie z ich znajomości, ewentualnie z tego że próba konfiguracji innego narzędzia (np. Extent Reports) sprawiała czasochłonne problemy. 

Dane testowe przechowuję w plikach .json, ponieważ sposób ten nadawał się zarówno do wymagań postawionych w testach UI jak i do tworzenia body requestów REST-owych. W testach API przekazuję też dane wejściowe w atrybucie TestCase.

Testy domyślnie uruchamiają się w trybie headed, uruchomienie w trybie headless wymaga odkomentowania lini 25 w klasie BaseTest.cs.

Co bym usprawniła, gdybym miała więcej czasu/zasobów:
- obsługa wielu przeglądarek, jest tylko Chrome
- screenshoty w momencie zakończenia testu, przydają się zwłaszcza w trybie headless do inwestygacji faili
- nie byłam pewna jak podejsć do elementów na stronie z tekstem typu "Test.allTheThings() T-Shirt (Red)" - czy przypadkiem nie jest to błąd, który test powinien zgłosić. Potraktowałam jak feature, ale daję znać że w realnym świecie konsultowałabym to
- wyliczanie łącznej ceny produktów i podatku można było zrobić dynamicznie (zsumować ceny detaliczne, zaokrąglić sumę w góre do pełnej wartości, policzyć od tego 108% i tak wychodziła cena z podatkiem)
- w testach koszyka/zakupów dla czyszczę koszyk na początku scenariusza testowego. Możliwe że poprawniej byłoby robić to w setUp. Test powinien także po sobie posprzątać
- zmina trybu headless/headed pewnie mogłaby być w configu
- modyfikatory dostępu - pewnie mam za dużo public