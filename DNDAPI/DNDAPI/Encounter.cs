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
        public bool SingleSubType { get; set; }
        public decimal GoldAmt { get; set; }
        public List<string> RestrictedTypes { get; set; }
        public List<Monster> AvailableMonsters { get; set; }
        public List<Monster> ChosenMonsters { get; set; }
        public List<Item> ChosenItems { get; set; }
        public Dictionary<ChallengeRating, int> ExpValues { get; set; }

        public Encounter(int enPCs, int enPCLvls, int[] enDifficulty, int enChanceForSame, bool enSingleType,  bool enSingleSubType, List<string> enRestrictedTypes, Compendium enCompendium)
        {
            compendium = enCompendium;
            DifficultyValues = enDifficulty;
            PCs = enPCs;
            PCLvls = enPCLvls;
            ChanceForSame = enChanceForSame;
            SingleType = enSingleType;
            SingleSubType = enSingleSubType;
            ExpValues = compendium.ExpValues;
            BaseExp = DetermineBaseExp();
            RestrictedTypes = enRestrictedTypes;
            AvailableMonsters = compendium.getSortedMonster(RestrictedTypes);
            ChosenMonsters = PickMonsters();
            GoldAmt = DetermineGold();
            if (GoldAmt > compendium.CommonItemValueMin)
            {
                ChosenItems = FindPotentialItems(GoldAmt);
            }
            else
            {
                ChosenItems = new List<Item>();
            }
            AdjExpMult = DetermineAdjustedExp();
        }

        public int DetermineBaseExp()
        {
            int expTotal = DifficultyValues[PCLvls - 1];
            expTotal *= PCs;
            return expTotal;
        }

        private List<Monster> PickMonsters()
        {
            List<Monster> pickedMons = new List<Monster>();
            Monster chosenMonster;
            int totalExp = 0;
            Random rand = new Random();
            int monsterIndex = rand.Next(0, AvailableMonsters.Count);
            chosenMonster = AvailableMonsters[monsterIndex];
            string monsterType = null;
            string monsterSubType = null;
            bool IsPicked = false;
            while (totalExp < (BaseExp * .8))
             {
                if (ExpValues[chosenMonster.CR] + totalExp <= BaseExp) //if the exp given according to the CR + the current exptotal is greater than the base exp of the encounter, then
                {
                    if (SingleType == true)
                    {
                        if (IsPicked == false)
                        {
                            monsterType = chosenMonster.MainType;
                            if( SingleSubType == true && chosenMonster.Subtype != null)
                            {
                                monsterSubType = chosenMonster.Subtype;
                            }
                            IsPicked = true;
                        }
                        if (chosenMonster.Subtype != null && monsterSubType != null)
                        {
                            if (chosenMonster.MainType == monsterType && chosenMonster.Subtype == monsterSubType)
                            {
                                totalExp += ExpValues[chosenMonster.CR];
                                pickedMons.Add(chosenMonster);
                                if (d100.Roll(1, 0) > ChanceForSame)//if its less than the chance threshold for a different monster
                                {
                                    chosenMonster = AvailableMonsters[rand.Next(0, AvailableMonsters.Count)];
                                }
                            }
                            else
                            {
                                chosenMonster = AvailableMonsters[rand.Next(0, AvailableMonsters.Count)];
                            }
                        }
                        else if (chosenMonster.MainType == monsterType)
                        {
                            totalExp += ExpValues[chosenMonster.CR];
                            pickedMons.Add(chosenMonster);
                            if (d100.Roll(1, 0) > ChanceForSame)//if its less than the chance threshold for a different monster
                            {
                                chosenMonster = AvailableMonsters[rand.Next(0, AvailableMonsters.Count)];
                            }
                        }
                        else
                        {
                            chosenMonster = AvailableMonsters[rand.Next(0, AvailableMonsters.Count)];
                        }
                    }
                    else
                    {
                        totalExp += ExpValues[chosenMonster.CR];
                        pickedMons.Add(chosenMonster);
                        if( d100.Roll(1, 0) > ChanceForSame)//if its above the roll, then pick a new one.
                        {
                            chosenMonster = AvailableMonsters[rand.Next(0, AvailableMonsters.Count)];
                        }
                    }
                }
                else
                {
                    monsterIndex = rand.Next(0, AvailableMonsters.Count);
                    chosenMonster = AvailableMonsters[monsterIndex];
                }

            }
            ExpAmt = totalExp;
            return pickedMons;
        }

        private decimal DetermineGold()
        {
            decimal copper = 0;
            Dictionary<int, Die[]> valueTable;
            int rolledNum = d100.Roll(1, 0);
            int foundKey = 0;
            System.Diagnostics.Debug.WriteLine("determineGold");
            foreach (Monster m in ChosenMonsters)
            {
                System.Diagnostics.Debug.WriteLine("beginning of foreach");
                foundKey = 0;
                if (m.CR.Total <= 4)
                {
                    valueTable = compendium.CR0_4Gold;
                }
                else if (m.CR.Total <= 10)
                {
                    valueTable = compendium.CR5_10Gold;
                }
                else if (m.CR.Total <= 16)
                {
                    valueTable = compendium.CR11_16Gold;
                }
                else
                {
                    valueTable = compendium.CR17_Gold;
                }
                foreach (int key in valueTable.Keys)
                {
                    if (rolledNum <= key && rolledNum > foundKey)
                    {
                        foundKey = key;
                    }
                }
                foreach (Die d in valueTable[foundKey])
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
            int itemIndex = rand.Next(0, compendium.FullItemList.Count);
            int currentValue = 0;
            Item i = compendium.FullItemList[itemIndex];
            i = DetermineItemQuality(i);
            while (currentValue < (GoldAmt * new decimal(0.5)))
            {
                if (currentValue + i.Value < gold) //if the exp given according to the CR + the current exptotal is greater than the base exp of the encounter, then
                {
                    currentValue += i.Value;
                    foundItems.Add(i);
                    itemIndex = rand.Next(0, compendium.FullItemList.Count);
                    i = compendium.FullItemList[itemIndex];
                    i = DetermineItemQuality(i);
                    
                }
                else
                {
                    itemIndex = rand.Next(0, compendium.FullItemList.Count);
                    i = compendium.FullItemList[itemIndex];
                    i = DetermineItemQuality(i);
                }
             }
            return foundItems;
        }

        public Item DetermineItemQuality(Item i)
        {
            Random rand = new Random();
            if (i.Rarity == "common")
            {
                i.Value = rand.Next(compendium.CommonItemValueMin, compendium.CommonItemValueMax);

                if ( i.Value < compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value < compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .4))
                {
                    i.Quality = "Mediocre";
                }
                else if (i.Value < compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .6))
                {
                    i.Quality = "";
                }
                else if (i.Value < compendium.CommonItemValueMin + (compendium.CommonItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "uncommon")
            {
                i.Value = rand.Next(compendium.CommonItemValueMax, compendium.UncommonItemValueMax);

                if (i.Value < compendium.CommonItemValueMax + (compendium.UncommonItemValueMax* .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value < compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .4))
                {
                    i.Quality = "Mediocre";
                }
                else if (i.Value < compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .6))
                {
                    i.Quality = "";
                }
                else if (i.Value < compendium.CommonItemValueMax + (compendium.UncommonItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "rare")
            {
                i.Value = rand.Next(compendium.UncommonItemValueMax, compendium.RareItemValueMax);

                if (i.Value < compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value < compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .4))
                {
                    i.Quality = "Mediocre";
                }
                else if (i.Value < compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .6))
                {
                    i.Quality = "";
                }
                else if (i.Value < compendium.UncommonItemValueMax + (compendium.RareItemValueMax * .8))
                {
                    i.Quality = "Well Crafted";
                }
                else
                {
                    i.Quality = "Masterwork";
                }
            }
            else if (i.Rarity == "very rare")
            {
                i.Value = rand.Next(compendium.RareItemValueMax, compendium.VeryRareItemValueMax);

                if (i.Value < compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .2))
                {
                    i.Quality = "Shoddy";
                }
                else if (i.Value < compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .4))
                {
                    i.Quality = "Mediocre";
                }
                else if (i.Value < compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .6))
                {
                    i.Quality = "";
                }
                else if (i.Value < compendium.RareItemValueMax + (compendium.VeryRareItemValueMax * .8))
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
                i.Value = rand.Next(compendium.VeryRareItemValueMax, compendium.VeryRareItemValueMax * 2);
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
                if (ChosenMonsters.Count <= key && ChosenMonsters.Count > foundKey)
                {
                    foundKey = key;
                }
            }
            if( foundKey == 0)
            {
                foundKey = valueTable.Keys.Last();
            }
            return valueTable[foundKey];
        }

        public string getGeneralData()
        {
            return "Exp Goal: " + BaseExp + " | " + "Exp Generated: " + ExpAmt + "\n" + "Total Creatures: " + ChosenMonsters.Count + "\n" + "Adjusted Exp Amt: " + (ExpAmt * AdjExpMult) + "\n" + "Exp Per Player: " + (ExpAmt / PCs) +  "\n" + "Gold Generated: " + GoldAmt + "\n";
        }
    }
}

