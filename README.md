# Så Ska Det Låta - Sällskapsspel

## Utveckling
För att utveckla och köra systemet lokalt behöver du ha Visual Studio med ASP.NET Core version 2.2 (eller högre) installerat. Visual Studio finns att installera här https://visualstudio.microsoft.com/vs/community/ och senaste versionen av .NET Core SDK finns att installera här https://dotnet.microsoft.com/download. Därefter borde det bara vara att klona repot och köra.
Kommunikation mellan "spelet" och admin-sidan sker med hjälp av ramverket SignalR. De pratar med varandra genom klassen `Hubs/ComsHub.cs` samt js-filerna `wwwroot/js/game.js` för spelet och `wwwoot/js/admin.js` för admin-sidan.

Exempel:
När man trycker "Nästa låt" i admin-sidan, körs följande kodsnutt i `admin.js`:
```javascript
connection.invoke("NextSong")
```
Vilket kallar på funktionen "NextSong" i `ComsHub.cs`, som kör nedanstående:
```C#
public async Task NextSong()
{
  _session.NextSong();
  await Clients.All.SendAsync("NextSong");
}
```
Varpå den skickar meddelandet "NextSong" till alla klienter. Därefter är det klientens ansvar att lyssna på meddelandet och svara därefter. Detta görs då i `game.js` på följande vis:
```javascript
connection.on("NextSong", function () {
    resetNumbers();
});
```
Där den lyssnar efter meddelandet "NextSong", och återställer panelerna till siffror igen.

## Deploy
Då jag tydligen ofta gör fel när jag ska deploya, så skriver jag ner instruktioner här till mig själv. 

Se till att Docker klienten är igång, och öppna en terminal i rätt folder (den foldern med Dockerfile i) och kör följande kommandon:

```
dotnet publish
```
```
heroku login
```
```
heroku container:login
```
```
heroku container:push web -a sa-ska-det-lata
```
```
heroku container:release web -a sa-ska-det-lata
```

Dummy-ändring för att trigga CI action