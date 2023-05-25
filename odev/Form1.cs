using Npgsql;
using System.Data;

namespace odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglantý = new NpgsqlConnection("server=localHost; port=5432; Database=dbvtysodev; user Id=postgres; password=1234Cakir1234");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            string listeleme = "select* from ürünhalý";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(listeleme, baglantý);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            baglantý.Open();
            NpgsqlCommand ekleme = new NpgsqlCommand("insert into ürünhalý(üretilen_halýnýn_id,üretim_sekli_ad,halýnýn_sekli,halý_renk,uretildigi_malzeme_id,dokuma_turune_id,stok_miktarý,satis_fiyati)  values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglantý);

            ekleme.Parameters.AddWithValue("@p1", int.Parse(Txturetilenhalýid.Text));
            ekleme.Parameters.AddWithValue("@p2", Txturetimsekliad.Text);
            ekleme.Parameters.AddWithValue("@p3", int.Parse(comboBox1.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p4", int.Parse(comboBox2.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p5", int.Parse(comboBox2.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p6", int.Parse(comboBox4.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p7", int.Parse(numericUpDown1.Value.ToString()));
            ekleme.Parameters.AddWithValue("@p8", int.Parse(Txtsatisfiyat.Text));

            ekleme.ExecuteNonQuery();
            baglantý.Close();
            MessageBox.Show("urun ekleme iþlemi baþarýlý bir þekilde gerçekleþtir");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            baglantý.Open();
            NpgsqlDataAdapter d1 = new NpgsqlDataAdapter("select * from sekline_göre_halý", baglantý);
            DataTable dt = new DataTable();
            d1.Fill(dt);
            comboBox1.DisplayMember = "þekil_ad";
            comboBox1.ValueMember = "þekil_id";
            comboBox1.DataSource = dt;
            baglantý.Close();


            baglantý.Open();
            NpgsqlDataAdapter d2 = new NpgsqlDataAdapter("select * from halýnýn_rengi", baglantý);
            DataTable ds = new DataTable();
            d2.Fill(ds);
            comboBox2.DisplayMember = "renk_ad";
            comboBox2.ValueMember = "renk_id";
            comboBox2.DataSource = ds;
            baglantý.Close();


            baglantý.Open();
            NpgsqlDataAdapter d3 = new NpgsqlDataAdapter("select * from uretildigi_malzemesine_göre_halý", baglantý);
            DataTable dm = new DataTable();
            d3.Fill(dm);
            comboBox3.DisplayMember = "malzemead";
            comboBox3.ValueMember = "malzemeid";
            comboBox3.DataSource = dm;
            baglantý.Close();


            baglantý.Open();
            NpgsqlDataAdapter d4 = new NpgsqlDataAdapter("select * from dokuma_turune_gore_cesitler", baglantý);
            DataTable dd = new DataTable();
            d4.Fill(dd);
            comboBox4.DisplayMember = "dokumatür_ad";
            comboBox4.ValueMember = "dokumatür_id";
            comboBox4.DataSource = dd;
            baglantý.Close();

        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglantý.Open();
            NpgsqlCommand silme = new NpgsqlCommand("Delete from ürünhalý Where üretilen_halýnýn_id =@p1", baglantý);
            silme.Parameters.AddWithValue("@p1", int.Parse(Txturetilenhalýid.Text));
            silme.ExecuteNonQuery();
            baglantý.Close();
            MessageBox.Show("Silme Ýslemi Basariyla Tamamlandý", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void Btnguncelle_Click(object sender, EventArgs e)
        {
            baglantý.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("Update ürünhalý set üretim_sekli_ad=@p1,halýnýn_sekli=@p2,halý_renk=@p3,uretildigi_malzeme_id=@p4,dokuma_turune_id=@p5, stok_miktarý=@p6, satis_fiyati=@p7 where üretilen_halýnýn_id=@p8", baglantý);
            guncelle.Parameters.AddWithValue("@p1", Txturetimsekliad.Text);
            guncelle.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p3", int.Parse(comboBox2.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p4", int.Parse(comboBox3.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p5", int.Parse(comboBox4.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p6", int.Parse(numericUpDown1.Value.ToString()));
            guncelle.Parameters.AddWithValue("@p7", int.Parse(Txtsatisfiyat.Text));
            guncelle.Parameters.AddWithValue("@p8", int.Parse(Txturetilenhalýid.Text));

            guncelle.ExecuteNonQuery();
            baglantý.Close();
            MessageBox.Show("Guncelleme islemi tamamlandý", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 gecis=new Form2();
            gecis.Show();
            this.Hide();
        }

    }
}