# Projekt zaliczeniowy - Clean Architecture .NET

## Instrukcja uruchomienia

### 1. Uruchomienie serwisów (każdy w osobnym terminalu):

**a) REST API** (port 5135)
```bash
cd src/WebApi
dotnet run

Dostępne pod: http://localhost:5135/swagger

b) GraphQL (port 5123)
bash

cd src/WebServices
dotnet run

Dostępne pod: http://localhost:5123/graphql

c) Panel administracyjny (port 5164)
bash

cd src/RazorAdmin
dotnet run

Dostępne pod: http://localhost:5164
2. Logowanie do panelu:

Wejdź na: http://localhost:5164/Login

Dane dostępu:

    Administrator:

        Login: admin

        Hasło: admin123

    Użytkownik:

        Login: user

        Hasło: user123



Uwaga: Porty mogą się zmienić jeśli są zajęte - aktualne adresy zawsze pojawiają się w konsoli po uruchomieniu dotnet run.