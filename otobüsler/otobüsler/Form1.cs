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

namespace otobüsler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Batuhan\\Desktop\\Documents\\Veri Tabanı\\otobüsler.accdb");
        
        private void görüntüleme()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();          
            komut.Connection = baglanti;
            komut.CommandText=("select * from otobusler1");

            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem lst = new ListViewItem();
                lst.Text = oku["plaka"].ToString();
                //lst.SubItems.Add(oku["otobustur"].ToString());
                //lst.SubItems.Add(oku["başyeri"].ToString());
                //lst.SubItems.Add(oku["bityeri"].ToString());
                //lst.SubItems.Add(oku["saat"].ToString());
                //lst.SubItems.Add(oku["tarih"].ToString());

                listView1.Items.Add(lst);
            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            görüntüleme();
            
        }
        
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenikişi y = new yenikişi();
            if (y.ShowDialog()==DialogResult.OK)
            {
                listView1.Refresh();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *,sıra from otobusler1");
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            yenikişi y = new yenikişi();
            while (oku.Read())
            {
                y.textBox1.Text = oku["plaka"].ToString();
                y.textBox2.Text = oku["otobustur"].ToString();
                y.textBox3.Text = oku["başyeri"].ToString();
                y.textBox4.Text = oku["bityeri"].ToString();
                y.textBox5.Text = oku["saat"].ToString();
                y.dateTimePicker1.Text = oku["tarih"].ToString();  
                              
            }
            y.ShowDialog();
            baglanti.Close();

        }
    }
}
