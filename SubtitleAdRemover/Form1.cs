using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace SubtitleAdRemover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDirList();

        }

        private void buttonBrowseForSubDir_Click(object sender, EventArgs e)
        {
            BrowseForSubDir();
        }

        private void BrowseForSubDir()
        {
            if (folderBrowserDialogSubtitleDirectory.ShowDialog() == DialogResult.OK)
            {
                listBoxDirectory.Items.Add(folderBrowserDialogSubtitleDirectory.SelectedPath);
            }
            SaveDirListToXML();
        }



        public static void BrowseForFiles()
        {

        }

        private void LoadDirList()
        {
            XElement xElement = XElement.Load("saves.xml");
            {
                foreach (XElement xEle in xElement.Descendants("save_path"))
                {
                    listBoxDirectory.Items.Add((string)xEle);
                }
            }
            //selects first item in listbox as default
            if (this.listBoxDirectory.Items.Count > 0)
                this.listBoxDirectory.SelectedIndex = 0;
            
            LoadSubtitleList();
        }

        private void DeleteItemFromDirList()
        {
            //ingen exceptions, så programmet "crasher" hvis man ikke har valgt en fil først! :-)
            string curItem = listBoxDirectory.SelectedItem.ToString();
            listBoxDirectory.Items.Remove(curItem);
        }

        private void SaveDirListToXML()
        {
            XDocument doc = new XDocument(

          new XElement("saves", listBoxDirectory.Items
         .OfType<string>()
         .Select(item => new XElement("save_path", item))));
            doc.Save("saves.xml");

        }

        private void LoadSubtitleList()
        {

            try
            {
                listBoxSubtitles.Items.Clear();
                string curItem = listBoxDirectory.SelectedItem.ToString();

                DirectoryInfo dInfo = new DirectoryInfo(curItem);
                FileInfo[] files = dInfo.GetFiles("*.srt");
                foreach (FileInfo file in files)
                {
                    listBoxSubtitles.Items.Add(file.Name);
                }
                //selects first item in listbox as default
                if (this.listBoxSubtitles.Items.Count > 0)
                    this.listBoxSubtitles.SelectedIndex = 0;
                ShowAdWordMatches();
            }

            catch (DirectoryNotFoundException dirEx)
            {
                // Let the user know that the directory did not exist.
                Console.WriteLine("Directory not found: " + dirEx.Message);

            }
        }

        public static void SearchForAds()
        {

        }

        private void ShowAdWordMatches()
        {
            string curPath = listBoxDirectory.SelectedItem.ToString();
            string curItem = listBoxSubtitles.SelectedItem.ToString();
            string[] paths = { curPath, curItem };
            string fullPath = Path.Combine(paths);
            string content = File.ReadAllText(fullPath);

            textBoxShowMatches.Text = ""; //start by clearing the textBox
            Regex regex = new Regex(@"(?<=\d\d:\d\d:\d\d,\d\d\d --> \d\d:\d\d:\d\d,\d\d\d)(\r\n.*subtitles.*\n.*)(?=)", RegexOptions.IgnoreCase);

            foreach (Match myMatch in regex.Matches(content))
            {
                //works without this line, but is it a good exception-handler of some kind? //if (myMatch.Success)
                textBoxShowMatches.Text += myMatch.Value + Environment.NewLine;
            }
        }

        private void RemoveLinesAndSave()
        {
            string curPath = listBoxDirectory.SelectedItem.ToString();
            string curItem = listBoxSubtitles.SelectedItem.ToString();
            string[] paths = { curPath, curItem };
            string fullPath = Path.Combine(paths);
            string content = File.ReadAllText(fullPath);

            Regex regex = new Regex(@"(?<=\d\d:\d\d:\d\d,\d\d\d --> \d\d:\d\d:\d\d,\d\d\d)(\r\n.*subtitles.*\n.*)(?=)", RegexOptions.IgnoreCase);
            string strReplace = @"";
            string testReplace = regex.Replace(content, strReplace);

            textBoxShowMatches.Text = testReplace;
            File.WriteAllText(fullPath + "NewFile(with_lines_removed).srt", testReplace);
        }

        private void listBoxDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubtitleList();
        }

        private void listBoxSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAdWordMatches();
        }
    }
}
