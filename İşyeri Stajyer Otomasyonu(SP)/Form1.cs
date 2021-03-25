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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        

        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            metroTextBox1.Focus();


        }
        int sayac = 0;
        private void MetroButton2_Click(object sender, EventArgs e)
        {

            

            //parola kontrol
            StreamReader sr = new StreamReader(@"PASS-OTO.txt");
            string pasget = sr.ReadLine();
            sr.Close();

            string ıd, pass; int plusloc;
            plusloc = pasget.IndexOf("+");
            ıd = pasget.Substring(0, plusloc);
            pass = pasget.Substring(plusloc + 1);
            if (metroTextBox1.Text == ıd)
            {
                if (metroTextBox2.Text == pass)
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    metroLabel4.Visible = true;
                    metroTextBox2.Text = "";
                    sayac++;
                }
            }
            else
            {
                metroLabel4.Visible = true;
                metroTextBox2.Text = "";
                sayac++;
            }

            if (sayac == 1) { metroLabel5.Text = "2(İki) Deneme Hakkınız Kaldı!"; metroLabel5.Style = MetroFramework.MetroColorStyle.Yellow; }
            if (sayac == 2) { metroLabel5.Text = "1(Bir) Deneme Hakkınız Kaldı!"; metroLabel5.Style = MetroFramework.MetroColorStyle.Red; }

            if (sayac == 3)
            {
                metroLabel5.Text = "Deneme Hakkınız Bitti!"; metroLabel5.Style = MetroFramework.MetroColorStyle.Red;
                MessageBox.Show("Deneme Hakkınız Doldu. Parolanızı Hatırlamıyorsanız Lütfen Yazılım Yöneticisine Başvurun.");
                this.Close();
            }

        }

        private void MetroButton3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void MetroTextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void MetroTextBox2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void MetroButton4_Click(object sender, EventArgs e)
        {

        }

        private void MetroButton4_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void MetroButton4_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void MetroButton4_MouseDown(object sender, MouseEventArgs e)
        {
            metroTextBox2.UseSystemPasswordChar = false;
        }

        private void MetroButton4_MouseUp(object sender, MouseEventArgs e)
        {
            metroTextBox2.UseSystemPasswordChar = true;
        }
    }
}
