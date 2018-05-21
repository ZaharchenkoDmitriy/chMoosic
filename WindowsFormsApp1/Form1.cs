using System;
using System.Collections.Generic;
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
        ExtendedPlaylist playlistContent = new ExtendedPlaylist();
        
        public Form1()
        {
            String directory = Directory.GetCurrentDirectory();
            directory = directory.Substring(0, directory.Length - 9);

            playlistContent.addSong(new Song("T-Fest - ya znal", directory + "sources\\T-Fest-odno_ya_znal.mp3"));
            playlistContent.addSong(new Song("This is America", directory+ "sources\\Childish Gambino – This Is America.mp3"));
            playlistContent.addSong(new Song("YeahRight", directory+ "sources\\Joji – Yeah Right.mp3"));
            playlistContent.addSong(new Song("RockStar", directory+ "sources\\Post Malone ft. 21 Savage – Rockstar.mp3"));
            
            InitializeComponent();
            rerender();

            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Image.FromFile(directory + "openFile.png");
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void itemChanged(object sender, EventArgs e)
        {
            Song song = (Song) playlist.SelectedItem;
            if(axWindowsMediaPlayer1.URL == null || !axWindowsMediaPlayer1.URL.Equals(song.FilePath)){
                axWindowsMediaPlayer1.URL = song.FilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void removeSong(object sender, EventArgs e)
        {
            Song song = (Song)playlist.SelectedItem;
            playlistContent.removeSong(song);

            rerender();
        }


        private void addToFavorite(object sender, EventArgs e)
        {
            if(toFavorite.Text.Equals("Favorite"))
            {
                Song song = (Song)playlist.SelectedItem;
                playlistContent.addFavorite(song);
            } else
            {
                Song song = (Song)playlist.SelectedItem;
                playlistContent.removeFavorite(song);
                rerender();
            }
        }

        private void rerender()
        {
            playlist.DataSource = null;

            playlist.DisplayMember = "Name";
            playlist.DataSource = favorites.Text.Equals("Favorites")
                ? playlistContent.getSongs()
                : playlistContent.getFavorites();
                
        }

        private void showFavorites(object sender, EventArgs e)
        {
            if(favorites.Text.Equals("Favorites"))
            {
                favorites.Text = "All";
                toFavorite.Text = "Remove";
                rerender();
            } else
            {
                favorites.Text = "Favorites";
                toFavorite.Text = "Favorite";
                rerender();
            }
        }

        private void openFile(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            playlistContent.addSong(new Song(openFileDialog1.FileName.Split('\\').Last(), openFileDialog1.FileName));
            rerender(); 
        }
       
    }
}
