using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Music;

namespace WindowsFormsApp1
{
    class PlayListsService
    {
        public PlayListsService()
        {
            CurrentPlayList = new DataService().getPlaylists()[0];
        }
        public AbstractPlaylist CurrentPlayList{ get; set; }
    }
}
