using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Music
{
    class Playlist : AbstractPlaylist
    {
        protected List<Song> songs = new List<Song>();
        
        public override String Name { get; set; }

        public Playlist()
        {

        }
        public Playlist(String name)
        {
            Name = name;
        }

        public override void addSong(Song songToAdd)
        {
            Song song = findSong(songToAdd);

            if(song ==null)
                songs.Add(songToAdd);
        }

        public override void removeSong(Song songToRemove)
        {
            Song song = findSong(songToRemove);
            if (song != null)
                songs.Remove(song);
        }
   
        protected Song findSong(Song songToFind)
        {
            foreach (Song song in songs)
            {
                if (song.FilePath.Equals(songToFind.FilePath))
                    return song;
            }

            return null;
        }
        public List<Song> getSongs()
        {
            return songs;
        }
    }
}
