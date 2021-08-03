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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(ORTALAMA)/count(*) from tbl_ders",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label1.Text = dr[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from  tbl_ders where DURUM=1 ", baglanti);
            SqlDataReader gr = komut2.ExecuteReader();
            while(gr.Read())
            {
                label2.Text = gr[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from  tbl_ders where DURUM=0 ", baglanti);
            SqlDataReader tg = komut3.ExecuteReader();
            while (tg.Read())
            {
                label3.Text = tg[0].ToString();
            }
            baglanti.Close();

        }
    }
}
