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

        public ExtendedPlaylist(){ }

        // Конструктор (вызывает конструктор класса-родителя, который устанавливает имя плейлиста)
        public ExtendedPlaylist(String name ) : base(name) {}

        // Добавить любимую песню
        public void addFavorite(Song songToAdd)
        {
            Song song = findSong(songToAdd);

            if (song != null && !favorites.Contains(song))
                favorites.Add(songToAdd);
        }
        
        // Удаляет ее
        public void removeFavorite(Song songToRemove)
        {
            Song song = findSong(songToRemove);

            if(song != null)
            {
                favorites.Remove(song);
            }
        }
        //Получает песни
        public List<Song> getFavorites()
        {
            return favorites;
        }
        
        // Удаление песни, переопределяется, ибо нужно удалять ее из списка музыки и из списка любимой музыки
        public override void removeSong(Song songToRemove)
        {
            removeFavorite(songToRemove);

            Song song = findSong(songToRemove);
            if (song != null)
                songs.Remove(song);
        }
    }
}
