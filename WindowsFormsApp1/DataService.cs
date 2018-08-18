using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Music;

namespace WindowsFormsApp1
{
    class DataService
    {
        String directory = Directory.GetCurrentDirectory();
        public static List<AbstractPlaylist> playlists = new List<AbstractPlaylist>();

        public DataService()
        {
            directory = directory.Substring(0, directory.Length - 9);
            if(!playlists.Any())
                generatePlaylists();
        }
        
        private void generatePlaylists()
        {
            playlists.Add(fillPlayList(new ExtendedPlaylist("TestPlaylist")));
        }
        private AbstractPlaylist fillPlayList(AbstractPlaylist playList)
        {
            playList.addSong(new Song("T-Fest - ya znal", directory + "sources\\T-Fest-odno_ya_znal.mp3"));
            playList.addSong(new Song("This is America", directory + "sources\\Childish Gambino – This Is America.mp3"));
            playList.addSong(new Song("YeahRight", directory + "sources\\Joji – Yeah Right.mp3"));
            playList.addSong(new Song("RockStar", directory + "sources\\Post Malone ft. 21 Savage – Rockstar.mp3"));

            return playList;
        }

        public List<AbstractPlaylist> getPlaylists()
        {
            return playlists; 
        }
    }
}
