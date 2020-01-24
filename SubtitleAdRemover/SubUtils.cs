using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
