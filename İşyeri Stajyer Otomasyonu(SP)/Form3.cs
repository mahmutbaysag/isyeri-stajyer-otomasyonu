using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace İşyeri_Stajyer_Otomasyonu_SP_
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            
        }
        int nullsayacı = 0;
        private void MetroButton3_Click(object sender, EventArgs e)
        {
            if (nullsayacı >= 1)
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }else
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
            }
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            bool ok = false;
            nullsayacı++;
            StreamReader sr = new StreamReader(@"PASS-OTO.txt");
            string pasget = sr.ReadToEnd(); sr.Close();
            int plusloc; string ıd;
            plusloc = pasget.IndexOf("+");
            ıd = pasget.Substring(0, plusloc);
            if(metroTextBox6.Text==ıd)
            {
                metroLabel9.Visible = false;
                if (metroTextBox5.Text == metroTextBox4.Text)
                {
                    metroLabel10.Visible = false;
                    ok = true;
                }else if(metroTextBox5.Text != metroTextBox4.Text)
                {
                    metroLabel10.Visible = true;
                    metroTextBox5.Focus();
                }
            }
            else
            {
                metroLabel9.Visible = true;
                metroLabel11.Visible = false;
                metroTextBox6.Focus();
            }

            if(ok == true)
            {
                StreamWriter sw = new StreamWriter(@"PASS-OTO.txt");
                string newıd = metroTextBox5.Text + pasget.Substring(plusloc);
                sw.Write(newıd);
                sw.Close();
                DialogResult msj;
                msj = MetroFramework.MetroMessageBox.Show(this, "Kullanıcı Adı Güncellendi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroLabel11.Visible = true;
            }
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            nullsayacı++;
            bool ok = false;
            StreamReader sr = new StreamReader(@"PASS-OTO.txt");
            string pasget = sr.ReadToEnd(); sr.Close();
            int plusloc = pasget.IndexOf("+");
            string pass = pasget.Substring(plusloc+1);
            if(metroTextBox1.Text==pass)
            {
                metroLabel12.Visible = false;
                if (metroTextBox2.Text == metroTextBox3.Text)
                {
                    metroLabel14.Visible = false;
                    metroLabel13.Visible = false;
                    ok = true;
                }else if(metroTextBox3.Text != metroTextBox2.Text)
                {
                    metroLabel13.Visible = true;
                    metroTextBox2.Focus();
                }
            }else if(metroTextBox1.Text != pass)
            {
                metroLabel12.Visible = true;
                metroLabel14.Visible = false;
                metroTextBox1.Focus();

            }

            if(ok == true)
            {
                string newpass = pasget.Substring(0, plusloc) +"+"+ metroTextBox2.Text;
                StreamWriter sw = new StreamWriter(@"PASS-OTO.txt");
                sw.Write(newpass); sw.Close();
                metroLabel14.Visible = true;
                DialogResult msj;
                msj = MetroFramework.MetroMessageBox.Show(this, "Parola Güncellendi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MetroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void MetroButton4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
