using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NOT_KAYIT_SİSTEMİ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotKayıtDataSet.tbl_ders' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_dersTableAdapter.Fill(this.dbNotKayıtDataSet.tbl_ders);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            textBox3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            textBox5.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
           
            double toplam, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(textBox3.Text);
            s2 = Convert.ToDouble(textBox4.Text);
            s3 = Convert.ToDouble(textBox5.Text);
            toplam = (s1 + s2 + s3) / 3;
            label12.Text = toplam.ToString();
            if (toplam >= 50)
            {
                label11.Text = "Geçti";
                durum = "True";
            }
            else
            {
                label11.Text = "Kaldı";
                durum = "False";
            }
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update tbl_ders set OGRS1=@S1,OGRS2=@S2,OGRS3=@S3,ORTALAMA=@S5,DURUM=@S4 Where OGRNUMARA=@S6", baglanti);
            komut1.Parameters.AddWithValue("S1", textBox3.Text);
            komut1.Parameters.AddWithValue("S2", textBox4.Text);
            komut1.Parameters.AddWithValue("S3", textBox5.Text);
            komut1.Parameters.AddWithValue("S5", decimal.Parse(label12.Text));
            komut1.Parameters.AddWithValue("S4", durum);
            komut1.Parameters.AddWithValue("S6", maskedTextBox1.Text);
            komut1.ExecuteNonQuery();
            MessageBox.Show("Güncelleme yapıldı");
            this.tbl_dersTableAdapter.Fill(this.dbNotKayıtDataSet.tbl_ders);

            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_ders (OGRNUMARA,OGRAD,OGRSOYAD,DURUM) values (@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4",label9.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt yapıldı");
            this.tbl_dersTableAdapter.Fill(this.dbNotKayıtDataSet.tbl_ders);
            baglanti.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label11.Text = "";
            label12.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 hg = new Form4();
            hg.Show();
        }
    }
}
