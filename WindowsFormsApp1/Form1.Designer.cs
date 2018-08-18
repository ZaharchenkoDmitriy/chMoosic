namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.playlist = new System.Windows.Forms.ListBox();
            this.playLists = new System.Windows.Forms.ListBox();
            this.favorites = new System.Windows.Forms.Button();
            this.toFavorite = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.addPlayList = new System.Windows.Forms.Button();
            this.removePlayListButton = new System.Windows.Forms.Button();
            this.playListName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(189, 463);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(612, 44);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // playlist
            // 
            this.playlist.FormattingEnabled = true;
            this.playlist.Location = new System.Drawing.Point(189, 24);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(611, 433);
            this.playlist.TabIndex = 1;
            this.playlist.Click += new System.EventHandler(this.itemChanged);
            // 
            // playLists
            // 
            this.playLists.FormattingEnabled = true;
            this.playLists.Location = new System.Drawing.Point(8, 22);
            this.playLists.Name = "playLists";
            this.playLists.Size = new System.Drawing.Size(175, 485);
            this.playLists.TabIndex = 2;
            this.playLists.SelectedIndexChanged += new System.EventHandler(this.playLists_SelectedIndexChanged);
            // 
            // favorites
            // 
            this.favorites.Location = new System.Drawing.Point(628, 412);
            this.favorites.Name = "favorites";
            this.favorites.Size = new System.Drawing.Size(99, 44);
            this.favorites.TabIndex = 3;
            this.favorites.Text = "Favorites";
            this.favorites.UseVisualStyleBackColor = true;
            this.favorites.Click += new System.EventHandler(this.showFavorites);
            // 
            // toFavorite
            // 
            this.toFavorite.Location = new System.Drawing.Point(406, 412);
            this.toFavorite.Name = "toFavorite";
            this.toFavorite.Size = new System.Drawing.Size(99, 44);
            this.toFavorite.TabIndex = 4;
            this.toFavorite.Text = "Favorite";
            this.toFavorite.UseVisualStyleBackColor = true;
            this.toFavorite.Click += new System.EventHandler(this.addToFavorite);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(511, 412);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(99, 44);
            this.remove.TabIndex = 5;
            this.remove.Text = "Delete";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.removeSong);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 37);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openFile);
            // 
            // addPlayList
            // 
            this.addPlayList.Location = new System.Drawing.Point(28, 473);
            this.addPlayList.Name = "addPlayList";
            this.addPlayList.Size = new System.Drawing.Size(66, 23);
            this.addPlayList.TabIndex = 7;
            this.addPlayList.Text = "Add";
            this.addPlayList.UseVisualStyleBackColor = true;
            this.addPlayList.Click += new System.EventHandler(this.addPlayList_Click);
            // 
            // removePlayListButton
            // 
            this.removePlayListButton.Location = new System.Drawing.Point(100, 473);
            this.removePlayListButton.Name = "removePlayListButton";
            this.removePlayListButton.Size = new System.Drawing.Size(66, 23);
            this.removePlayListButton.TabIndex = 8;
            this.removePlayListButton.Text = "Delete";
            this.removePlayListButton.UseVisualStyleBackColor = true;
            this.removePlayListButton.Click += new System.EventHandler(this.removePlayListButton_Click);
            // 
            // playListName
            // 
            this.playListName.Location = new System.Drawing.Point(12, 447);
            this.playListName.Name = "playListName";
            this.playListName.Size = new System.Drawing.Size(167, 20);
            this.playListName.TabIndex = 9;
            this.playListName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 521);
            this.Controls.Add(this.playListName);
            this.Controls.Add(this.removePlayListButton);
            this.Controls.Add(this.addPlayList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.toFavorite);
            this.Controls.Add(this.favorites);
            this.Controls.Add(this.playLists);
            this.Controls.Add(this.playlist);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListBox playlist;
        private System.Windows.Forms.ListBox playLists;
        private System.Windows.Forms.Button favorites;
        private System.Windows.Forms.Button toFavorite;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addPlayList;
        private System.Windows.Forms.Button removePlayListButton;
        private System.Windows.Forms.TextBox playListName;
    }
}

