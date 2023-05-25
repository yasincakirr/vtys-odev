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
        NpgsqlConnection baglant� = new NpgsqlConnection("server=localHost; port=5432; Database=dbvtysodev; user Id=postgres; password=1234Cakir1234");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            string listeleme = "select* from �r�nhal�";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(listeleme, baglant�);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            baglant�.Open();
            NpgsqlCommand ekleme = new NpgsqlCommand("insert into �r�nhal�(�retilen_hal�n�n_id,�retim_sekli_ad,hal�n�n_sekli,hal�_renk,uretildigi_malzeme_id,dokuma_turune_id,stok_miktar�,satis_fiyati)  values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglant�);

            ekleme.Parameters.AddWithValue("@p1", int.Parse(Txturetilenhal�id.Text));
            ekleme.Parameters.AddWithValue("@p2", Txturetimsekliad.Text);
            ekleme.Parameters.AddWithValue("@p3", int.Parse(comboBox1.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p4", int.Parse(comboBox2.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p5", int.Parse(comboBox2.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p6", int.Parse(comboBox4.SelectedValue.ToString()));
            ekleme.Parameters.AddWithValue("@p7", int.Parse(numericUpDown1.Value.ToString()));
            ekleme.Parameters.AddWithValue("@p8", int.Parse(Txtsatisfiyat.Text));

            ekleme.ExecuteNonQuery();
            baglant�.Close();
            MessageBox.Show("urun ekleme i�lemi ba�ar�l� bir �ekilde ger�ekle�tir");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            baglant�.Open();
            NpgsqlDataAdapter d1 = new NpgsqlDataAdapter("select * from sekline_g�re_hal�", baglant�);
            DataTable dt = new DataTable();
            d1.Fill(dt);
            comboBox1.DisplayMember = "�ekil_ad";
            comboBox1.ValueMember = "�ekil_id";
            comboBox1.DataSource = dt;
            baglant�.Close();


            baglant�.Open();
            NpgsqlDataAdapter d2 = new NpgsqlDataAdapter("select * from hal�n�n_rengi", baglant�);
            DataTable ds = new DataTable();
            d2.Fill(ds);
            comboBox2.DisplayMember = "renk_ad";
            comboBox2.ValueMember = "renk_id";
            comboBox2.DataSource = ds;
            baglant�.Close();


            baglant�.Open();
            NpgsqlDataAdapter d3 = new NpgsqlDataAdapter("select * from uretildigi_malzemesine_g�re_hal�", baglant�);
            DataTable dm = new DataTable();
            d3.Fill(dm);
            comboBox3.DisplayMember = "malzemead";
            comboBox3.ValueMember = "malzemeid";
            comboBox3.DataSource = dm;
            baglant�.Close();


            baglant�.Open();
            NpgsqlDataAdapter d4 = new NpgsqlDataAdapter("select * from dokuma_turune_gore_cesitler", baglant�);
            DataTable dd = new DataTable();
            d4.Fill(dd);
            comboBox4.DisplayMember = "dokumat�r_ad";
            comboBox4.ValueMember = "dokumat�r_id";
            comboBox4.DataSource = dd;
            baglant�.Close();

        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglant�.Open();
            NpgsqlCommand silme = new NpgsqlCommand("Delete from �r�nhal� Where �retilen_hal�n�n_id =@p1", baglant�);
            silme.Parameters.AddWithValue("@p1", int.Parse(Txturetilenhal�id.Text));
            silme.ExecuteNonQuery();
            baglant�.Close();
            MessageBox.Show("Silme �slemi Basariyla Tamamland�", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void Btnguncelle_Click(object sender, EventArgs e)
        {
            baglant�.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("Update �r�nhal� set �retim_sekli_ad=@p1,hal�n�n_sekli=@p2,hal�_renk=@p3,uretildigi_malzeme_id=@p4,dokuma_turune_id=@p5, stok_miktar�=@p6, satis_fiyati=@p7 where �retilen_hal�n�n_id=@p8", baglant�);
            guncelle.Parameters.AddWithValue("@p1", Txturetimsekliad.Text);
            guncelle.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p3", int.Parse(comboBox2.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p4", int.Parse(comboBox3.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p5", int.Parse(comboBox4.SelectedValue.ToString()));
            guncelle.Parameters.AddWithValue("@p6", int.Parse(numericUpDown1.Value.ToString()));
            guncelle.Parameters.AddWithValue("@p7", int.Parse(Txtsatisfiyat.Text));
            guncelle.Parameters.AddWithValue("@p8", int.Parse(Txturetilenhal�id.Text));

            guncelle.ExecuteNonQuery();
            baglant�.Close();
            MessageBox.Show("Guncelleme islemi tamamland�", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 gecis=new Form2();
            gecis.Show();
            this.Hide();
        }

    }
}