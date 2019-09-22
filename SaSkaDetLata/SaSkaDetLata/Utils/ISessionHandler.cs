namespace SaSkaDetLata.Utils
{
    using SaSkaDetLata.Models;

    public interface ISessionHandler
    {
        int SongCount { get; set; }

        Song CurrentSong { get; set; }

        void NextSong();

        void Reset();
    }
}
