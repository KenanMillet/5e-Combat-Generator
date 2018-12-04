using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace DNDAPI
{
    public partial class FormMain : Form
    {
        private const string baseURL = "https://api-beta.open5e.com/";
        private const string monsterUrl = "monsters";
        private const string itemsUrl = "magicitems";

        Compendium compendium;

        Random rand = new Random();

        WebClient client = new WebClient();

        Encounter encounter = new Encounter();

        float largeFontSize = 16;
        float normalFontSize = 14;
        float smallFontSize = 8;
        Color titleColor = Color.FromArgb(155, 40, 24);
        Color smallColor = Color.Gray;
        Color normalColor = Color.Black;

        public FormMain()
        {
            InitializeComponent();
            
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            //DECLARING VARIABLEs
            int pcTotal = 0;
            int pcLevel = 0;

            int[] difficulty = new int[0];

            BoxOutput.Clear();//clear textbox

            bool inputError = false;
            List<string> RestrictedTypes = new List<string>(BoxRestrictedTypes.Text.Split(','));

            if (compendium == null)
            {
                generateCompendium();
            }
            // INPUT VALIDATION AND VARIABLE POPULATION
            if (MaskedTextBoxNumber.Text != "" && MaskedTextBoxLevel.Text != "")
            {
                pcTotal = Convert.ToInt32(MaskedTextBoxNumber.Text);//Normally scary, but this is from a masked text box
                pcLevel = Convert.ToInt32(MaskedTextBoxLevel.Text);

                if (pcTotal < 1 && pcLevel < 1)
                {
                    BoxOutput.Text += "Both textfields must be equal to or greater than 1.";
                    inputError = true;
                }
            } 
            else
            {
                BoxOutput.Text += "Both textfields must have an entry.";//clear textbox
                inputError = true;
            }

            if (RadioButtonEasy.Checked)//easier to set this now than to reference it later longer, every time
            {
                difficulty = compendium.DifficultyValues[0];
            }
            else if (RadioButtonMedium.Checked)
            {
                difficulty = compendium.DifficultyValues[1];
            }
            else if (RadioButtonHard.Checked)
            {
                difficulty = compendium.DifficultyValues[2];
            }
            else if (RadioButtonDeadly.Checked)
            {
                difficulty = compendium.DifficultyValues[3];
            }
            else
            {
                BoxOutput.Text +=  "A difficulty must be selected.";
                inputError = true;
            }
            if(BoxSameChance.Text == "")
            {
                BoxSameChance.Text = "0";
            }
            //GET INFO FROM API
            if (inputError == false)
            {
                for(int i = 0; i < RestrictedTypes.Count; i++)
                {
                    RestrictedTypes[i] = RestrictedTypes[i].Trim(' ');
                }
                encounter = new Encounter(pcTotal, pcLevel, difficulty, Convert.ToInt32(BoxSameChance.Text), CheckBoxCohesion.Checked , RestrictedTypes, compendium);
                PrintEncounter(encounter);
                //foreach (Monster m in compendium.FullMonsterList)
                //{
                //    PrintMonster(m);
                //}
                //foreach (Item i in compendium.FullItemList)
                //{
                //    PrintItem(i);
                //}
            }
        }

        private string FetchData(string URL, int numPages)
        {
            //string data = "";

            //for (int i = 1; i < numPages + 1; i++)//pages on the site begin at 1, not 0.
            //{
            //    data += client.DownloadString(baseURL + monsterUrl + "?page=" + i + "&format=json");
            //}
            //System.Diagnostics.Debug.WriteLine("Data List: " + data);
            //return data;
            //THANK YOU BERYL
    
            string data = "[";

            for (int i = 1; i < numPages + 1; i++)//pages on the site begin at 1, not 0.
            {
                string page = client.DownloadString(URL + "?page=" + i + "&format=json");

                data += page.Remove(0, page.IndexOf("results") + 10).TrimEnd('}').TrimEnd(']') + ",";


            }
            System.Diagnostics.Debug.WriteLine("Data List: " + data);
            return data.TrimEnd(',') + "]";
        }

        private void PrintMonster(Monster m)
        {
            ToggleTitle(true);
            BoxOutput.AppendText(m.GetTitle());
            ToggleTitle(false);
            ToggleSmallText(true);
            BoxOutput.AppendText(m.GetSubTitle());
            ToggleSmallText(false);
            BoxOutput.AppendText(m.GetNormalText());
            ToggleSmallText(true);
            BoxOutput.AppendText(m.GetEndNote());
            ToggleSmallText(false);
        }

        private void PrintItem(Item i)
        {
            ToggleTitle(true);
            BoxOutput.AppendText(i.GetTitle());
            ToggleTitle(false);
            ToggleSmallText(true);
            BoxOutput.AppendText(i.GetSubTitle());
            ToggleSmallText(false);
            BoxOutput.AppendText(i.GetNormalText());
            ToggleSmallText(true);
            BoxOutput.AppendText(i.GetEndNote());
            ToggleSmallText(false);
        }

        private void ToggleTitle(bool state)
        {
            if (BoxOutput.SelectionFont != null)
            {
                float selectionSize;
                Font currentFont = BoxOutput.SelectionFont;
                FontStyle newFontStyle;

                if (state == true)
                {
                    selectionSize = largeFontSize;

                    newFontStyle = FontStyle.Underline;
                    BoxOutput.SelectionColor = titleColor;
                }
                else
                {
                    selectionSize = normalFontSize;
                    newFontStyle = FontStyle.Regular;
                    BoxOutput.SelectionColor = normalColor;
                }   

            BoxOutput.SelectionFont = new Font(currentFont.FontFamily, selectionSize, newFontStyle);
            }
          else
                {
                    System.Diagnostics.Debug.WriteLine("SelectionFont is Null--does it have more than two styles?");
                }
            }

        private void ToggleSmallText(bool state)
        {
            if (BoxOutput.SelectionFont != null)
            {
                float selectionSize;
                Font currentFont = BoxOutput.SelectionFont;

                if (state == true)
                {
                    selectionSize = smallFontSize;
                    BoxOutput.SelectionColor = smallColor;
                }
                else
                {
                    selectionSize = normalFontSize;
                    BoxOutput.SelectionColor = normalColor;
                }

                BoxOutput.SelectionFont = new Font(currentFont.FontFamily, selectionSize);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("SelectionFont is Null--does it have more than two styles?");
            }
        }

        private void MaskedTextBoxNumber_Click(object sender, EventArgs e)
        {
            MaskedTextBoxNumber.Focus();
            MaskedTextBoxNumber.Select(0, 0);
        }

        private void MaskedTextBoxLevel_Click(object sender, EventArgs e)
        {
            MaskedTextBoxLevel.Focus();
            MaskedTextBoxLevel.Select(0, 0);
        }

        private void BoxSameChance_Click(object sender, EventArgs e)
        {
            BoxSameChance.Focus();
            BoxSameChance.Select(0, 0);
        }

        private void generateCompendium()
        {
            string monsterData;
            string itemData;

            List<MonsterData> monsterDataList = new List<MonsterData>();
            List<ItemData> itemDataList = new List<ItemData>();

            Monster mstr;
            Item itm;

            List<Monster> monsterList = new List<Monster>();
            List<Item> itemList = new List<Item>();


            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            monsterData = FetchData(baseURL + monsterUrl, 7);
            itemData = FetchData(baseURL + itemsUrl, 5);
            monsterDataList = new JavaScriptSerializer().Deserialize<List<MonsterData>>(monsterData);
            System.Diagnostics.Debug.WriteLine("monsterList: " + monsterDataList.Count + " items");
            System.Diagnostics.Debug.WriteLine("Example" + monsterDataList[rand.Next(monsterDataList.Count - 1)].ToString());
            itemDataList = new JavaScriptSerializer().Deserialize<List<ItemData>>(itemData);
            System.Diagnostics.Debug.WriteLine("itemList: " + itemDataList.Count + "items");
            System.Diagnostics.Debug.WriteLine("Example" + itemDataList[rand.Next(itemDataList.Count - 1)].ToString());

            for (int i = 0; i < monsterDataList.Count; i++)
            {
                mstr = new Monster(monsterDataList[i]);
                monsterList.Add(mstr);
            }
            for (int i = 0; i < itemDataList.Count; i++)
            {
                itm = new Item(itemDataList[i]);
                itemList.Add(itm);
            }
            compendium = new Compendium(monsterList, itemList);
        }

        private void PrintEncounter(Encounter encounter)
        {
            BoxOutput.AppendText(encounter.getGeneralData());
            foreach(Monster m in encounter.ChosenMonsters)
            {
                PrintMonster(m);
            }
            foreach (Item i in encounter.ChosenItems)
            {
                PrintItem(i);
            }
        }

    }
}
