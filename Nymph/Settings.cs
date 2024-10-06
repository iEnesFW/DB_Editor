using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPrinc3_DB_Editor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        Configuration config;
        private void button2_Click(object sender, EventArgs e)
        {
            ConfigHelper.SaveSQLToConfig(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        folderDialog.Description = "Bir klasör seçin";
        folderDialog.ShowNewFolderButton = true;

        DialogResult result = folderDialog.ShowDialog();

        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
        {
                // Seçilen klasör yolu
            string selectedFolderPath = folderDialog.SelectedPath;

                // Seçilen klasör yolunu App.config dosyasına kaydet
                ConfigHelper.SaveFolderPathToConfig(selectedFolderPath);

            MessageBox.Show("Seçilen Klasör: " + selectedFolderPath);
        }
    }

        private void Settings_Load(object sender, EventArgs e)
        {
            label5.Text = "Dosya Yolu : " + ConfigHelper.SelectedFolderPath;
            label1.Text = "Dosya Yolu : " + ConfigHelper.SelectedOwnPath;

            var (server, userId, password) = ConfigHelper.ParseConnectionString(ConfigHelper.SelectedSQLPath);
            textBox1.Text = server; // Server name
            textBox2.Text = userId; // User Id
            textBox3.Text = password; // Password
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.Description = "Bir klasör seçin";
            folderDialog.ShowNewFolderButton = true;

            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                // Seçilen klasör yolu
                string selectedFolderPath = folderDialog.SelectedPath;

                // Seçilen klasör yolunu App.config dosyasına kaydet
                ConfigHelper.SaveFolderOwnToConfig(selectedFolderPath);

                MessageBox.Show("Seçilen Klasör: " + selectedFolderPath);
            }
        }
    }
}
