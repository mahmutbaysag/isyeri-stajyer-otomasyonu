using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace İşyeri_Stajyer_Otomasyonu_SP_
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form5());
            Application.Run(new Form1());
        }
    }
}
