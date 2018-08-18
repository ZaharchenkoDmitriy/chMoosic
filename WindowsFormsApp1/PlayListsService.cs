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
        DataService dataService = new DataService();
        
        public PlayListsService()
        {
            CurrentPlayList = dataService.getPlaylists()[0];    
        }
        public AbstractPlaylist CurrentPlayList{ get; set; }

        public void addPlaylist(AbstractPlaylist playlist)
        {
            
        }

        public List<AbstractPlaylist> getPlaylists()
        {
            return dataService.getPlaylists();               
        }
    }
}
