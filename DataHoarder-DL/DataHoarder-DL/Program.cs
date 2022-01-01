using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataHoarder_DL.Controllers;

namespace DataHoarder_DL
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormController formController = new FormController();
            formController.Preload();
            if (!Globals.Settings.DisclaimerAccepted)
            {
                if (ShowDisclaimer())
                {
                    Globals.Settings.DisclaimerAccepted = true;
                    Globals.Settings.Save();
                    formController.ShowMainUI();
                }
            }
            else
            {
                formController.ShowMainUI();
            }
        }
        static bool ShowDisclaimer()
        {
            string DiscalimerBody = "Warning:\n\nThis software allow scraping various social media and video hosting services.\nThis may or may not be legal in your area, and could result in your IP or account for these services being terminated.\n\nThe developers of this software accept no responsibility for any undesirable outcomes that may result from use of this application.";
            string BetaWarning = "Note:\n\nThis is prerelease software. Your scraped data may be deleted randomly without warning. Always keep a backup.";
            string Prompt = "This message will only be displayed once, would you like to continue?";
            DialogResult result = MessageBox.Show(DiscalimerBody + "\n\n\n" + BetaWarning + "\n\n\n" + Prompt, "Disclaimer", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                return true;
            else
                Environment.Exit(0);
            return false;
        }
    }
}
