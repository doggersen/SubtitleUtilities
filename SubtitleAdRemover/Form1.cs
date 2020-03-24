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

        public string replaceTextWithEmpty = @"";
        public string subtitlesMatchesRemoved = "";


        public Form1()
        {
            InitializeComponent();
            //the sequence these are loaded in matters! if LoadListFromXML is loaded first, it crashes because LoadLostFromXMLSearchWords ends up with a null-error!
            LoadListFromXMLSearchWords("saveSearchList.xml");
            LoadListFromXML("saveDirList.xml");
            
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
            LoadMovieList();
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

        private void LoadMovieList()
        {
            listBoxMovies.Items.Clear();
            string curItem = listBoxDirectory.SelectedItem.ToString();

            DirectoryInfo dInfo = new DirectoryInfo(curItem);
            FileInfo[] files = dInfo.GetFiles("*.mkv");
            foreach (FileInfo file in files)
            {
                listBoxMovies.Items.Add(file.Name);
            }
        }

        public static void SearchForAds()
        {

        }


        private string SelectedSubtitleFile()
        {
            string curPath = listBoxDirectory.SelectedItem.ToString();
            string curItem = listBoxSubtitles.SelectedItem.ToString();
            string[] paths = { curPath, curItem };
            string fullPath = Path.Combine(paths);

            return fullPath;
            
        }

        private string SelectedMovieFile()
        {
            
            string curPath = listBoxDirectory.SelectedItem.ToString();
            string curItem = listBoxMovies.SelectedItem.ToString();
            string[] paths = { curPath, Path.GetFileNameWithoutExtension(curItem) };
            string fullPath = Path.Combine(paths);

            return fullPath;
            
        }


        private void ShowAdWordMatches()
        {
            if (this.listBoxSubtitles.Items.Count > 0)
            {

             
                string content = File.ReadAllText(SelectedSubtitleFile());

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
            
            string content = File.ReadAllText(SelectedSubtitleFile());

            Regex regex = new Regex(@"(?<=\d\d:\d\d:\d\d,\d\d\d --> \d\d:\d\d:\d\d,\d\d\d)(\r\n.*subtitles.*\n.*)(?=)", RegexOptions.IgnoreCase);
            string strReplace = @"";
            subtitlesMatchesRemoved = regex.Replace(content, strReplace);

            
        }

        private void SaveChangesToSubtitleFile()
        {

            //textBoxShowMatches.Text = testReplace;
            //string fullPath = SelectedSubtitleFile();
            RemoveMatchingLines();
            if (listBoxMovies.SelectedIndex == -1)
            {
                string message = $"You haven't selected a movie name, so your subtitle file will be called: {SelectedSubtitleFile()}(with_advertising_lines_removed";
                string title = "Do you want to continue?";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(SelectedSubtitleFile() + "(with_advertising_lines_removed).srt", subtitlesMatchesRemoved);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("you selected cancel");
                }
            }
            else
            {
                string message = $"your subtitle file will be called: {SelectedMovieFile()}.srt";
                string title = "Do you want to continue?";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(SelectedMovieFile() + ".srt", subtitlesMatchesRemoved);
                }
                else
                {
                    listBoxMovies.ClearSelected();
                }
               
            }
            



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

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChangesToSubtitleFile();
        }
    }
}
