using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataHoarder_DL.Controllers
{
    class FormController
    {
        public void Preload()
        {
            Preloader preloaderForm = new Preloader();
            preloaderForm.ShowDialog();
        }
        public void ShowMainUI()
        {
            //DownloaderUI downloaderForm = new DownloaderUI();
            //downloaderForm.Show();
            Application.Run(new DownloaderUI());
        }
    }
}
