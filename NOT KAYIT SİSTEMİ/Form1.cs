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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_ders where OGRNUMARA=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            SqlDataReader tb = komut.ExecuteReader();
            if(tb.Read())
            {
               Form2 frm = new Form2();
               frm.numara = maskedTextBox1.Text;
               frm.Show();
            }
            else
            {
                MessageBox.Show("Sistemde kayıtlı numara bulunamadı");
            }
            baglanti.Close();
            

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text=="1111")
            {
                Form3 fr = new Form3();
                fr.Show();
            }
        }
    }
}
