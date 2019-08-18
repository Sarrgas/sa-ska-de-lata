# Så Ska Det Låta - Sällskapsspel

## Utveckling
För att utveckla och köra systemet lokalt behöver du ha Visual Studio installerat. Finns att installera här https://visualstudio.microsoft.com/vs/community/ . Därefter borde det bara vara att klona repot och köra.
Kommunikation mellan "spelet" och admin-sidan sker med hjälp av ramverket SignalR. De pratar med varandra genom klassen `Hubs/ComsHub.cs` samt js-filerna `wwwroot/js/game.js` för spelet och `wwwoot/js/admin.js` för admin-sidan. 

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
