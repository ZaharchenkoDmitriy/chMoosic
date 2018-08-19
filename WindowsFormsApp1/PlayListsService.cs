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
        // Создание датасервиса и обьявление текущего плейлиста
        DataService dataService = new DataService();
        private AbstractPlaylist currentPlayList;
        
        // конструктор который утонавливает текущим плейлистом первый из списка
        public PlayListsService()
        {
            CurrentPlayList = dataService.getPlaylists()[0];    
        }
        
        //Свойство которое меняет значение текущего плейлиста
        // И возвращает либо текущий плейлист, либо пустой в случае если текущего нет
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

        //Добавление нового плейлиста
        public void addPlaylist(AbstractPlaylist playlist)
        {
            DataService.playlists.Add(playlist);
        }

        // Удаление плейлиста
        public void removePlayList(AbstractPlaylist playlist)
        {
            DataService.playlists.Remove(playlist);
        }

        // Получение плейлистов
        public List<AbstractPlaylist> getPlaylists()
        {
            return dataService.getPlaylists();               
        }
    }
}
