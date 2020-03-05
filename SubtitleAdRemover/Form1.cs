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
            LoadListFromXML("saveDirList.xml");
            LoadListFromXMLSearchWords("saveSearchList.xml");
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
            SaveListToXML("saveDirList.xml");
        }


        
        private void LoadListFromXMLSearchWords(string loadFileName)
            {
                XElement xElement = XElement.Load(loadFileName);
                {
                    foreach (XElement xEle in xElement.Descendants("save_path"))
                    {
                        listBoxSearchWords.Items.Add((string)xEle);
                    }
                }
                //selects first item in listbox as default
                if (this.listBoxSearchWords.Items.Count > 0)
                {
                    this.listBoxSearchWords.SelectedIndex = 0;
                }
            }

        /// <summary>
        /// this method loads a a list from a XML-file (OBS: it requires a "save_path"-element in the xml-file, so it can't be used with any xml-file)
        /// </summary>
        /// <param name="loadFileName">the name of the file to load</param>
        private void LoadListFromXML(string loadFileName)
        {
            XElement xElement = XElement.Load(loadFileName);
            {
                foreach (XElement xEle in xElement.Descendants("save_path"))
                {
                    listBoxDirectory.Items.Add((string)xEle);
                }
            }
            //selects first item in listbox as default
            if (this.listBoxDirectory.Items.Count > 0)
            { 
                this.listBoxDirectory.SelectedIndex = 0;
            }
            
            LoadSubtitleList();
        }


        //virker delvist, den sletter det markerede, men så crasher den. 
        private void DeleteItemFromDirList()
        {
            //ingen exceptions, så programmet "crasher" hvis man ikke har valgt en fil først! :-)
            string curItem = listBoxDirectory.SelectedItem.ToString();
            listBoxDirectory.Items.Remove(curItem);
        }

        private void SaveListToXML(string saveFileName)
        {
            XDocument doc = new XDocument(

          new XElement("saves", listBoxDirectory.Items
         .OfType<string>()
         .Select(item => new XElement("save_path", item))));
            doc.Save(saveFileName);
            //doc.Save("saves.xml");
        }


        private void checkIfListItemSelected (ListBox listBox)
        {
            //if ($"this.{listBox}.Items.Count > 0)
               this.listBoxSubtitles.SelectedIndex = 0;
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

        private string CombinePathWithFilename()
        {
            string curPath = listBoxDirectory.SelectedItem.ToString();
            string curItem = listBoxSubtitles.SelectedItem.ToString();
            string[] paths = { curPath, curItem };
            string fullPath = Path.Combine(paths);

            return fullPath;
            
        }

        private void ShowAdWordMatches()
        {
            if (this.listBoxSubtitles.Items.Count > 0)
            {

             
                string content = File.ReadAllText(CombinePathWithFilename());

                string searchWord = listBoxSearchWords.SelectedItem.ToString();
                textBoxShowMatches.Text = ""; //start by clearing the textBox

                string reg = @"(?<=\d\d:\d\d:\d\d,\d\d\d --> \d\d:\d\d:\d\d,\d\d\d)(\r\n.*{0}.*\n.*)(?=)";
                string newString = String.Format(reg, searchWord);
                Regex regex = new Regex(newString, RegexOptions.IgnoreCase);

                foreach (Match myMatch in regex.Matches(content))
                {
                    //works without this line, but is it a good exception-handler of some kind? //if (myMatch.Success)
                    textBoxShowMatches.Text += myMatch.Value + Environment.NewLine;
                }

            }
 
        }

        private void RemoveMatchingLines()
        {
            
            string content = File.ReadAllText(CombinePathWithFilename());

            Regex regex = new Regex(@"(?<=\d\d:\d\d:\d\d,\d\d\d --> \d\d:\d\d:\d\d,\d\d\d)(\r\n.*subtitles.*\n.*)(?=)", RegexOptions.IgnoreCase);
            string strReplace = @"";
            string testReplace = regex.Replace(content, strReplace);

            
        }

        private void SaveChangesToSubtitleFile()
        {
            //textBoxShowMatches.Text = testReplace;
            //File.WriteAllText(fullPath + "NewFile(with_lines_removed).srt", testReplace);
        }


        private void listBoxDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxShowMatches.Text = ""; //clears the box first, so it shows matches when there is currently a subtitle selected. 
            LoadSubtitleList();
        }

        private void listBoxSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ShowAdWordMatches();
        }

        private void listBoxDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteItemFromDirList();
            }
        }

        private void listBoxSearchWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAdWordMatches();
        }
    }
}
