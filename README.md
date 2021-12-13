# Oppsett

## I Azure

### Strorage account

Applikasjonen trenger et sted å lagre sine todos. Dette løser vi ved å bruke tabel lagring i en storage account.

Om du ikke har en account fra før må du opprette en, samt lage en tabel som heter 'Sysut' (dette kan eventuelt endres
ved å redigere program.cs).

Velg en region som passer deg

### Azure app service

Sett opp en azure app service. Velg passende region (samme som Storage account).

Og en passende plan (basic eller standard) om du ikke har en allerede.
Velg deploye kode og .NET 6.

Når applikasjonen er laget må du legge inn connection string i configuration.
Legg til ny app setting, velg NET_CONNECTION_STRING (eller rediger navn i program.cs).
Connection string finner du under Access Keys til storage account.

## Github

Det skal allerede være definert et build og en release i `.github/workflows`
For at deploy skal fungere må publish profile legges inn som en secret i github.
Denne finnes i ovewview i portalen for Azure App Service-en, kopier innhold fra filen og lim in.

Pipeline forventer at variablen heter `AZURE_WEBAPP_PUBLISH_PROFILE`
Publish profile må matche `AZURE_WEBAPP_NAME`, dette skal være navnet på web app ressursen.

