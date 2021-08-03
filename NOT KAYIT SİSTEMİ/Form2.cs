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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            label9.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_ders where OGRNUMARA=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label8.Text = dr[2].ToString() + " " + dr[3].ToString();
                label10.Text = dr[4].ToString();
                label11.Text = dr[5].ToString();
                label12.Text = dr[6].ToString();
                label13.Text = dr[7].ToString();
                label14.Text = dr[8].ToString();



            }
            baglanti.Close();
        }
    }
}
