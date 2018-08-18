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
        PlayListsService playListService = new PlayListsService();

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

        private void renderPlaylists()
        {
            playLists.DataSource = null;

            playLists.DisplayMember = "Name";
            playLists.DataSource = playListService.getPlaylists();

            playListName.Text = "";
            rerender();
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
            playListService.CurrentPlayList.removeSong(song);

            rerender();
        }


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

        private void rerender()
        {
            playlist.DataSource = null;

            playlist.DisplayMember = "Name";
            playlist.DataSource = favorites.Text.Equals("Favorites")
                ? ((ExtendedPlaylist)playListService.CurrentPlayList).getSongs()
                : ((ExtendedPlaylist)playListService.CurrentPlayList).getFavorites();
                
        }

        private void showFavorites(object sender, EventArgs e)
        {
            bool favorite = favorites.Text.Equals("Favorites");
            
            favorites.Text = favorite ? "All" : "Favorites";
            toFavorite.Text = favorite ? "Remove" : "Favorite";
            
            rerender();
        }

        private void openFile(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            ((ExtendedPlaylist)playListService.CurrentPlayList).addSong(new Song(openFileDialog1.FileName.Split('\\').Last(), openFileDialog1.FileName));
            rerender(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addPlayList_Click(object sender, EventArgs e)
        {
            playListService.addPlaylist(new ExtendedPlaylist(playListName.Text));

            renderPlaylists();
        }

        private void removePlayListButton_Click(object sender, EventArgs e)
        {
            AbstractPlaylist selectedPlaylist = (ExtendedPlaylist)playLists.SelectedItem;
            playLists.SelectedIndex = playLists.SelectedIndex - 1;
            playListService.removePlayList(selectedPlaylist);

            renderPlaylists();
        }

        private void playLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            playListService.CurrentPlayList = (ExtendedPlaylist)playLists.SelectedItem;
            rerender();
        }
    }
}
