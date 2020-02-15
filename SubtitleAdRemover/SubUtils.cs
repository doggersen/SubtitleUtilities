using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;



namespace SubtitleAdRemover
{


    //can't access the form1 from this class easily. Unless i set the form1 to public, but that doesn't seem to be good practise. 
    //best solution is to use an interface, so this class is completely decoupled from the form1-code. 
    //next-best solution is to get access through a property, read more about it all here: https://stackoverflow.com/questions/5646954/how-to-access-winform-textbox-control-from-another-class
    // until then, i will just use the easy solution and put these methods directly in the form1 class.
    class SubUtils
    {
        public static void BrowseForFiles()
        {

        }

        public static void LoadDirList()
        {
      
        }

        public void DeleteItemFromDirList()
        {
           
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
