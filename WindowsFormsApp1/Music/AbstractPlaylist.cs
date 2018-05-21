using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Music
{
    abstract class AbstractPlaylist
    {
        protected List<Song> songs = new List<Song>();

        public abstract void addSong(Song songToAdd);

        public abstract void removeSong(Song songToRemove);    
    }
}
