using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Music
{
    class ExtendedPlaylist : Playlist
    {
        List<Song> favorites = new List<Song>();

        public void addFavorite(Song songToAdd)
        {
            Song song = findSong(songToAdd);

            if (song != null && !favorites.Contains(song))
                favorites.Add(songToAdd);
        }
        public void removeFavorite(Song songToRemove)
        {
            Song song = findSong(songToRemove);

            if(song != null)
            {
                favorites.Remove(song);
            }
        }
        public List<Song> getFavorites()
        {
            return favorites;
        }
        public override void removeSong(Song songToRemove)
        {
            removeFavorite(songToRemove);

            Song song = findSong(songToRemove);
            if (song != null)
                songs.Remove(song);
        }
    }
}
