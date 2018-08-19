fgtusing System;
usiung System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Music;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Создание плейлист сервиса
        PlayListsService playListService = new PlayListsService();
        // Конструктор формы, происходит отрисовка(рендер) списков и задание картинки для открытия файла
        public Form1()
        {
            String directory = Directory.GetCurrentDirectory();
            directory = directory.Substring(0, directory.Length - 9);

            InitializeComponent();
            rerender();
            renderPlaylists();

            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Image.FromFile(directory + "openFile.png");
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        // Отрисовка плейлиста тут удаляется старый ресурс и заного стягивается список плейлистов
        // Так же очищается поле для создание плейлиста и отрисовуется список песен
        private void renderPlaylists()
        {
            playLists.DataSource = null;

            playLists.DisplayMember = "Name";
            playLists.DataSource = playListService.getPlaylists();

            playListName.Text = "";
            rerender();
        }

        // Функция которая срабатывает при переключениях песни,
        // тут проверяется не играет ли уже эта песня и если нет,
        // то она включается  
        private void itemChanged(object sender, EventArgs e)
        {
            Song song = (Song) playlist.SelectedItem;
            if(axWindowsMediaPlayer1.URL == null || !axWindowsMediaPlayer1.URL.Equals(song.FilePath)){
                axWindowsMediaPlayer1.URL = song.FilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        // удаление песни. Берется текущая песня( выбранная в списке),
        // песня перед ней делается выбранной и удаляется песня после чего перерисовуется
        private void removeSong(object sender, EventArgs e)
        {
            Song song = (Song)playlist.SelectedItem;
            playlist.SelectedIndex = playlist.SelectedIndex - 1; 
            playListService.CurrentPlayList.removeSong(song);

            rerender();
        }


        //Добавление или удаление из любимых. проверяется в каком мы сейчас режиме
        //(любимых или нет. Берется текущая песня из списка, если мы в обычных песнях,
        // то добавляем в любимые, если в любимых то удаляем из них и перерисувуем. 
        private void addToFavorite(object sender, EventArgs e)
        {
            bool favorite = toFavorite.Text.Equals("Favorite");
            Song song = (Song)playlist.SelectedItem;

            if(favorite)
                ((ExtendedPlaylist)playListService.CurrentPlayList).addFavorite(song);
            else
                ((ExtendedPlaylist) playListService.CurrentPlayList).removeFavorite(song); 
            
            rerender();
        }
        // Перерисовка:
        // скидывается текущий список, устанавлевается отображаемое свойство обьекта,
        // проверяется в каком мы режиме и в зависимости устанавливается как ресурс, либо любимые песни ли обычные
        private void rerender()
        {
            playlist.DataSource = null;

            playlist.DisplayMember = "Name";
            playlist.DataSource = favorites.Text.Equals("Favorites")
                ? ((ExtendedPlaylist)playListService.CurrentPlayList).getSongs()
                : ((ExtendedPlaylist)playListService.CurrentPlayList).getFavorites();
                
        }

        // Функция которя срабатывает при нажатии кнопки переключения любимых 
        // Проверяет в каком мы режиме и меняет режымы(просто подменяет текст на кнопках и перерисовует)
        private void showFavorites(object sender, EventArgs e)
        {
            bool favorite = favorites.Text.Equals("Favorites");
            
            favorites.Text = favorite ? "All" : "Favorites";
            toFavorite.Text = favorite ? "Remove" : "Favorite";
            
            rerender();
        }

        // Функция для открытия файла: открывает диалоговое окно для выбора файла и добавляет песню которую выбрал пользователь
        private void openFile(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            ((ExtendedPlaylist)playListService.CurrentPlayList).addSong(new Song(openFileDialog1.FileName.Split('\\').Last(), openFileDialog1.FileName));
            rerender(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Добавление плейлиста 
        private void addPlayList_Click(object sender, EventArgs e)
        {
            playListService.addPlaylist(new ExtendedPlaylist(playListName.Text));

            renderPlaylists();
        }
        // удаление плейлиста
        // получаем текущий, переключаемся на предыдущий и удаляем нужный
        private void removePlayListButton_Click(object sender, EventArgs e)
        {
            AbstractPlaylist selectedPlaylist = (ExtendedPlaylist)playLists.SelectedItem;
            playLists.SelectedIndex = playLists.SelectedIndex - 1;
            playListService.removePlayList(selectedPlaylist);

            renderPlaylists();
        }

        // при переключение плейлистов, устанавливаем в плейлист сервис текущий плейлист и перерисовуем
        private void playLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            playListService.CurrentPlayList = (ExtendedPlaylist)playLists.SelectedItem;
            rerender();
        }
    }
}
