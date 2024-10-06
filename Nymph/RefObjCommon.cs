using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPrinc3_DB_Editor
{
    public class RefObjCommon
    {
        public int Service { get; set; }
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string ObjName128 { get; set; }
        public string OrgObjCodeName128 { get; set; }
        public string NameStrID128 { get; set; }
        public string DescStrID128 { get; set; }
        public byte CashItem { get; set; }
        public byte Bionic { get; set; }
        public byte TypeID1 { get; set; }
        public byte TypeID2 { get; set; }
        public byte TypeID3 { get; set; }
        public byte TypeID4 { get; set; }
        public int DecayTime { get; set; }
        public byte Country { get; set; }
        public byte Rarity { get; set; }
        public byte CanTrade { get; set; }
        public byte CanSell { get; set; }
        public byte CanBuy { get; set; }
        public byte CanBorrow { get; set; }
        public byte CanDrop { get; set; }
        public byte CanPick { get; set; }
        public byte CanRepair { get; set; }
        public byte CanRevive { get; set; }
        public byte CanUse { get; set; }
        public byte CanThrow { get; set; }
        public int Price { get; set; }
        public int CostRepair { get; set; }
        public int CostRevive { get; set; }
        public int CostBorrow { get; set; }
        public int KeepingFee { get; set; }
        public int SellPrice { get; set; }
        public int ReqLevelType1 { get; set; }
        public byte ReqLevel1 { get; set; }
        public int ReqLevelType2 { get; set; }
        public byte ReqLevel2 { get; set; }
        public int ReqLevelType3 { get; set; }
        public byte ReqLevel3 { get; set; }
        public int ReqLevelType4 { get; set; }
        public byte ReqLevel4 { get; set; }
        public int MaxContain { get; set; }
        public short RegionID { get; set; }
        public short Dir { get; set; }
        public short OffsetX { get; set; }
        public short OffsetY { get; set; }
        public short OffsetZ { get; set; }
        public short Speed1 { get; set; }
        public short Speed2 { get; set; }
        public int Scale { get; set; }
        public short BCHeight { get; set; }
        public short BCRadius { get; set; }
        public int EventID { get; set; }
        public string AssocFileObj128 { get; set; }
        public string AssocFileDrop128 { get; set; }
        public string AssocFileIcon128 { get; set; }
        public string AssocFile1_128 { get; set; }
        public string AssocFile2_128 { get; set; }
        public int Link { get; set; }


        public static void Prepare_RefObjCommon()
        {
            // SelectedOwnPath boş mu kontrol et
            if (string.IsNullOrEmpty(ConfigHelper.SelectedOwnPath))
            {
                MessageBox.Show("Klasör yolu boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gerekli dizin yollarını tanımla
            string serverDepPath = Path.Combine(ConfigHelper.SelectedOwnPath, "server_dep", "silkroad", "textdata");

            // Eğer dizin yoksa oluştur
            if (!Directory.Exists(serverDepPath))
            {
                Directory.CreateDirectory(serverDepPath);
                MessageBox.Show($"Gerekli dizin oluşturuldu: {serverDepPath}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string connectionString = ConfigHelper.SelectedSQLPath; //  SQL bağlantı dizesi

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL sorgusu
                string query = "SELECT * FROM [SRO_VT_SHARD].[dbo].[_RefObjCommon]";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int fileIndex = 1;
                    int recordCount = 0;

                    // Dosya oluşturma
                    StreamWriter writer = CreateStreamWriter(serverDepPath, fileIndex);

                    while (reader.Read())
                    {
                        // Satırdaki her bir değeri yaz
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write(reader[i]);
                            if (i < reader.FieldCount - 1)
                            {
                                writer.Write("\t"); // Tab ile ayır
                            }
                        }
                        writer.WriteLine(); // Her kayıttan sonra yeni satır

                        recordCount++;

                        // Her 5000 kayıt için yeni dosya oluştur
                        if (recordCount % 5000 == 0)
                        {
                            writer.Close();
                            fileIndex++;
                            writer = CreateStreamWriter(serverDepPath, fileIndex);
                        }
                    }
                    writer.Close();
                }
            }
        }
        private static StreamWriter CreateStreamWriter(string path, int fileIndex)
        {
            string fileName = $"itemdata_{fileIndex * 5000}.txt"; // Dosya adı
            string fullPath = Path.Combine(path, fileName); // Tam yol
            return new StreamWriter(fullPath); // Yeni StreamWriter döndür
        }
    }

}
