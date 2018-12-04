using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    class Encounter
    {
        Compendium compendium { get; set; }

        private Die d100 = new Die(100);

        public int[] DifficultyValues { get; set; }
        public int PCs { get; set; }
        public int PCLvls { get; set; }
        public int ChanceForSame { get; set; }
        public int BaseExp { get; set; }
        public int ExpAmt { get; set; }
        public decimal AdjExpMult { get; set; }//this is not the actual exp rewarded
        public bool SingleType { get; set; }
        public decimal GoldAmt { get; set; }
        public List<string> RestrictedTypes { get; set; }
        public List<Monster> AvailableMonsters { get; set; }
        public List<Monster> ChosenMonsters { get; set; }
        public List<Item> ChosenItems { get; set; }
        public Dictionary<ChallengeRating, int> ExpValues { get; set; }

        public Encounter()
        {
            DifficultyValues = new int[0];
            PCs = 0;
            PCLvls = 0;
            ChanceForSame = 0;
            BaseExp = 0;
            ExpAmt = 0;
            AdjExpMult = 0;
            ExpValues = new Dictionary<ChallengeRating, int>();
            GoldAmt = 0;
            RestrictedTypes = new List<string>();
            AvailableMonsters = new List<Monster>();
            ChosenMonsters = new List<Monster>();
            ChosenItems = new List<Item>();
        }

        public Encounter(int enPCs, int enPCLvls, int[] enDifficulty, int enChanceForSame, bool singleType,  List<string> restrictedTypes, Compendium newCompendium)
        {
            compendium = newCompendium;
            DifficultyValues = enDifficulty;
            PCs = enPCs;
            PCLvls = enPCLvls;
            ChanceForSame = enChanceForSame;
            ExpValues = compendium.ExpValues;
            BaseExp = DetermineBaseExp();
            RestrictedTypes = restrictedTypes;
            AvailableMonsters = compendium.getSortedMonster(RestrictedTypes);
            ChosenMonsters = PickMonsters();
            GoldAmt = DetermineGold();
            if (GoldAmt > compendium.CommonItemValueMin)
            {
                ChosenItems = FindPotentialItems(GoldAmt);
            }
            AdjExpMult = DetermineAdjustedExp();
            //while
        }

        public int DetermineBaseExp()
        {
            int expTotal = DifficultyValues[PCLvls];
            System.Diagnostics.Debug.WriteLine("expTotal = " + DifficultyValues[PCLvls]);
            expTotal *= PCs;
            System.Diagnostics.Debug.WriteLine("expTotal = " + expTotal);
            return expTotal;
        }

        private List<Monster> PickMonsters()
        {
            List<Monster> pickedMons = new List<Monster>();
            Monster chosenMonster;
            int totalExp = 0;
            Random rand = new Random();
            int monsterIndex = rand.Next(0, AvailableMonsters.Count - 1);
            chosenMonster = AvailableMonsters[monsterIndex];
            string monsterType = chosenMonster.MainType;
            while (totalExp < (BaseExp * .8))
             {
                
                if(ExpValues[chosenMonster.CR] + totalExp < BaseExp) //if the exp given according to the CR + the current exptotal is greater than the base exp of the encounter, then
                {
                    if (SingleType == true)
                    {
                        while (chosenMonster.MainType != monsterType)
                        {
                            chosenMonster = AvailableMonsters[monsterIndex];
                        }
                    }
                    else
                    {
                        BaseExp += ExpValues[chosenMonster.CR];
                        pickedMons.Add(chosenMonster);
                        if( d100.Roll(1, 0) < ChanceForSame)//if its less than the chance threshold for a different monster
                        {
                            chosenMonster = AvailableMonsters[monsterIndex];
                        }
                    }
                }
            }
            return pickedMons;
        }

        private decimal DetermineGold()
        {
            decimal copper = 0;
            Dictionary<int, Die[]> valueTable = new Dictionary<int, Die[]>();
            int rolledNum = d100.Roll(1, 0);
            int foundKey = 0;

            foreach (Monster m in ChosenMonsters)
            {
                foundKey = 0;
                if (m.CR.Total <= 4)
                {
                    valueTable = compendium.CR0_4Gold;
                    foreach(int key in valueTable.Keys)
                    {
                        if(rolledNum <= key)
                        {
                            foundKey = key;
                        }
                    }
                }
                else if (m.CR.Total <= 10)
                {
                    valueTable = compendium.CR5_10Gold;
                    foreach (int key in valueTable.Keys)
                    {
                        if (rolledNum <= key)
                        {
                            foundKey = key;
                        }
                    }
                }
                else if (m.CR.Total <= 16)
                {
                    valueTable = compendium.CR11_16Gold;
                    foreach (int key in valueTable.Keys)
                    {
                        if (rolledNum <= key)
                        {
                            foundKey = key;
                        }
                    }
                }
                else
                {
                    valueTable = compendium.CR17_Gold;
                    foreach (int key in valueTable.Keys)
                    {
                        if (rolledNum <= key)
                        {
                            foundKey = key;
                        }
                    }
                }
                if (foundKey == 0)
                {
                    foundKey = valueTable.Keys.Last();
                }
                foreach(Die d in valueTable[foundKey])
                {
                    copper += d.RollInternal(0);
                }
            }
            return copper / 100; //for gold value
        }

        private List<Item> FindPotentialItems(decimal gold)
        {
            List<Item> foundItems = new List<Item>();
            Random rand = new Random();
            int itemIndex = rand.Next(0, ChosenItems.Count - 1);
            int currentValue = 0;
            Item i = ChosenItems[itemIndex];
            while (currentValue < (GoldAmt * new decimal(0.8)))
            {
                if (currentValue + i.Value < gold) //if the exp given according to the CR + the current exptotal is greater than the base exp of the encounter, then
                {
                    foundItems.Add(i);
                    itemIndex = rand.Next(0, ChosenItems.Count - 1);
                    i = ChosenItems[itemIndex];
                }
                else
                {
                    itemIndex = rand.Next(0, ChosenItems.Count - 1);
                    i = ChosenItems[itemIndex];
                }
             }
            return foundItems;
        }

        public Item DetermineItemQuality(Item i)
        {
            Random rand = new Random();
            if (i.Rarity == "Common")
            {
                i.Value = rand.Next(compendium.CommonItemValueMin, compendium.CommonItemValueMax);

                 
                if ( i.Value > compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value > compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .4))
                {
                    i.Quality = "Fair";
                }
                else if (i.Value > compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .6))
                {
                    i.Quality = "Average";
                }
                else if (i.Value > compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "Uncommon")
            {
                if(i.Value > compendium.CommonItemValueMax + (compendium.UncommonItemValueMax* .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value > compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .4))
                {
                    i.Quality = "Fair";
                }
                else if (i.Value > compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .6))
                {
                    i.Quality = "Average";
                }
                else if (i.Value > compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "Rare")
            {
                if (i.Value > compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value > compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .4))
                {
                    i.Quality = "Fair";
                }
                else if (i.Value > compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .6))
                {
                    i.Quality = "Average";
                }
                else if (i.Value > compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "Very Rare")
            {
                if (i.Value > compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value > compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .4))
                {
                    i.Quality = "Fair";
                }
                else if (i.Value > compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .6))
                {
                    i.Quality = "Average";
                }
                else if (i.Value > compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else
            {
                i.Quality = "Legendary";
            }
            return i;
        }

        private decimal DetermineAdjustedExp()
        {
            Dictionary<int, decimal> valueTable = compendium.NumMonsterMult;
            int foundKey = 0;

            foreach (int key in valueTable.Keys)
            {
                if (ChosenMonsters.Count <= key)
                {
                    foundKey = key;
                }
            }
                if (foundKey == 0)
                {
                    foundKey = valueTable.Keys.Last();
                }
            return valueTable[foundKey];
        }

        public string getGeneralData()
        {
            return "Exp Goal: " + BaseExp + " | " + "Exp Generated: " + ExpAmt + "\n" + "Adjusted Exp Amt: " + (ExpAmt * AdjExpMult) + "\n" + "Gold Generated: " + GoldAmt;
        }
    }
}

