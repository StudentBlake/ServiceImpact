using System;
using System.Threading;
using System.Windows.Forms;

namespace ServiceImpact
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Mutex mutex = new Mutex(false, "ServiceImpactMutex");
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new TrayLogic());
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                }
            }
        }
    }
}