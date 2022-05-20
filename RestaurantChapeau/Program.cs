using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantChapeau
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            if (args.Length > 0)
            {
                if (args[0] == "debugui")
                {
                    Application.Run(new Form1());
                }
            }
            else
            {
                Application.Run(new LoginForm());
            }
#else
            Application.Run(new LoginForm());
#endif
        }
    }
}
