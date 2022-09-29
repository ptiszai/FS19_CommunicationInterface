/*
    Communication Interface windows App for FS19
    @author:    Tiszai Istvan(tiszaii@hotmail.com)
    @history:	2022 - 09 - 30
*/

using System;
using System.Windows.Forms;

namespace CommunicationInterface
{
    static class Program
    {
        static public readonly string DRIVER = "r:\\";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
