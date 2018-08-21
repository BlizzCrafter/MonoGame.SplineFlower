using MonoGame.SplineFlower.Samples;
using System;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplineForm());
        }
    }
}
