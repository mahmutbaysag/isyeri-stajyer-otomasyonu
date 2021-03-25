using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace İşyeri_Stajyer_Otomasyonu_SP_
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        DataSet verikümesi;

        string ıd;
        int updatesayac = 0;  bool updatecontrol = false;
        int addsayac = 0;    bool addcontrol = false;
        int dellsayac = 0;   bool dellcontrol = false;

        public Form2()
        {
            InitializeComponent(); 
        }

        void veridoldur()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=İso.accdb");
            adaptor = new OleDbDataAdapter("Select * from bilgiler", baglanti);
            verikümesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikümesi, "bilgiler");
            metroGrid1.DataSource = verikümesi.Tables["bilgiler"];
            baglanti.Close();
        }

        private void MetroLabel3_Click(object sender, EventArgs e)
        {
        }

        private void MetroButton4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void MetroButton5_Click(object sender, EventArgs e)
        {
            string c = "";
            metroTextBox1.Text = c;
            metroTextBox2.Text = c;
            metroTextBox3.Text = c;
            metroTextBox5.Text = c;
            metroComboBox1.Text = c;
            
            metroLabel7.Focus();
        }

        private void MetroButton6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            veridoldur();

            string clr = "";
            metroTextBox1.Text = clr;
            metroTextBox2.Text = clr;
            metroTextBox3.Text = clr;
            metroComboBox1.Text = clr;
            metroTextBox5.Text = "0";
            metroLabel7.Focus();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        { 
        }

        private void MetroButton7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (dellsayac == updatesayac)
            {
                addsayac++;
                if (addsayac == 1)
                {
                    metroButton1.BackColor = MetroFramework.MetroColors.Green;
                    metroLabel6.Visible = true;
                    metroButton9.Visible = true;
                    addcontrol = true;
                    DialogResult msj = MetroFramework.MetroMessageBox.Show(this, "Lütfen Yeni Stajyer Bilgilerini Girdikten Sonra Ekle Butonuna Basın", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    metroTextBox1.Focus();
                    
                }else if(addsayac == 2)
                {
                    metroButton1.BackColor = Color.Transparent;
                    addsayac = 0;
                    metroLabel6.Visible = false;
                    metroButton9.Visible = false;
                    addcontrol = false;
                    metroLabel7.Focus();
                }
            }
            else
            {
                DialogResult mj = MetroFramework.MetroMessageBox.Show(this, "Şu anda Başka Bir Mod Açık Durumda Lütfen Diğer Modu Kapatıp Tekrar Deneyin!", "İşlem Tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                metroTextBox1.Focus();
            }
        }

        private void MetroGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        
        private void MetroButton3_Click(object sender, EventArgs e)
        {
            if (addsayac == dellsayac)
            {
                updatesayac++;
                 if (updatesayac == 1)
                 {
                    metroButton3.BackColor = MetroFramework.MetroColors.Green;
                    metroLabel10.Visible = true;
                    metroButton8.Visible = true;
                    updatecontrol = true;
                    
                    DialogResult msj; msj = MetroFramework.MetroMessageBox.Show(this, "Lütfen Bilgilerini Güncellemek İstediğiniz Kişiyi Seçip Yeni Bilgilerini Ekleyin ve Güncelle Butonuna Basın.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metroTextBox1.Focus();
                }
                else if (updatesayac == 2)
                 {
                    metroButton3.BackColor = Color.Transparent;
                    updatesayac = 0;
                    metroLabel10.Visible = false;
                    metroButton8.Visible = false;
                    updatecontrol = false;
                    metroLabel7.Focus();
                }
            }
            else
            {
                DialogResult msj = MetroFramework.MetroMessageBox.Show(this, "Şu anda Başka Bir Mod Açık Durumda Lütfen Diğer Modu Kapatıp Tekrar Deneyin!", "İşlem Tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                metroTextBox1.Focus();
            }   
        }

        private void MetroButton8_Click(object sender, EventArgs e)
        {
            if (updatecontrol == true)
            {
                if ((((((metroTextBox1.Text == null) || (metroTextBox2.Text == null)) || (metroTextBox3.Text == null)) || (metroTextBox5.Text == null)) || (metroComboBox1.Text == null)))
                {
                    DialogResult m = MetroFramework.MetroMessageBox.Show(this, "Lütfen Tüm Bilgileri Giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    string sorgu = "Update bilgiler Set ad=@ad,soyad=@soyad,yaş=@yaş,sınıf=@sınıf,telefon=@telefon,başlangıç=@başlangıç,bitiş=@bitiş Where ıd=@ıd";
                    komut = new OleDbCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@ad", metroTextBox1.Text);
                    komut.Parameters.AddWithValue("@soyad", metroTextBox2.Text);
                    komut.Parameters.AddWithValue("@yaş", Convert.ToInt32(metroTextBox3.Text));
                    komut.Parameters.AddWithValue("@sınıf", Convert.ToString(metroComboBox1.Text));
                    komut.Parameters.AddWithValue("@telefon", Convert.ToString(metroTextBox5.Text));
                    komut.Parameters.AddWithValue("@başlangıç", Convert.ToString(metroDateTime1.Text));
                    komut.Parameters.AddWithValue("@bitiş", Convert.ToString(metroDateTime2.Text));
                    komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(ıd));
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    veridoldur();

                    DialogResult msj = MetroFramework.MetroMessageBox.Show(this, "Stajyer Bilgileri Güncellendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string c = "";
                    metroTextBox1.Text = c;
                    metroTextBox2.Text = c;
                    metroTextBox3.Text = c;
                    metroTextBox5.Text = c;
                    metroComboBox1.Text = c;

                    metroLabel7.Focus();
                }

                               
            }
        }

        private void MetroButton9_Click(object sender, EventArgs e)
        {


            if (addcontrol == true)
            {

                if ((((((metroTextBox1.Text == null) || (metroTextBox2.Text == null)) || (metroTextBox3.Text == null)) || (metroTextBox5.Text == null)) || (metroComboBox1.Text == null))){
                    DialogResult m = MetroFramework.MetroMessageBox.Show(this, "Lütfen Tüm Bilgileri Giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    komut = new OleDbCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into bilgiler (ad, soyad, yaş, sınıf, telefon, başlangıç, bitiş) values(@pad, @psoyad, @pyaş, @psınıf, @ptelefon, @pbaşlangıç, @pbitiş)";

                    komut.Parameters.AddWithValue("@pad", metroTextBox1.Text);
                    komut.Parameters.AddWithValue("@psoyad", metroTextBox2.Text);
                    komut.Parameters.AddWithValue("@pyaş", Convert.ToInt32(metroTextBox3.Text));
                    komut.Parameters.AddWithValue("@psınıf", Convert.ToString(metroComboBox1.Text));
                    komut.Parameters.AddWithValue("@ptelefon", Convert.ToString(metroTextBox5.Text));
                    komut.Parameters.AddWithValue("@pbaşlangıç", Convert.ToString(metroDateTime1.Text));
                    komut.Parameters.AddWithValue("@pbitiş", Convert.ToString(metroDateTime2.Text));

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    veridoldur();
                    DialogResult msj;
                    msj = MetroFramework.MetroMessageBox.Show(this, "Yeni Stajyer Eklendi.", "İşlem Başarıyla Gerçekleştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string c = "";
                    metroTextBox1.Text = c;
                    metroTextBox2.Text = c;
                    metroTextBox3.Text = c;
                    metroTextBox5.Text = c;
                    metroComboBox1.Text = c;

                    metroLabel7.Focus();
                }

                
            }
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            if (addsayac == updatesayac)
            {
                dellsayac++;
                if (dellsayac == 1)
                {
                    metroButton2.BackColor = MetroFramework.MetroColors.Green;
                    metroLabel11.Visible = true;
                    metroButton10.Visible = true;
                    dellcontrol = true;
                    DialogResult msj; msj = MetroFramework.MetroMessageBox.Show(this, "Lütfen Bilgilerini Silmek İstediğiniz Stajyeri Seçin ve Kaldır Butonuna Basın.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metroGrid1.Focus();
                }else if (dellsayac == 2)
                {
                    metroButton2.BackColor = Color.Transparent;
                    dellsayac = 0;
                    metroLabel11.Visible = false;
                    metroButton10.Visible = false;
                    dellcontrol = false;
                    metroLabel7.Focus();
                }
            }
            else
            {
                DialogResult msj = MetroFramework.MetroMessageBox.Show(this, "Şu anda Başka Bir Mod Açık Durumda Lütfen Diğer Modu Kapatıp Tekrar Deneyin!", "İşlem Tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                metroGrid1.Focus();
            }
        }

        private void MetroButton10_Click(object sender, EventArgs e)
        {
            if (dellcontrol == true)
            {
                string sorgu = "Delete From bilgiler Where ıd=@no";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@no", metroGrid1.CurrentRow.Cells[0].Value);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                veridoldur();

                DialogResult msj = MetroFramework.MetroMessageBox.Show(this, "Stajyer Kaldırıldı.", "İşlem Başarıyla Gerçekleştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string c = "";
                metroTextBox1.Text = c;
                metroTextBox2.Text = c;
                metroTextBox3.Text = c;
                metroTextBox5.Text = c;
                metroComboBox1.Text = c;

                metroLabel7.Focus();
            }
        }

        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MetroGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            metroTextBox1.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox2.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            metroTextBox3.Text = metroGrid1.CurrentRow.Cells[3].Value.ToString();
            metroComboBox1.Text = metroGrid1.CurrentRow.Cells[4].Value.ToString();
            metroTextBox5.Text = metroGrid1.CurrentRow.Cells[5].Value.ToString();
            metroDateTime1.Text = metroGrid1.CurrentRow.Cells[6].Value.ToString();
            metroDateTime2.Text = metroGrid1.CurrentRow.Cells[7].Value.ToString();
            ıd = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            
        }
    }
}
