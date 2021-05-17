using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataHoarder_DL
{
    public partial class Preloader : Form
    {
        public Preloader()
        {
            InitializeComponent();
        }

        private void Preloader_Load(object sender, EventArgs e)
        {
            //LoadThings
            CheckUpdates();
            LoadModules();
            this.Close();

        }
        private void LoadModules()
        {
            //load module info from jsons
        }
        private void CheckUpdates()
        {
            //UpdateModules();
        }
    }
}
