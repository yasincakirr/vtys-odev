using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbvtysodev; user Id=postgres; password=1234Cakir1234");

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 oncekiSayfa=new Form1();
            oncekiSayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from  musteriler_danismanlik_toblo_birlestirme()";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu2 = "Select * from kayittaki_toplam_musteri_sayisi(2)";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu3 = "Select * from hali_urunlerini_listele()";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView1.DataSource = ds3.Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sorgu4 = "Select * from personelleri_sehir_adlari_ile_birlestirme()";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView1.DataSource = ds4.Tables[0];

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sorgu5 = "Select * from sehir where sehir_ad like 'B%'";
            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            dataGridView1.DataSource = ds5.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu6 = "Select * from calısanlar where sabitucret>13000";
            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, baglanti);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            dataGridView1.DataSource = ds6.Tables[0];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu7 = "Select * from sehir where sehir_id>50";
            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, baglanti);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            dataGridView1.DataSource = ds7.Tables[0];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sorgu8 = "select * from calısanlar where kıdem > 5";
            NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, baglanti);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            dataGridView1.DataSource = ds8.Tables[0];

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sorgu9 = "Select * from ürünhalı where satis_fiyati>1500";
            NpgsqlDataAdapter da9 = new NpgsqlDataAdapter(sorgu9, baglanti);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            dataGridView1.DataSource = ds9.Tables[0];

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sorgu10 = "Select * from ürünhalı where stok_miktarı<20";
            NpgsqlDataAdapter da10 = new NpgsqlDataAdapter(sorgu10, baglanti);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            dataGridView1.DataSource = ds10.Tables[0];
        }
    }
}
