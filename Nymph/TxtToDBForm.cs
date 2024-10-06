using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace DarkPrinc3_DB_Editor
{
    public partial class TxtToDBForm : Form
    {
        public TxtToDBForm()
        {
            InitializeComponent();
        }
        string[] fileLines;
        bool isIdentity = false;
        List<RefObjCommon> refObjList = new List<RefObjCommon>();
        List<RefObjItem> refObjItemList = new List<RefObjItem>();


        private void RefObjCommonInsert(RefObjCommon refObjCommonItem)
        {
            // SQL bağlantısı için connection string
            string connectionString = ConfigHelper.SelectedSQLPath;
            string identityCheckQuery = "SELECT COLUMNPROPERTY(OBJECT_ID('_RefObjCommon'), 'ID', 'IsIdentity') AS IsIdentity";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand identityCheckCommand = new SqlCommand(identityCheckQuery, connection))
                {
                    isIdentity = Convert.ToBoolean(identityCheckCommand.ExecuteScalar());
                }

                string query;
                // Veritabanına INSERT komutu
                if (!isIdentity)
                {
                    query = @"
            INSERT INTO _RefObjCommon
            (
                Service, ID, CodeName128, ObjName128, OrgObjCodeName128, NameStrID128, DescStrID128, 
                CashItem, Bionic, TypeID1, TypeID2, TypeID3, TypeID4, DecayTime, Country, 
                Rarity, CanTrade, CanSell, CanBuy, CanBorrow, CanDrop, CanPick, CanRepair, 
                CanRevive, CanUse, CanThrow, Price, CostRepair, CostRevive, CostBorrow, KeepingFee, 
                SellPrice, ReqLevelType1, ReqLevel1, ReqLevelType2, ReqLevel2, ReqLevelType3, ReqLevel3, 
                ReqLevelType4, ReqLevel4, MaxContain, RegionID, Dir, OffsetX, OffsetY, OffsetZ, 
                Speed1, Speed2, Scale, BCHeight, BCRadius, EventID, AssocFileObj128, AssocFileDrop128, 
                AssocFileIcon128, AssocFile1_128, AssocFile2_128, Link
            ) 
            VALUES
            (
                @Service, @ID, @CodeName128, @ObjName128, @OrgObjCodeName128, @NameStrID128, @DescStrID128, 
                @CashItem, @Bionic, @TypeID1, @TypeID2, @TypeID3, @TypeID4, @DecayTime, @Country, 
                @Rarity, @CanTrade, @CanSell, @CanBuy, @CanBorrow, @CanDrop, @CanPick, @CanRepair, 
                @CanRevive, @CanUse, @CanThrow, @Price, @CostRepair, @CostRevive, @CostBorrow, @KeepingFee, 
                @SellPrice, @ReqLevelType1, @ReqLevel1, @ReqLevelType2, @ReqLevel2, @ReqLevelType3, @ReqLevel3, 
                @ReqLevelType4, @ReqLevel4, @MaxContain, @RegionID, @Dir, @OffsetX, @OffsetY, @OffsetZ, 
                @Speed1, @Speed2, @Scale, @BCHeight, @BCRadius, @EventID, @AssocFileObj128, @AssocFileDrop128, 
                @AssocFileIcon128, @AssocFile1_128, @AssocFile2_128, @Link
            );";
                }
                else
                {
                    query = @"
            INSERT INTO _RefObjCommon
            (
                Service, CodeName128, ObjName128, OrgObjCodeName128, NameStrID128, DescStrID128, 
                CashItem, Bionic, TypeID1, TypeID2, TypeID3, TypeID4, DecayTime, Country, 
                Rarity, CanTrade, CanSell, CanBuy, CanBorrow, CanDrop, CanPick, CanRepair, 
                CanRevive, CanUse, CanThrow, Price, CostRepair, CostRevive, CostBorrow, KeepingFee, 
                SellPrice, ReqLevelType1, ReqLevel1, ReqLevelType2, ReqLevel2, ReqLevelType3, ReqLevel3, 
                ReqLevelType4, ReqLevel4, MaxContain, RegionID, Dir, OffsetX, OffsetY, OffsetZ, 
                Speed1, Speed2, Scale, BCHeight, BCRadius, EventID, AssocFileObj128, AssocFileDrop128, 
                AssocFileIcon128, AssocFile1_128, AssocFile2_128, Link
            ) 
            VALUES
            (
                @Service, @CodeName128, @ObjName128, @OrgObjCodeName128, @NameStrID128, @DescStrID128, 
                @CashItem, @Bionic, @TypeID1, @TypeID2, @TypeID3, @TypeID4, @DecayTime, @Country, 
                @Rarity, @CanTrade, @CanSell, @CanBuy, @CanBorrow, @CanDrop, @CanPick, @CanRepair, 
                @CanRevive, @CanUse, @CanThrow, @Price, @CostRepair, @CostRevive, @CostBorrow, @KeepingFee, 
                @SellPrice, @ReqLevelType1, @ReqLevel1, @ReqLevelType2, @ReqLevel2, @ReqLevelType3, @ReqLevel3, 
                @ReqLevelType4, @ReqLevel4, @MaxContain, @RegionID, @Dir, @OffsetX, @OffsetY, @OffsetZ, 
                @Speed1, @Speed2, @Scale, @BCHeight, @BCRadius, @EventID, @AssocFileObj128, @AssocFileDrop128, 
                @AssocFileIcon128, @AssocFile1_128, @AssocFile2_128, @Link
            );";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Verileri refObjCommonItem'dan alarak parametrelere ekliyoruz
                    command.Parameters.AddWithValue("@Service", refObjCommonItem.Service);
                    if (!isIdentity) command.Parameters.AddWithValue("@ID", refObjCommonItem.ID);
                    command.Parameters.AddWithValue("@CodeName128", refObjCommonItem.CodeName128);
                    command.Parameters.AddWithValue("@ObjName128", refObjCommonItem.ObjName128);
                    command.Parameters.AddWithValue("@OrgObjCodeName128", refObjCommonItem.OrgObjCodeName128);
                    command.Parameters.AddWithValue("@NameStrID128", refObjCommonItem.NameStrID128);
                    command.Parameters.AddWithValue("@DescStrID128", refObjCommonItem.DescStrID128);
                    command.Parameters.AddWithValue("@CashItem", refObjCommonItem.CashItem);
                    command.Parameters.AddWithValue("@Bionic", refObjCommonItem.Bionic);
                    command.Parameters.AddWithValue("@TypeID1", refObjCommonItem.TypeID1);
                    command.Parameters.AddWithValue("@TypeID2", refObjCommonItem.TypeID2);
                    command.Parameters.AddWithValue("@TypeID3", refObjCommonItem.TypeID3);
                    command.Parameters.AddWithValue("@TypeID4", refObjCommonItem.TypeID4);
                    command.Parameters.AddWithValue("@DecayTime", refObjCommonItem.DecayTime);
                    command.Parameters.AddWithValue("@Country", refObjCommonItem.Country);
                    command.Parameters.AddWithValue("@Rarity", refObjCommonItem.Rarity);
                    command.Parameters.AddWithValue("@CanTrade", refObjCommonItem.CanTrade);
                    command.Parameters.AddWithValue("@CanSell", refObjCommonItem.CanSell);
                    command.Parameters.AddWithValue("@CanBuy", refObjCommonItem.CanBuy);
                    command.Parameters.AddWithValue("@CanBorrow", refObjCommonItem.CanBorrow);
                    command.Parameters.AddWithValue("@CanDrop", refObjCommonItem.CanDrop);
                    command.Parameters.AddWithValue("@CanPick", refObjCommonItem.CanPick);
                    command.Parameters.AddWithValue("@CanRepair", refObjCommonItem.CanRepair);
                    command.Parameters.AddWithValue("@CanRevive", refObjCommonItem.CanRevive);
                    command.Parameters.AddWithValue("@CanUse", refObjCommonItem.CanUse);
                    command.Parameters.AddWithValue("@CanThrow", refObjCommonItem.CanThrow);
                    command.Parameters.AddWithValue("@Price", refObjCommonItem.Price);
                    command.Parameters.AddWithValue("@CostRepair", refObjCommonItem.CostRepair);
                    command.Parameters.AddWithValue("@CostRevive", refObjCommonItem.CostRevive);
                    command.Parameters.AddWithValue("@CostBorrow", refObjCommonItem.CostBorrow);
                    command.Parameters.AddWithValue("@KeepingFee", refObjCommonItem.KeepingFee);
                    command.Parameters.AddWithValue("@SellPrice", refObjCommonItem.SellPrice);
                    command.Parameters.AddWithValue("@ReqLevelType1", refObjCommonItem.ReqLevelType1);
                    command.Parameters.AddWithValue("@ReqLevel1", refObjCommonItem.ReqLevel1);
                    command.Parameters.AddWithValue("@ReqLevelType2", refObjCommonItem.ReqLevelType2);
                    command.Parameters.AddWithValue("@ReqLevel2", refObjCommonItem.ReqLevel2);
                    command.Parameters.AddWithValue("@ReqLevelType3", refObjCommonItem.ReqLevelType3);
                    command.Parameters.AddWithValue("@ReqLevel3", refObjCommonItem.ReqLevel3);
                    command.Parameters.AddWithValue("@ReqLevelType4", refObjCommonItem.ReqLevelType4);
                    command.Parameters.AddWithValue("@ReqLevel4", refObjCommonItem.ReqLevel4);
                    command.Parameters.AddWithValue("@MaxContain", refObjCommonItem.MaxContain);
                    command.Parameters.AddWithValue("@RegionID", refObjCommonItem.RegionID);
                    command.Parameters.AddWithValue("@Dir", refObjCommonItem.Dir);
                    command.Parameters.AddWithValue("@OffsetX", refObjCommonItem.OffsetX);
                    command.Parameters.AddWithValue("@OffsetY", refObjCommonItem.OffsetY);
                    command.Parameters.AddWithValue("@OffsetZ", refObjCommonItem.OffsetZ);
                    command.Parameters.AddWithValue("@Speed1", refObjCommonItem.Speed1);
                    command.Parameters.AddWithValue("@Speed2", refObjCommonItem.Speed2);
                    command.Parameters.AddWithValue("@Scale", refObjCommonItem.Scale);
                    command.Parameters.AddWithValue("@BCHeight", refObjCommonItem.BCHeight);
                    command.Parameters.AddWithValue("@BCRadius", refObjCommonItem.BCRadius);
                    command.Parameters.AddWithValue("@EventID", refObjCommonItem.EventID);
                    command.Parameters.AddWithValue("@AssocFileObj128", refObjCommonItem.AssocFileObj128);
                    command.Parameters.AddWithValue("@AssocFileDrop128", refObjCommonItem.AssocFileDrop128);
                    command.Parameters.AddWithValue("@AssocFileIcon128", refObjCommonItem.AssocFileIcon128);
                    command.Parameters.AddWithValue("@AssocFile1_128", refObjCommonItem.AssocFile1_128);
                    command.Parameters.AddWithValue("@AssocFile2_128", refObjCommonItem.AssocFile2_128);
                    command.Parameters.AddWithValue("@Link", refObjCommonItem.Link);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Dosyadaki veriler başarıyla eklendi.");
        }
        private int RefObjItemInsert(RefObjItem refObjItem)
        {
            // SQL bağlantısı için connection string
            string connectionString = ConfigHelper.SelectedSQLPath;

            string query = @"
            INSERT INTO _RefObjItem
            (
                MaxStack, ReqGender, ReqStr, ReqInt, ItemClass, SetID, Dur_L, Dur_U, PD_L, PD_U, PDInc, ER_L, ER_U, ERInc, PAR_L, PAR_U, PARInc, 
                BR_L, BR_U, MD_L, MD_U, MDInc, MAR_L, MAR_U, MARInc, PDStr_L, PDStr_U, MDInt_L, MDInt_U, Quivered, Ammo1_TID4, Ammo2_TID4, 
                Ammo3_TID4, Ammo4_TID4, Ammo5_TID4, SpeedClass, TwoHanded, Range, PAttackMin_L, PAttackMin_U, PAttackMax_L, PAttackMax_U, 
                PAttackInc, MAttackMin_L, MAttackMin_U, MAttackMax_L, MAttackMax_U, MAttackInc, PAStrMin_L, PAStrMin_U, PAStrMax_L, PAStrMax_U, 
                MAInt_Min_L, MAInt_Min_U, MAInt_Max_L, MAInt_Max_U, HR_L, HR_U, HRInc, CHR_L, CHR_U, Param1, Desc1_128, Param2, Desc2_128, 
                Param3, Desc3_128, Param4, Desc4_128, Param5, Desc5_128, Param6, Desc6_128, Param7, Desc7_128, Param8, Desc8_128, 
                Param9, Desc9_128, Param10, Desc10_128, Param11, Desc11_128, Param12, Desc12_128, Param13, Desc13_128, Param14, Desc14_128, 
                Param15, Desc15_128, Param16, Desc16_128, Param17, Desc17_128, Param18, Desc18_128, Param19, Desc19_128, Param20, Desc20_128, 
                MaxMagicOptCount, ChildItemCount, Link
            ) 
            VALUES
            (
                @MaxStack, @ReqGender, @ReqStr, @ReqInt, @ItemClass, @SetID, @Dur_L, @Dur_U, @PD_L, @PD_U, @PDInc, @ER_L, @ER_U, @ERInc, 
                @PAR_L, @PAR_U, @PARInc, @BR_L, @BR_U, @MD_L, @MD_U, @MDInc, @MAR_L, @MAR_U, @MARInc, @PDStr_L, @PDStr_U, @MDInt_L, 
                @MDInt_U, @Quivered, @Ammo1_TID4, @Ammo2_TID4, @Ammo3_TID4, @Ammo4_TID4, @Ammo5_TID4, @SpeedClass, @TwoHanded, @Range, 
                @PAttackMin_L, @PAttackMin_U, @PAttackMax_L, @PAttackMax_U, @PAttackInc, @MAttackMin_L, @MAttackMin_U, @MAttackMax_L, 
                @MAttackMax_U, @MAttackInc, @PAStrMin_L, @PAStrMin_U, @PAStrMax_L, @PAStrMax_U, @MAInt_Min_L, @MAInt_Min_U, @MAInt_Max_L, 
                @MAInt_Max_U, @HR_L, @HR_U, @HRInc, @CHR_L, @CHR_U, @Param1, @Desc1_128, @Param2, @Desc2_128, @Param3, @Desc3_128, 
                @Param4, @Desc4_128, @Param5, @Desc5_128, @Param6, @Desc6_128, @Param7, @Desc7_128, @Param8, @Desc8_128, @Param9, 
                @Desc9_128, @Param10, @Desc10_128, @Param11, @Desc11_128, @Param12, @Desc12_128, @Param13, @Desc13_128, @Param14, 
                @Desc14_128, @Param15, @Desc15_128, @Param16, @Desc16_128, @Param17, @Desc17_128, @Param18, @Desc18_128, @Param19, 
                @Desc19_128, @Param20, @Desc20_128, @MaxMagicOptCount, @ChildItemCount, @Link
            ); 
            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Her bir RefObjItem nesnesindeki değerleri parametrelere ekliyoruz
                        command.Parameters.AddWithValue("@MaxStack", refObjItem.MaxStack);
                        command.Parameters.AddWithValue("@ReqGender", refObjItem.ReqGender);
                        command.Parameters.AddWithValue("@ReqStr", refObjItem.ReqStr);
                        command.Parameters.AddWithValue("@ReqInt", refObjItem.ReqInt);
                        command.Parameters.AddWithValue("@ItemClass", refObjItem.ItemClass);
                        command.Parameters.AddWithValue("@SetID", refObjItem.SetID);
                        command.Parameters.AddWithValue("@Dur_L", refObjItem.Dur_L);
                        command.Parameters.AddWithValue("@Dur_U", refObjItem.Dur_U);
                        command.Parameters.AddWithValue("@PD_L", refObjItem.PD_L);
                        command.Parameters.AddWithValue("@PD_U", refObjItem.PD_U);
                        command.Parameters.AddWithValue("@PDInc", refObjItem.PDInc);
                        command.Parameters.AddWithValue("@ER_L", refObjItem.ER_L);
                        command.Parameters.AddWithValue("@ER_U", refObjItem.ER_U);
                        command.Parameters.AddWithValue("@ERInc", refObjItem.ERInc);
                        command.Parameters.AddWithValue("@PAR_L", refObjItem.PAR_L);
                        command.Parameters.AddWithValue("@PAR_U", refObjItem.PAR_U);
                        command.Parameters.AddWithValue("@PARInc", refObjItem.PARInc);
                        command.Parameters.AddWithValue("@BR_L", refObjItem.BR_L);
                        command.Parameters.AddWithValue("@BR_U", refObjItem.BR_U);
                        command.Parameters.AddWithValue("@MD_L", refObjItem.MD_L);
                        command.Parameters.AddWithValue("@MD_U", refObjItem.MD_U);
                        command.Parameters.AddWithValue("@MDInc", refObjItem.MDInc);
                        command.Parameters.AddWithValue("@MAR_L", refObjItem.MAR_L);
                        command.Parameters.AddWithValue("@MAR_U", refObjItem.MAR_U);
                        command.Parameters.AddWithValue("@MARInc", refObjItem.MARInc);
                        command.Parameters.AddWithValue("@PDStr_L", refObjItem.PDStr_L);
                        command.Parameters.AddWithValue("@PDStr_U", refObjItem.PDStr_U);
                        command.Parameters.AddWithValue("@MDInt_L", refObjItem.MDInt_L);
                        command.Parameters.AddWithValue("@MDInt_U", refObjItem.MDInt_U);
                        command.Parameters.AddWithValue("@Quivered", refObjItem.Quivered);
                        command.Parameters.AddWithValue("@Ammo1_TID4", refObjItem.Ammo1_TID4);
                        command.Parameters.AddWithValue("@Ammo2_TID4", refObjItem.Ammo2_TID4);
                        command.Parameters.AddWithValue("@Ammo3_TID4", refObjItem.Ammo3_TID4);
                        command.Parameters.AddWithValue("@Ammo4_TID4", refObjItem.Ammo4_TID4);
                        command.Parameters.AddWithValue("@Ammo5_TID4", refObjItem.Ammo5_TID4);
                        command.Parameters.AddWithValue("@SpeedClass", refObjItem.SpeedClass);
                        command.Parameters.AddWithValue("@TwoHanded", refObjItem.TwoHanded);
                        command.Parameters.AddWithValue("@Range", refObjItem.Range);
                        command.Parameters.AddWithValue("@PAttackMin_L", refObjItem.PAttackMin_L);
                        command.Parameters.AddWithValue("@PAttackMin_U", refObjItem.PAttackMin_U);
                        command.Parameters.AddWithValue("@PAttackMax_L", refObjItem.PAttackMax_L);
                        command.Parameters.AddWithValue("@PAttackMax_U", refObjItem.PAttackMax_U);
                        command.Parameters.AddWithValue("@PAttackInc", refObjItem.PAttackInc);
                        command.Parameters.AddWithValue("@MAttackMin_L", refObjItem.MAttackMin_L);
                        command.Parameters.AddWithValue("@MAttackMin_U", refObjItem.MAttackMin_U);
                        command.Parameters.AddWithValue("@MAttackMax_L", refObjItem.MAttackMax_L);
                        command.Parameters.AddWithValue("@MAttackMax_U", refObjItem.MAttackMax_U);
                        command.Parameters.AddWithValue("@MAttackInc", refObjItem.MAttackInc);
                        command.Parameters.AddWithValue("@PAStrMin_L", refObjItem.PAStrMin_L);
                        command.Parameters.AddWithValue("@PAStrMin_U", refObjItem.PAStrMin_U);
                        command.Parameters.AddWithValue("@PAStrMax_L", refObjItem.PAStrMax_L);
                        command.Parameters.AddWithValue("@PAStrMax_U", refObjItem.PAStrMax_U);
                        command.Parameters.AddWithValue("@MAInt_Min_L", refObjItem.MAInt_Min_L);
                        command.Parameters.AddWithValue("@MAInt_Min_U", refObjItem.MAInt_Min_U);
                        command.Parameters.AddWithValue("@MAInt_Max_L", refObjItem.MAInt_Max_L);
                        command.Parameters.AddWithValue("@MAInt_Max_U", refObjItem.MAInt_Max_U);
                        command.Parameters.AddWithValue("@HR_L", refObjItem.HR_L);
                        command.Parameters.AddWithValue("@HR_U", refObjItem.HR_U);
                        command.Parameters.AddWithValue("@HRInc", refObjItem.HRInc);
                        command.Parameters.AddWithValue("@CHR_L", refObjItem.CHR_L);
                        command.Parameters.AddWithValue("@CHR_U", refObjItem.CHR_U);
                        command.Parameters.AddWithValue("@Param1", refObjItem.Param1);
                        command.Parameters.AddWithValue("@Desc1_128", refObjItem.Desc1_128);
                        command.Parameters.AddWithValue("@Param2", refObjItem.Param2);
                        command.Parameters.AddWithValue("@Desc2_128", refObjItem.Desc2_128);
                        command.Parameters.AddWithValue("@Param3", refObjItem.Param3);
                        command.Parameters.AddWithValue("@Desc3_128", refObjItem.Desc3_128);
                        command.Parameters.AddWithValue("@Param4", refObjItem.Param4);
                        command.Parameters.AddWithValue("@Desc4_128", refObjItem.Desc4_128);
                        command.Parameters.AddWithValue("@Param5", refObjItem.Param5);
                        command.Parameters.AddWithValue("@Desc5_128", refObjItem.Desc5_128);
                        command.Parameters.AddWithValue("@Param6", refObjItem.Param6);
                        command.Parameters.AddWithValue("@Desc6_128", refObjItem.Desc6_128);
                        command.Parameters.AddWithValue("@Param7", refObjItem.Param7);
                        command.Parameters.AddWithValue("@Desc7_128", refObjItem.Desc7_128);
                        command.Parameters.AddWithValue("@Param8", refObjItem.Param8);
                        command.Parameters.AddWithValue("@Desc8_128", refObjItem.Desc8_128);
                        command.Parameters.AddWithValue("@Param9", refObjItem.Param9);
                        command.Parameters.AddWithValue("@Desc9_128", refObjItem.Desc9_128);
                        command.Parameters.AddWithValue("@Param10", refObjItem.Param10);
                        command.Parameters.AddWithValue("@Desc10_128", refObjItem.Desc10_128);
                        command.Parameters.AddWithValue("@Param11", refObjItem.Param11);
                        command.Parameters.AddWithValue("@Desc11_128", refObjItem.Desc11_128);
                        command.Parameters.AddWithValue("@Param12", refObjItem.Param12);
                        command.Parameters.AddWithValue("@Desc12_128", refObjItem.Desc12_128);
                        command.Parameters.AddWithValue("@Param13", refObjItem.Param13);
                        command.Parameters.AddWithValue("@Desc13_128", refObjItem.Desc13_128);
                        command.Parameters.AddWithValue("@Param14", refObjItem.Param14);
                        command.Parameters.AddWithValue("@Desc14_128", refObjItem.Desc14_128);
                        command.Parameters.AddWithValue("@Param15", refObjItem.Param15);
                        command.Parameters.AddWithValue("@Desc15_128", refObjItem.Desc15_128);
                        command.Parameters.AddWithValue("@Param16", refObjItem.Param16);
                        command.Parameters.AddWithValue("@Desc16_128", refObjItem.Desc16_128);
                        command.Parameters.AddWithValue("@Param17", refObjItem.Param17);
                        command.Parameters.AddWithValue("@Desc17_128", refObjItem.Desc17_128);
                        command.Parameters.AddWithValue("@Param18", refObjItem.Param18);
                        command.Parameters.AddWithValue("@Desc18_128", refObjItem.Desc18_128);
                        command.Parameters.AddWithValue("@Param19", refObjItem.Param19);
                        command.Parameters.AddWithValue("@Desc19_128", refObjItem.Desc19_128);
                        command.Parameters.AddWithValue("@Param20", refObjItem.Param20);
                        command.Parameters.AddWithValue("@Desc20_128", refObjItem.Desc20_128);
                        command.Parameters.AddWithValue("@MaxMagicOptCount", refObjItem.MaxMagicOptCount);
                        command.Parameters.AddWithValue("@ChildItemCount", refObjItem.ChildItemCount);
                        command.Parameters.AddWithValue("@Link", refObjItem.Link);


                    return Convert.ToInt32(command.ExecuteScalar());

                }
            }
        }

        private void InsertToDB_Click(object sender, EventArgs e)
        {
            refObjItemList.Clear();
            refObjList.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Satırda herhangi bir hücre varsa ve ilk hücredeki değeri kontrol et
                if (row.Cells[0].Value is bool isChecked && isChecked)
                {
                    // Eğer CheckBox işaretliyse, satırdaki diğer verileri al
                    string[] columns = new string[dataGridView1.Columns.Count];

                    for (int i = 0; i < dataGridView1.Columns.Count-1; i++)
                    {
                        columns[i] = row.Cells[i+1].Value?.ToString() ?? string.Empty; // Değer varsa al, yoksa boş string
                    }

                    RefObjCommon refObj = new RefObjCommon
                    {
                        Service = int.Parse(columns[0]),
                        ID = int.Parse(columns[1]),
                        CodeName128 = columns[2],
                        ObjName128 = columns[3],
                        OrgObjCodeName128 = columns[4],
                        NameStrID128 = columns[5],
                        DescStrID128 = columns[6],
                        CashItem = byte.Parse(columns[7]),
                        Bionic = byte.Parse(columns[8]),
                        TypeID1 = byte.Parse(columns[9]),
                        TypeID2 = byte.Parse(columns[10]),
                        TypeID3 = byte.Parse(columns[11]),
                        TypeID4 = byte.Parse(columns[12]),
                        DecayTime = int.Parse(columns[13]),
                        Country = byte.Parse(columns[14]),
                        Rarity = byte.Parse(columns[15]),
                        CanTrade = byte.Parse(columns[16]),
                        CanSell = byte.Parse(columns[17]),
                        CanBuy = byte.Parse(columns[18]),
                        CanBorrow = byte.Parse(columns[19]),
                        CanDrop = byte.Parse(columns[20]),
                        CanPick = byte.Parse(columns[21]),
                        CanRepair = byte.Parse(columns[22]),
                        CanRevive = byte.Parse(columns[23]),
                        CanUse = byte.Parse(columns[24]),
                        CanThrow = byte.Parse(columns[25]),
                        Price = int.Parse(columns[26]),
                        CostRepair = int.Parse(columns[27]),
                        CostRevive = int.Parse(columns[28]),
                        CostBorrow = int.Parse(columns[29]),
                        KeepingFee = int.Parse(columns[30]),
                        SellPrice = int.Parse(columns[31]),
                        ReqLevelType1 = int.Parse(columns[32]),
                        ReqLevel1 = byte.Parse(columns[33]),
                        ReqLevelType2 = int.Parse(columns[34]),
                        ReqLevel2 = byte.Parse(columns[35]),
                        ReqLevelType3 = int.Parse(columns[36]),
                        ReqLevel3 = byte.Parse(columns[37]),
                        ReqLevelType4 = int.Parse(columns[38]),
                        ReqLevel4 = byte.Parse(columns[39]),
                        MaxContain = int.Parse(columns[40]),
                        RegionID = short.Parse(columns[41]),
                        Dir = short.Parse(columns[42]),
                        OffsetX = short.Parse(columns[43]),
                        OffsetY = short.Parse(columns[44]),
                        OffsetZ = short.Parse(columns[45]),
                        Speed1 = short.Parse(columns[46]),
                        Speed2 = short.Parse(columns[47]),
                        Scale = int.Parse(columns[48]),
                        BCHeight = short.Parse(columns[49]),
                        BCRadius = short.Parse(columns[50]),
                        EventID = int.Parse(columns[51]),
                        AssocFileObj128 = columns[52],
                        AssocFileDrop128 = columns[53],
                        AssocFileIcon128 = columns[54],
                        AssocFile1_128 = columns[55],
                        AssocFile2_128 = columns[56],
                        Link = 0
                    };
                    RefObjItem refObjItem = new RefObjItem
                    {
                        MaxStack = int.Parse(columns[57]),
                        ReqGender = byte.Parse(columns[58]),
                        ReqStr = int.Parse(columns[59]),
                        ReqInt = int.Parse(columns[60]),
                        ItemClass = byte.Parse(columns[61]),
                        SetID = int.Parse(columns[62]),
                        Dur_L = float.Parse(columns[63]),
                        Dur_U = float.Parse(columns[64]),
                        PD_L = float.Parse(columns[65]),
                        PD_U = float.Parse(columns[66]),
                        PDInc = float.Parse(columns[67]),
                        ER_L = float.Parse(columns[68]),
                        ER_U = float.Parse(columns[69]),
                        ERInc = float.Parse(columns[70]),
                        PAR_L = float.Parse(columns[71]),
                        PAR_U = float.Parse(columns[72]),
                        PARInc = float.Parse(columns[73]),
                        BR_L = float.Parse(columns[74]),
                        BR_U = float.Parse(columns[75]),
                        MD_L = float.Parse(columns[76]),
                        MD_U = float.Parse(columns[77]),
                        MDInc = float.Parse(columns[78]),
                        MAR_L = float.Parse(columns[79]),
                        MAR_U = float.Parse(columns[80]),
                        MARInc = float.Parse(columns[81]),
                        PDStr_L = float.Parse(columns[82]),
                        PDStr_U = float.Parse(columns[83]),
                        MDInt_L = float.Parse(columns[84]),
                        MDInt_U = float.Parse(columns[85]),
                        Quivered = byte.Parse(columns[86]),
                        Ammo1_TID4 = byte.Parse(columns[87]),
                        Ammo2_TID4 = byte.Parse(columns[88]),
                        Ammo3_TID4 = byte.Parse(columns[89]),
                        Ammo4_TID4 = byte.Parse(columns[90]),
                        Ammo5_TID4 = byte.Parse(columns[91]),
                        SpeedClass = byte.Parse(columns[92]),
                        TwoHanded = byte.Parse(columns[93]),
                        Range = short.Parse(columns[94]),
                        PAttackMin_L = float.Parse(columns[95]),
                        PAttackMin_U = float.Parse(columns[96]),
                        PAttackMax_L = float.Parse(columns[97]),
                        PAttackMax_U = float.Parse(columns[98]),
                        PAttackInc = float.Parse(columns[99]),
                        MAttackMin_L = float.Parse(columns[100]),
                        MAttackMin_U = float.Parse(columns[101]),
                        MAttackMax_L = float.Parse(columns[102]),
                        MAttackMax_U = float.Parse(columns[103]),
                        MAttackInc = float.Parse(columns[104]),
                        PAStrMin_L = float.Parse(columns[105]),
                        PAStrMin_U = float.Parse(columns[106]),
                        PAStrMax_L = float.Parse(columns[107]),
                        PAStrMax_U = float.Parse(columns[108]),
                        MAInt_Min_L = float.Parse(columns[109]),
                        MAInt_Min_U = float.Parse(columns[110]),
                        MAInt_Max_L = float.Parse(columns[111]),
                        MAInt_Max_U = float.Parse(columns[112]),
                        HR_L = float.Parse(columns[113]),
                        HR_U = float.Parse(columns[114]),
                        HRInc = float.Parse(columns[115]),
                        CHR_L = float.Parse(columns[116]),
                        CHR_U = float.Parse(columns[117]),
                        Param1 = int.Parse(columns[118]),
                        Desc1_128 = columns[119],
                        Param2 = int.Parse(columns[120]),
                        Desc2_128 = columns[121],
                        Param3 = int.Parse(columns[122]),
                        Desc3_128 = columns[123],
                        Param4 = int.Parse(columns[124]),
                        Desc4_128 = columns[125],
                        Param5 = int.Parse(columns[126]),
                        Desc5_128 = columns[127],
                        Param6 = int.Parse(columns[128]),
                        Desc6_128 = columns[129],
                        Param7 = int.Parse(columns[130]),
                        Desc7_128 = columns[131],
                        Param8 = int.Parse(columns[132]),
                        Desc8_128 = columns[133],
                        Param9 = int.Parse(columns[134]),
                        Desc9_128 = columns[135],
                        Param10 = int.Parse(columns[136]),
                        Desc10_128 = columns[137],
                        Param11 = int.Parse(columns[138]),
                        Desc11_128 = columns[139],
                        Param12 = int.Parse(columns[140]),
                        Desc12_128 = columns[141],
                        Param13 = int.Parse(columns[142]),
                        Desc13_128 = columns[143],
                        Param14 = int.Parse(columns[144]),
                        Desc14_128 = columns[145],
                        Param15 = int.Parse(columns[146]),
                        Desc15_128 = columns[147],
                        Param16 = int.Parse(columns[148]),
                        Desc16_128 = columns[149],
                        Param17 = int.Parse(columns[150]),
                        Desc17_128 = columns[151],
                        Param18 = int.Parse(columns[152]),
                        Desc18_128 = columns[153],
                        Param19 = int.Parse(columns[154]),
                        Desc19_128 = columns[155],
                        Param20 = int.Parse(columns[156]),
                        Desc20_128 = columns[157],
                        MaxMagicOptCount = byte.Parse(columns[158]),
                        ChildItemCount = byte.Parse(columns[159]),
                        Link = 0
                    };
                    refObjItemList.Add(refObjItem);
                    refObjList.Add(refObj);
                }
            }


            if (refObjItemList.Count() > 0)
            {
                foreach (var item in refObjItemList)
                {
                    int i = refObjItemList.FindIndex(q=> q == item);
                    int refObjItemID = RefObjItemInsert(refObjItemList[i]);
                    // RefObj içindeki Link alanına bu ID'yi atayın
                    refObjList[i].Link = refObjItemID;
                }
                
            }

            if (refObjList.Count() > 0)
            {
                foreach (var item in refObjList)
                {
                    // Icon kopyalama
                    ConfigHelper.CopyIcon(item.AssocFileIcon128);

                    if (item.CodeName128.StartsWith("ITEM"))
                    {
                        RefObjCommonInsert(item);
                    }
                }
            }
        }





        CheckBox headerCheckBox = new CheckBox();

        private void TxtToDBForm_Load(object sender, EventArgs e)
        {
            // Header'a checkbox eklemek için alan belirleyelim
            dataGridView1.AllowUserToAddRows = false;
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Location = new Point(30, 5); // Checkbox'ın konumu
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            dataGridView1.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Eğer header'daki checkbox seçildiyse, tüm satırları seç veya seçimden çıkar
            dataGridView1.CurrentCell = null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells["Select"];
                checkBox.Value = headerCheckBox.Checked;
            }
        }

        private void addTxt_Click(object sender, EventArgs e)
        {
            // Dosya seç
            SelectFile();
        }


        private void searchTextBox_TextChanged_1(object sender, EventArgs e)
        {
            string searchValue = searchTextBox.Text.ToLower(); // TextBox içeriğini al ve küçük harfe çevir
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Satırın CodeName128 hücresinin değerini al
                string codeName128Value = row.Cells["CodeName128"].Value?.ToString().ToLower();

                // Eğer TextBox içeriği CodeName128 değerini içeriyorsa satırı göster, aksi takdirde gizle
                if (codeName128Value != null && codeName128Value.Contains(searchValue))
                {
                    row.Visible = true; // Eşleşiyorsa görünür yap
                }
                else
                {
                    row.Visible = false; // Eşleşmiyorsa gizle
                }
            }
        }


        private void SelectFile()
        {
            refObjList.Clear();



            if (ConfigHelper.SelectedFolderPath != string.Empty)
            {
                string filePath = ConfigHelper.SelectedFolderPath + "\\server_dep\\silkroad\\textdata\\itemdata_45000.txt";

                // Dosyayı oku
                fileLines = File.ReadAllLines(filePath);

                // DataGridView'ı temizle
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear(); // Sütunları temizle

                // Checkbox sütununu ekleyin
                DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select", // Başlık kısmı
                    Name = "Select",
                    Width = 50
                };
                dataGridView1.Columns.Add(selectColumn);

                // Diğer sütun başlıklarını ekleyin
                string[] headers = new string[]
                {
                    //RefObjCommon
                    "Service", "ID", "CodeName128", "ObjName128", "OrgObjCodeName128",
                    "NameStrID128", "DescStrID128", "CashItem", "Bionic", "TypeID1",
                    "TypeID2", "TypeID3", "TypeID4", "DecayTime", "Country", "Rarity",
                    "CanTrade", "CanSell", "CanBuy", "CanBorrow", "CanDrop",
                    "CanPick", "CanRepair", "CanRevive", "CanUse", "CanThrow",
                    "Price", "CostRepair", "CostRevive", "CostBorrow", "KeepingFee",
                    "SellPrice", "ReqLevelType1", "ReqLevel1", "ReqLevelType2", "ReqLevel2",
                    "ReqLevelType3", "ReqLevel3", "ReqLevelType4", "ReqLevel4", "MaxContain",
                    "RegionID", "Dir", "OffsetX", "OffsetY", "OffsetZ",
                    "Speed1", "Speed2", "Scale", "BCHeight", "BCRadius",
                    "EventID", "AssocFileObj128", "AssocFileDrop128", "AssocFileIcon128",
                    "AssocFile1_128", "AssocFile2_128",

                    //RefObjItem
                    "MaxStack", "ReqGender", "ReqStr", "ReqInt", "ItemClass", "SetID",
                    "Dur_L", "Dur_U", "PD_L", "PD_U", "PDInc", "ER_L", "ER_U", "ERInc",
                    "PAR_L", "PAR_U", "PARInc", "BR_L", "BR_U", "MD_L", "MD_U", "MDInc",
                    "MAR_L", "MAR_U", "MARInc", "PDStr_L", "PDStr_U", "MDInt_L", "MDInt_U",
                    "Quivered", "Ammo1_TID4", "Ammo2_TID4", "Ammo3_TID4", "Ammo4_TID4",
                    "Ammo5_TID4", "SpeedClass", "TwoHanded", "Range", "PAttackMin_L",
                    "PAttackMin_U", "PAttackMax_L", "PAttackMax_U", "PAttackInc",
                    "MAttackMin_L", "MAttackMin_U", "MAttackMax_L", "MAttackMax_U",
                    "MAttackInc", "PAStrMin_L", "PAStrMin_U", "PAStrMax_L", "PAStrMax_U",
                    "MAInt_Min_L", "MAInt_Min_U", "MAInt_Max_L", "MAInt_Max_U",
                    "HR_L", "HR_U", "HRInc", "CHR_L", "CHR_U", "Param1", "Desc1_128",
                    "Param2", "Desc2_128", "Param3", "Desc3_128", "Param4", "Desc4_128",
                    "Param5", "Desc5_128", "Param6", "Desc6_128", "Param7", "Desc7_128",
                    "Param8", "Desc8_128", "Param9", "Desc9_128", "Param10", "Desc10_128",
                    "Param11", "Desc11_128", "Param12", "Desc12_128", "Param13", "Desc13_128",
                    "Param14", "Desc14_128", "Param15", "Desc15_128", "Param16", "Desc16_128",
                    "Param17", "Desc17_128", "Param18", "Desc18_128", "Param19", "Desc19_128",
                    "Param20", "Desc20_128", "MaxMagicOptCount", "ChildItemCount"
                };

                foreach (string header in headers)
                {
                    dataGridView1.Columns.Add(header, header); // Sütunları ekle
                }
                // Dosyadan sonraki satırları DataGridView'a ekle
                foreach (var line in fileLines)
                {
                    // Satırı TAB karakteri ile ayır
                    string[] columns = line.Split('\t');
                    if (columns.Length > 40)
                    {



                        // Geçerli sütun sayısını kontrol et
                        // Checkbox için false değeri ekle ve ardından diğer değerleri ekle
                        object[] row = new object[columns.Length + 1]; // 1 ekstra alan checkbox için
                        row[0] = false; // Checkbox başlangıç değeri (isteğe bağlı)
                        for (int i = 0; i < columns.Length; i++)
                        {
                            row[i + 1] = columns[i]; // Diğer sütun değerlerini ekle
                        }

                        dataGridView1.Rows.Add(row); // Satırı ekle
                    }

                }

                // Seçilen dosya yolunu göster
                txtPath.Text = filePath;
            }
        }
    }
}
