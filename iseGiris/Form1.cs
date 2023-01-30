using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
namespace iseGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-52MVLDJ\\SQLEXPRESS;Initial Catalog=personellist;Integrated Security=True;TrustServerCertificate=True");

        private void Form1_Load(object sender, EventArgs e)
        {






        }
        public static string UyeListeleSecilen;

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand komutUyeEkle = new SqlCommand("INSERT INTO list (kimlikno,ad,soyad,departman,tarih) VALUES (@kimlikno,@ad,@soyad,@departman,@tarih)", baglanti);
                komutUyeEkle.Parameters.Add("@kimlikno", SqlDbType.BigInt).Value = textBox1.Text.ToString();
                komutUyeEkle.Parameters.Add("@ad", SqlDbType.Text).Value = textBox2.Text;
                komutUyeEkle.Parameters.Add("@soyad", SqlDbType.Text).Value = textBox3.Text;
                komutUyeEkle.Parameters.Add("@departman", SqlDbType.Text).Value = comboBox1.Text;
                komutUyeEkle.Parameters.Add("@tarih", SqlDbType.Date).Value = dateTimePicker1.Text.ToString();

                baglanti.Open();
                komutUyeEkle.ExecuteNonQuery();
                MessageBox.Show("Personel Baþarýyla Eklendi");
                baglanti.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                dateTimePicker1.Text = "";





            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluþtu");

            }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           textBox1.MaxLength= 11;
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand UyeListele = new SqlCommand("SELECT *  FROM list", baglanti);
            SqlDataAdapter veri = new SqlDataAdapter(UyeListele);
            DataTable dt = new DataTable();
            veri.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Personeli silmek istediðinizden emin misiniz?", "Uyarý", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {
                    string secilen = Form1.UyeListeleSecilen.ToString();

                    baglanti.Open();
                    SqlCommand KayitSil = new SqlCommand("DELETE FROM list WHERE kimlikno=@secilen  ", baglanti);
                    KayitSil.Parameters.Add("@secilen", SqlDbType.BigInt).Value = Form1.UyeListeleSecilen.ToString();
                    KayitSil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayýt baþarýyla silindi");
                    
                }
                catch (Exception)
                {

                    MessageBox.Show("Bir hata oluþtu");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            UyeListeleSecilen = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["kimlikno"].Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}