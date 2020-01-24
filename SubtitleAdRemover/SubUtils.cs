using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;



namespace SubtitleAdRemover
{
    class SubUtils
    {
        public static void BrowseForFiles()
        {

        }

        public static void LoadDirList()
        {
            XElement xElement = XElement.Load("saves.xml");
            {
                foreach (XElement xEle in xElement.Descendants("save_path"))
                {
                    listBox3.Items.Add((string)xEle);
                }
            }
        }

        public static void DeleteItemFromDirList()
        {
            //ingen exceptions, så programmet "crasher" hvis man ikke har valgt en fil først! :-)
            string curItem = listBox3.SelectedItem.ToString();
            listBox3.Items.Remove(curItem);
        }


        public static void LoadSubtitleList()
        {

        }

        public static void SearchForAds()
        {

        }

        public static void RemoveLinesAndSave()
        {

        }


    }
}
