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
        // Путь к текущей дериктории (где запущен проект).
        String directory = Directory.GetCurrentDirectory();
        
        // Список плейлистов
        public static List<AbstractPlaylist> playlists = new List<AbstractPlaylist>();

        // Конструктор класса. В нем форматируется путь к дериктории что бы с этим можно было работать
        // и формируется плейлист, что бы были начальные данные. 
        public DataService()
        {
            directory = directory.Substring(0, directory.Length - 9);
            if(!playlists.Any())
                generatePlaylists();
        }
        
        
        // Функция для генерации плейлиста
        private void generatePlaylists()
        {
            playlists.Add(fillPlayList(new ExtendedPlaylist("TestPlaylist")));
        }
        // Функция заполнения плейлиста песнями
        private AbstractPlaylist fillPlayList(AbstractPlaylist playList)
        {
            playList.addSong(new Song("T-Fest - ya znal", directory + "sources\\T-Fest-odno_ya_znal.mp3"));
            playList.addSong(new Song("This is America", directory + "sources\\Childish Gambino – This Is America.mp3"));
            playList.addSong(new Song("YeahRight", directory + "sources\\Joji – Yeah Right.mp3"));
            playList.addSong(new Song("RockStar", directory + "sources\\Post Malone ft. 21 Savage – Rockstar.mp3"));

            return playList;
        }

        // Функция которая вазвращает плейлист
        public List<AbstractPlaylist> getPlaylists()
        {
            return playlists; 
        }
        // Функция для получения пустого плейлиста, нужна для случая когда все плейлисты удалены 
        public AbstractPlaylist getEmptyPlayList() {
            return new ExtendedPlaylist();
        }
    }
}
