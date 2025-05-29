using System;
using System.Windows.Forms;
using SpotDifferenceGame.UI;


namespace SpotDifferenceGame
{
    class Program
    {
        //Single Threaded Apartment (STA) وهو ضروري للتعامل مع واجهة المستخدم (UI) بشكل سليم،
        [STAThread]
        static void Main()
        {
            //يفعل نمط الواجهة الحديثة لنظام ويندوز، بحيث يظهر التطبيق بشكل أكثر أناقة 
            Application.EnableVisualStyles();
            //محرك النص القديم أو الجديد.
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
