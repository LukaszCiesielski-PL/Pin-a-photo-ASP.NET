# PinAphoto-ASP.NET
-----------------------
**OPIS I URUCHOMIENIE SIECIOWE**
-----------------------
Aplikacja ta symuluje częściowe funkcje Pinteresta.

Strona uruchomiona na usłudze Microsoft Azure
Link do strony: **pinaphoto.azurewebsites.net**

Zawiera domyślnie stworzone konto administratora. **Login - Admin / Hasło - Qazwsx123!** 


-----------------------
**KONFIGURACJA I URUCHOMIENIE LOKALNE**
-----------------------
- Admin: Login - Admin / Hasło - Qazwsx123!
- Użytkownik: Login - Qwerty / Hasło - Qazwsx123!

**Aby uruchomić aplikację lokalnie trzeba:**

**1.** W pliku **appsetings.json** należy zmienić **ConnectionString** 
  - DATA SOURCE={Nazwa maszyny};Integrated Security=true;DATABASE={Nazwa bazy};Trusted_Connection=True;MultipleActiveResultSets=True
  
  Przykład
  
  - DATA SOURCE=DESKTOP-MMS65A0;Integrated Security=true;DATABASE=PinAPhoto; Database=Identity; Trusted_Connection=True;MultipleActiveResultSets=true

**2.** Utworzyć bazę danych poprzez wpisanie w **konsoli menadżera pakietów** 
  - **add-migration nazwamigracji**
  
  Po sukcesie
  
  - **update-database -verbose**
  
  Powinno nam to utworzyć lokalną bazę danych z Administratorem


-----------------------
**DZIAŁAJĄCE FUNKCJONALNOŚCI**
-----------------------
- Walidacja wprowadzanych danych dla wszystkich formularzy
- Rejestracja nowych użytkowników
- Logowanie z podziałem na:
  - użytkownika
  - administratora
  - gościa (nie wymaga zalogowania)
- Osobne wyglądy interfaceu dla użytkownika i administratora
- CRUD z utrwaleniem danych dla użytkownika
- CRUD dla zdjęć
-----------------------
**Użytkownik** 
- może logować się
- może wyświetlać swoje dane
- może edytować swoje dane w profilu
- może uploadować zdjęcia
- może usuwać zdjęcia
- może edytować właściwości zdjęcia

**Administrator**
- wszystko co Użytkownik
- PLUS
- może wyświetlać wszystkich użytkowników
- może usuwać użytkowników
 
**Gość**
- może przeglądać tylko główną stronę
- utworzyć konto w serwisie
