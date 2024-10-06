using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPrinc3_DB_Editor
{
    public class ConfigHelper
    {
        public static string SelectedFolderPath { get; private set; }
        public static string SelectedSQLPath { get; private set; }
        public static string SelectedOwnPath { get; private set; }

        public static (string Server, string UserId, string Password) ParseConnectionString(string connectionString)
        {
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
            string server = builder.DataSource; // Server bilgisi
            string userId = builder.UserID; // User Id bilgisi
            string password = builder.Password; // Password bilgisi

            return (server, userId, password);
        }

        // Program başlatıldığında bu metot çağrılır
        public static void LoadConfig()
        {
            SelectedFolderPath = ConfigurationManager.AppSettings["SelectedFolderPath"];
            SelectedOwnPath = ConfigurationManager.AppSettings["SelectedOwnPath"];
            SelectedSQLPath = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public static void CopyIcon(string iconName)
        {
            if (string.IsNullOrEmpty(SelectedOwnPath))
            {
                MessageBox.Show("Kendi klasör yolunuz boş olamaz. Ayarlara göz atın.");
                return;
            }

            // Kopyalama yapılacak klasör yolu
            string iconFolderPath = Path.Combine(SelectedOwnPath, "icon");

            // Eğer icon klasörü yoksa oluştur
            if (!Directory.Exists(iconFolderPath))
            {
                Directory.CreateDirectory(iconFolderPath);
                MessageBox.Show("Icon klasörü oluşturuldu: " + iconFolderPath);
            }

            // Belirtilen icon adını bul
            string sourceIconFolderPath = Path.Combine(SelectedFolderPath, @"icon");

            if (!Directory.Exists(sourceIconFolderPath))
            {
                MessageBox.Show("Belirtilen kaynak icon klasörü bulunamadı.");
                return;
            }

            // İcon dosyasını bul
            string[] iconFiles = Directory.GetFiles(sourceIconFolderPath, $"{iconName}.*", SearchOption.AllDirectories);

            if (iconFiles.Length == 0)
            {
                MessageBox.Show($"'{iconName}' ile eşleşen bir dosya bulunamadı.");
                return;
            }

            // İlk bulunan dosyayı kopyala
            string sourceFilePath = iconFiles[0];
            string destinationFilePath = Path.Combine(iconFolderPath, Path.GetFileName(sourceFilePath));

            // Dosya var mı kontrolü
            if (File.Exists(destinationFilePath))
            {
                MessageBox.Show($"'{iconName}' dosyası zaten mevcut: {destinationFilePath}");
                return; // Dosya zaten varsa işlemi sonlandır
            }

            try
            {
                File.Copy(sourceFilePath, destinationFilePath); // Eğer dosya yoksa kopyala
                MessageBox.Show($"'{iconName}' başarıyla '{iconFolderPath}' dizinine kopyalandı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya kopyalanırken hata oluştu: {ex.Message}");
            }
        }


        public static void SaveFolderPathToConfig(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SelectedFolderPath"].Value = path;
            config.Save(ConfigurationSaveMode.Modified);

            // Ayarları yeniden yükle
            ConfigurationManager.RefreshSection("appSettings");
            SelectedFolderPath = path;
        }
        public static void SaveFolderOwnToConfig(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SelectedOwnPath"].Value = path;
            config.Save(ConfigurationSaveMode.Modified);

            // Ayarları yeniden yükle
            ConfigurationManager.RefreshSection("appSettings");
            SelectedOwnPath = path;
        }
        public static void SaveSQLToConfig(string ServerName,string ID,string PW)
        {
            string connectionString = $"Server={ServerName};Database=SRO_VT_SHARD;User Id={ID};Password={PW};";

            // App.config dosyasını aç ve güncelle
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Eğer DbConnection var ise, onu güncelle, yoksa yeni bir tane ekle
            if (config.ConnectionStrings.ConnectionStrings["DbConnection"] != null)
            {
                config.ConnectionStrings.ConnectionStrings["DbConnection"].ConnectionString = connectionString;
            }
            else
            {
                ConnectionStringSettings connectionStringSettings = new ConnectionStringSettings
                {
                    Name = "DbConnection",
                    ConnectionString = connectionString,
                    ProviderName = "System.Data.SqlClient"
                };
                config.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);
            }

            // App.config dosyasını kaydet ve güncellemeleri uygulamaya yansıt
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
