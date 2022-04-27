using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DataHoarder_DL.Models.Instagram;

namespace DataHoarder_DL
{
    public partial class BrowserUI : Form
    {
        public BrowserUI()
        {
            InitializeComponent();
        }
        List<IGData> InstagramData { get; set; } = new List<IGData>();
        ImageList IGImageList { get; set; } = new ImageList();
        private void BrowserUI_Load(object sender, EventArgs e)
        {
            LoadAllIGMetadata();
            PopulateList();
            lsvIGImages.Refresh();
        }
        private void LoadAllIGMetadata()
        {
            foreach(UnifiedScrapeItem Item in Globals.Settings.ScrapeItems)
            {
                if (Item.ScrapeType != ScrapeType.Instagram) continue;
                IGData _data = Controllers.InstagramController.ParseIGData(Item.ItemPath + "\\metadata\\_working.json");
                if(_data != null) InstagramData.Add(_data);
            }
        }
        private void PopulateList()
        {
            foreach(IGData _data in InstagramData)
            {
                lsvIGAccts.Items.Add(_data.GraphProfileInfo.username);
            }
        }

        private void lsvIGAccts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvIGAccts.SelectedItems.Count <= 0) return;
            List<IGData> SelectedIGData = new List<IGData>();
            foreach (ListViewItem item in lsvIGAccts.SelectedItems)
            {
                SelectedIGData.Add(InstagramData.Find(x => x.GraphProfileInfo.username == item.Text));
            }
            if (SelectedIGData.Count <= 0) return;
            lsvIGImages.Items.Clear();
            IGImageList.Images.Clear();
            foreach (IGData _data in SelectedIGData)
            {
                UnifiedScrapeItem usi = Globals.Settings.ScrapeItems.Find(x => x.ShortName == _data.GraphProfileInfo.username);
                foreach (GraphImage image in _data.GraphImages)
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                    for (int urlid = 0; urlid <image.urls.Count; urlid++)
                    {
                        string fileName = usi.ItemPath + "\\media\\images\\" + dto.ToString("yyyyMMdd") + "-" + Controllers.InstagramController.URLtoName(image.urls[urlid]);
                        //TODO make thumnails so it can load videos too
                        if (fileName.EndsWith(".mp4")) continue;
                        if (File.Exists(fileName))
                        {
                            IGImageList.Images.Add(image.id + "-" + urlid.ToString(), Image.FromFile(fileName));
                            ListViewItem item = new ListViewItem()
                            {
                                ImageKey = image.id + "-" + urlid.ToString(),
                                Text= image.id + "-" + urlid.ToString()
                            };
                            lsvIGImages.Items.Add(item);
                        }
                    }
                }
            }
            IGImageList.ImageSize = new Size(256, 256);
            IGImageList.ColorDepth = ColorDepth.Depth32Bit;
            lsvIGImages.LargeImageList = IGImageList;
            lsvIGImages.Refresh();
        }

    }
}
