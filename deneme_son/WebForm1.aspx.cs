using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using ZXing;
using System.Drawing;
using System.IO;
using System.Web.Configuration;

namespace deneme_son
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public double x1 = 40.78;
        public double x2 = 29.97;
        public int sira;
       
        string[] Neden = new string[] { "Trafik", "YolcuYogunlugu", "Ariza", "Kaza" };
        string[] Havadurumu = new string[] { "Yagisli", "Normal", "Karli" };
        string neden;
        string havadurumu;

        double[] sonuclar = new double[12];
        double enbuyuk;
        int tut;
        int geckalma;

        int hat = 23;
        string durakno= "";

        string saat;

        DataTable dt = new DataTable();
        DataTable d1 = new DataTable();
        DataTable d2 = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            veri_alma();
            deger_uret();
            d1.Columns.Add("feyyaz"); d1.Columns.Add("ozhan"); //2. ve 3. gridlerin sütunlarını olustur...
            d2.Columns.Add("feyyaz"); d2.Columns.Add("ozhan");
            durakno = durakno + ";";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView3.Visible = true;
            GridView4.Visible = true;
            GridView5.Visible = false;
            GridView6.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView5.Visible = true;
            GridView6.Visible = true;
            GridView3.Visible = false;
            GridView4.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);

            
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT23_sefer_saatleri ", bag);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            GridView2.DataSource = tablo;
            GridView2.DataBind();
            bag.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT24_sefer_saatleri ", bag);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            GridView2.DataSource = tablo;
            GridView2.DataBind();
            bag.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            sira = 1;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            sira = 2;
        }
        

        void barkod1_oku()
        {
            IBarcodeReader reader = new BarcodeReader();
            Bitmap barcodeBitmap = new Bitmap(Server.MapPath("~/resimler/Durak1.png"));
            var result = reader.Decode(barcodeBitmap);

          
            string[] deneme = result.Text.Split(',');
            double a = Convert.ToDouble(deneme[0]);
            double b = Convert.ToDouble(deneme[1]);
            x1 = a;
            x2 = b;

            
        }
        void barkod2_oku()
        {
            IBarcodeReader reader = new BarcodeReader();
            Bitmap barcodeBitmap = new Bitmap(Server.MapPath("~/resimler/Durak2.png"));
            var result = reader.Decode(barcodeBitmap);

            string[] deneme = result.Text.Split(',');
            double a = Convert.ToDouble(deneme[0]);
            double b = Convert.ToDouble(deneme[1]);
            x1 = a;
            x2 = b;
        }
        void barkod3_oku()
        {
            IBarcodeReader reader = new BarcodeReader();
            Bitmap barcodeBitmap = new Bitmap(Server.MapPath("~/resimler/Durak3.png"));
            var result = reader.Decode(barcodeBitmap);

            string[] deneme = result.Text.Split(',');
            double a = Convert.ToDouble(deneme[0]);
            double b = Convert.ToDouble(deneme[1]);
            x1 = a;
            x2 = b;
        }
        void barkod4_oku()
        {
            IBarcodeReader reader = new BarcodeReader();
            Bitmap barcodeBitmap = new Bitmap(Server.MapPath("~/resimler/Durak4.png"));
            var result = reader.Decode(barcodeBitmap);

            string[] deneme = result.Text.Split(',');
            double a = Convert.ToDouble(deneme[0]);
            double b = Convert.ToDouble(deneme[1]);
            x1 = a;
            x2 = b;
        }
        void barkod5_oku()
        {
            IBarcodeReader reader = new BarcodeReader();
            Bitmap barcodeBitmap = new Bitmap(Server.MapPath("~/resimler/Durak5.png"));
            var result = reader.Decode(barcodeBitmap);

            string[] deneme = result.Text.Split(',');
            double a = Convert.ToDouble(deneme[0]);
            double b = Convert.ToDouble(deneme[1]);
            x1 = a;
            x2 = b;
        }
        void ingilizceye_cevir()
        {
            System.Globalization.CultureInfo englishculture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = englishculture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = englishculture;
        }
        void algoritmalari_cagir()
        {
            sonuclar[0] = algoritma1();
            sonuclar[1] = algoritma2();
            sonuclar[2] = algoritma3();
            sonuclar[3] = algoritma4();
            sonuclar[4] = algoritma5();
            sonuclar[5] = algoritma6();
            sonuclar[6] = algoritma7();
            sonuclar[7] = algoritma8();
            sonuclar[8] = algoritma9();
            sonuclar[9] = algoritma10();
            sonuclar[10] = algoritma11();
            sonuclar[11] = algoritma12();


            saaticek();
            geckalmabul();
            geckalmaekle();
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            ingilizceye_cevir();

            if (e.CommandName == "Ne Zaman Gelecek")
            {
                int sira = Convert.ToInt32(e.CommandArgument);
                string Sira = sira.ToString();
                durakno = Sira + ";";
                algoritmalari_cagir();                
            }

            else if (e.CommandName == "Haritada Göster")
            {
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira == 42) { barkod1_oku(); }
                if (sira == 43) { barkod2_oku(); }                
                if (sira == 44) { barkod3_oku(); }                
                if (sira == 45) { barkod4_oku(); }                
                if (sira == 46) { barkod5_oku(); }
            }

            else if (e.CommandName == "Geçen Diğer Hatlar")
            {
                GridView1.Visible = false;
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira != 42 && sira != 43 && sira != 44 && sira != 45 && sira != 46)
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;

                    string Sira = sira.ToString();
                    string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);
                    bag.Open();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT23_" + Sira + " ", bag);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    tablo.Columns[0].ColumnName = "Hat No";
                    tablo.Columns[1].ColumnName = "Hat Adı";
                    tablo.Columns[2].ColumnName = "Durak ID";
                    tablo.Columns[3].ColumnName = "Yönü";
                    GridView1.DataSource = tablo;
                    GridView1.DataBind();
                    bag.Close();
                }
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ingilizceye_cevir();

            if (e.CommandName == "Ne Zaman Gelecek")
            {
                int sira = Convert.ToInt32(e.CommandArgument);
                string Sira = sira.ToString();
                durakno = Sira + ";";
                algoritmalari_cagir();
            }

            else if (e.CommandName == "Haritada Göster")
            {
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira == 51) { barkod1_oku(); }
                if (sira == 50) { barkod2_oku(); }
                if (sira == 49) { barkod3_oku(); }
                if (sira == 48) { barkod4_oku(); }
                if (sira == 47) { barkod5_oku(); }
            }
            else if (e.CommandName == "Geçen Diğer Hatlar")
            {
                GridView1.Visible = false;
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira != 47 && sira != 48 && sira != 49 && sira != 50 && sira != 51)
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;

                    string Sira = sira.ToString();
                    string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);
                    bag.Open();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT23_" + Sira + " ", bag);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    tablo.Columns[0].ColumnName = "Hat No";
                    tablo.Columns[1].ColumnName = "Hat Adı";
                    tablo.Columns[2].ColumnName = "Durak ID";
                    tablo.Columns[3].ColumnName = "Yönü";
                    GridView1.DataSource = tablo;
                    GridView1.DataBind();
                    bag.Close();
                }

            }
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ingilizceye_cevir();

            if (e.CommandName == "Ne Zaman Gelecek")
            {
                int sira = Convert.ToInt32(e.CommandArgument);
                string Sira = sira.ToString();
                durakno = Sira + ";";
                algoritmalari_cagir();
            }

            else if (e.CommandName == "Haritada Göster")
            {
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira == 47) { barkod1_oku(); }
                if (sira == 48) { barkod2_oku(); }
                if (sira == 49) { barkod3_oku(); }
                if (sira == 50) { barkod4_oku(); }
                if (sira == 51) { barkod5_oku(); }
            }
            else if (e.CommandName == "Geçen Diğer Hatlar")
            {
                GridView1.Visible = false;
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira != 47 && sira != 48 && sira != 49 && sira != 50 && sira != 51)
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;

                    string Sira = sira.ToString();
                    string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);
                    bag.Open();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT23_" + Sira + " ", bag);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    tablo.Columns[0].ColumnName = "Hat No";
                    tablo.Columns[1].ColumnName = "Hat Adı";
                    tablo.Columns[2].ColumnName = "Durak ID";
                    tablo.Columns[3].ColumnName = "Yönü";
                    GridView1.DataSource = tablo;
                    GridView1.DataBind();
                    bag.Close();
                }

            }
        }

        protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ingilizceye_cevir();

            if (e.CommandName == "Ne Zaman Gelecek")
            {
                int sira = Convert.ToInt32(e.CommandArgument);
                string Sira = sira.ToString();
                durakno = Sira + ";";
                algoritmalari_cagir();
            }

            else if (e.CommandName == "Haritada Göster")
            {
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira == 56) { barkod1_oku(); }
                if (sira == 55) { barkod2_oku(); }
                if (sira == 54) { barkod3_oku(); }
                if (sira == 53) { barkod4_oku(); }
                if (sira == 52) { barkod5_oku(); }
            }
            else if (e.CommandName == "Geçen Diğer Hatlar")
            {
                GridView1.Visible = false;
                int sira = Convert.ToInt32(e.CommandArgument);

                if (sira != 52 && sira != 53 && sira != 54 && sira != 55 && sira != 56)
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;

                    string Sira = sira.ToString();
                    string baglanti_cumlesi = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    OleDbConnection bag = new OleDbConnection(baglanti_cumlesi);
                    bag.Open();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("select * From HAT23_" + Sira + " ", bag);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    tablo.Columns[0].ColumnName = "Hat No";
                    tablo.Columns[1].ColumnName = "Hat Adı";
                    tablo.Columns[2].ColumnName = "Durak ID";
                    tablo.Columns[3].ColumnName = "Yönü";
                    GridView1.DataSource = tablo;
                    GridView1.DataBind();
                    bag.Close();
                }
            }
        }

        double algoritma1()
        {
            
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;


            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 0 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 5)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 0 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 5)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 0 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 5)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

        
            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma2()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    //
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 6 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 10)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)   
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 6 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 10)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 6 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 10)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) { return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma3()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 11 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 15)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 11 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 15)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 11 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 15)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;
        }
        double algoritma4()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)   
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 16 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 20)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)   
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 16 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 20)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 16 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 20)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma5()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)   
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 21 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 25)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 21 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 25)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 21 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 25)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

        
            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;
        }
        double algoritma6()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 26 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 30)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu) 
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 26 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 30)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 26 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 30)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

        
            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;
        }
        double algoritma7()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 31 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 35)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 31 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 35)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 31 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 35)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;
        }
        double algoritma8()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 36 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 40)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 36 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 40)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 36 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 40)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

     
            if (satir_say2 == 0 || satir_say3 == 0) { return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma9()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 41 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 45)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu) 
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 41 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 45)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 41 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 45)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }


            if (satir_say2 == 0 || satir_say3 == 0) { return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma10()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden) 
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 46 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 50)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 46 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 50)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 46 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 50)
                    {
                        ++z;
                    }
                    ++eleman;
                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma11()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden) 
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 51 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 55)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu) 
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 51 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 55)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 51 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 55)
                    {
                        ++z;
                    }
                    ++eleman;

                }
            }

   
            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }
        double algoritma12()
        {
            double sonuc;

            int x = 0;
            int y = 0;
            int z = 0;

            int eleman = 0;
            int satir_say2 = 0;
            int satir_say3 = 0;

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    if (dt.Rows[k]["Neden"].ToString() == neden)  
                    {
                        d1.Rows.Add();
                        d1.Rows[satir_say2]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d1.Rows[satir_say2]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);

                        if (Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) >= 56 && Convert.ToInt32(d1.Rows[satir_say2]["feyyaz"]) <= 60)
                        {
                            ++x;
                        } ++satir_say2;
                    }

                    if (dt.Rows[k]["Havadurumu"].ToString() == havadurumu)  
                    {
                        d2.Rows.Add();
                        d2.Rows[satir_say3]["feyyaz"] = Convert.ToInt32(dt.Rows[k]["GecKalma"]);
                        d2.Rows[satir_say3]["ozhan"] = Convert.ToInt32(dt.Rows[k]["Hatno"]);


                        if (Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) >= 56 && Convert.ToInt32(d2.Rows[satir_say3]["feyyaz"]) <= 60)
                        {
                            ++y;
                        } ++satir_say3;
                    }

                    if (Convert.ToInt32(dt.Rows[k]["GecKalma"]) >= 56 && Convert.ToInt32(dt.Rows[k]["GecKalma"]) <= 60)
                    {
                        ++z;
                    }
                    ++eleman;

                }
            }

            if (satir_say2 == 0 || satir_say3 == 0) {  return 0; }
            sonuc = (Convert.ToDouble(x) / Convert.ToDouble(satir_say2)) * (Convert.ToDouble(y) / Convert.ToDouble(satir_say3)) * (Convert.ToDouble(z) / Convert.ToDouble(eleman));
            return sonuc;

        }

        void saaticek()
        {
            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                if (Convert.ToInt32(dt.Rows[k]["Hatno"]) == hat && dt.Rows[k]["DurakNo;"].ToString() == durakno)
                {
                    saat = dt.Rows[k]["DOGS"].ToString(); break;
                }
            }
            Label1.Text = "Durakta olması gereken saat:&nbsp&nbsp&nbsp&nbsp" + saat;
            

        }
        void geckalmabul()
        {
            enbuyuk = sonuclar[0];
            for (int i = 0; i < 11; ++i)
            {
                if (enbuyuk < sonuclar[i + 1])
                {
                    enbuyuk = sonuclar[i + 1];
                    tut = i + 1;
                }
            }
            if (tut == 0) geckalma = 3; if (tut == 1) geckalma = 8; if (tut == 2) geckalma = 13; if (tut == 3) geckalma = 18; if (tut == 4) geckalma = 23; if (tut == 5) geckalma = 28; if (tut == 6) geckalma = 33; if (tut == 7) geckalma = 38; if (tut == 8) geckalma = 43; if (tut == 9) geckalma = 48; if (tut == 10) geckalma = 53; if (tut == 11) geckalma = 58;
        }
        void geckalmaekle()
        {
            System.Globalization.CultureInfo englishculture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentCulture = englishculture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = englishculture;



            string[] value = saat.Split(':');
            int yenisaat = Convert.ToInt32(value[0]);
            int dakika = Convert.ToInt32(value[1]);

            dakika += geckalma;
            saat = yenisaat.ToString() + ":" + dakika.ToString();

            if (dakika >= 60)
            {
                yenisaat += 1;
                dakika -= 60;
                saat = yenisaat.ToString() + ":" + dakika.ToString();
                if (dakika < 10) { saat = yenisaat.ToString() + ":0" + dakika.ToString(); }

            }


            Label1.Text = Label1.Text + "<br/>Neden:&nbsp&nbsp&nbsp&nbsp" + neden + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspHava Durumu:&nbsp&nbsp&nbsp&nbsp" + havadurumu + "<br/>Geleceği saat:&nbsp&nbsp&nbsp&nbsp" + saat;

        }

        void deger_uret()
        {
            Random rasgele = new Random();
            int a = rasgele.Next(4);
            int b = rasgele.Next(3);
            neden = Neden[a];
            havadurumu = Havadurumu[b];

        }
        void veri_alma()
        {
            FileStream fs = new FileStream(Server.MapPath("~/ornekler_min .txt"), FileMode.Open);
            StreamReader reader = new StreamReader(fs);

            string line = reader.ReadLine();
            string[] value = line.Split(',');


            DataRow row;

            for (int i = 0; i < value.Length; i++)
            {
                dt.Columns.Add(new DataColumn(value[i]));
            }

            while (reader.Peek() > -1)
            {
                value = reader.ReadLine().Split(',');

                row = dt.NewRow();

                row.ItemArray = value;
                dt.Rows.Add(row);
            }

            reader.Close();

        }

        
    }
}