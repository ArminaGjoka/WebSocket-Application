using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace ServerClient_Application
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form1 = new Form1();
            Form2 form2 = new Form2();

            System.Threading.Thread thread1 = new System.Threading.Thread(() => Application.Run(form1));
            System.Threading.Thread thread2 = new System.Threading.Thread(() => Application.Run(form2));

            thread1.Start();
            thread2.Start();
        }
    }
}
