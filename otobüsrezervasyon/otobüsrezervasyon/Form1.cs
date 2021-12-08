using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace otobüsrezervasyon
{
    public partial class Form1 : Form
    {
        
        private static Button sender;
        rezervasyonekranı r;
        Button b = (Button)sender;
        public Form1()
        {
            InitializeComponent();
            r = new rezervasyonekranı();
        }
        //OleDbConnection baglanti=new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\Users\\Batuhan\\Desktop\\Documents\\Veri Tabanı\\otobüsrezervasyon.accdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            
            r.baglanti.Open();
            string koltuk;
            OleDbCommand komut = new OleDbCommand("select * from rezervasyon");
            komut.Connection = r.baglanti;
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                koltuk = "button" + oku["koltukno"].ToString();
                if(oku["cinsiyet"].ToString()=="Erkek")
                    this.Controls[koltuk].BackColor = Color.Blue;
                else
                    this.Controls[koltuk].BackColor = Color.Pink;
            }
            r.baglanti.Close();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Button b1 = (Button)sender;
            r.textBox7.Text = b1.Text;
            r.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string yer = "Button" + textBox1.Text;
            this.Controls[yer].BackColor = Color.Red;
        }
    }
}
