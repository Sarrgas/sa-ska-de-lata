# Så Ska Det Låta - Sällskapsspel

## Deploy
Då jag tydligen ofta gör fel när jag ska deploya, så skriver jag ner instruktioner här till mig själv. 

Öppna en terminal i rätt folder (den foldern med Dockerfile i) och kör följande kommandon:

```
dotnet publish
```
```
heroku container:push web -a sa-ska-det-lata
```
```
heroku release:push web -a sa-ska-det-lata
```
