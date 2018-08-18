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
        private AbstractPlaylist currentPlayList;
        public PlayListsService()
        {
            CurrentPlayList = dataService.getPlaylists()[0];    
        }
        public AbstractPlaylist CurrentPlayList{
            set {
                this.currentPlayList = value;
            }
            get {
                if (currentPlayList != null)
                    return currentPlayList;
                else
                    return dataService.getEmptyPlayList();
            }
        }

        public void addPlaylist(AbstractPlaylist playlist)
        {
            DataService.playlists.Add(playlist);
        }

        public void removePlayList(AbstractPlaylist playlist)
        {
            DataService.playlists.Remove(playlist);
        }

        public List<AbstractPlaylist> getPlaylists()
        {
            return dataService.getPlaylists();               
        }
    }
}
