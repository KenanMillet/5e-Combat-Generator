using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class Compendium
    {
        public Dictionary<int, int[]> DifficultyValues { get; set; }
        public Dictionary<int, decimal> NumMonsterMult { get; set; }
        public Dictionary<int, Die[]> CR0_4Gold { get; set; }
        public Dictionary<int, Die[]> CR5_10Gold { get; set; }
        public Dictionary<int, Die[]> CR11_16Gold { get; set; }
        public Dictionary<int, Die[]> CR17_Gold { get; set; }
        public int CommonItemValueMin { get; set; }
        public int CommonItemValueMax { get; set; }
        public int UncommonItemValueMax { get; set; }
        public int RareItemValueMax { get; set; }
        public int VeryRareItemValueMax { get; set; }
        public Dictionary<ChallengeRating, int> ExpValues { get; set; }
        public List<Monster> FullMonsterList { get; set; }
        public List<Item> FullItemList { get; set; }

        public Compendium(List<Monster> fullMonsterList, List<Item> fullItemList)
        {
            FullMonsterList = fullMonsterList;
            FullItemList = fullItemList;
            
            DifficultyValues = new Dictionary<int, int[]>();
            NumMonsterMult = new Dictionary<int, decimal>();
            CR0_4Gold = new Dictionary<int, Die[]>();
            CR5_10Gold = new Dictionary<int, Die[]>();
            CR11_16Gold = new Dictionary<int, Die[]>();
            CR17_Gold = new Dictionary<int, Die[]>();
            ExpValues = new Dictionary<ChallengeRating, int>();

            DifficultyValues.Add(0, new int[] { 25, 50, 75, 125, 250, 300, 350, 450, 550, 600, 800, 1000, 1100, 1250, 1400, 1600, 2000, 2100, 2400, 2800 });
            DifficultyValues.Add(1, new int[] { 50, 100, 150, 250, 500, 600, 750, 900, 1100, 1200, 1600, 2000, 2200, 2500, 2800, 3200, 3900, 4200, 4900, 5700 });
            DifficultyValues.Add(2, new int[] { 75, 150, 225, 375, 750, 900, 1100, 1400, 1600, 1900, 2400, 3000, 3400, 3800, 4300, 4800, 5900, 6300, 7300, 8500 });
            DifficultyValues.Add(3, new int[] { 100, 200, 400, 500, 1100, 1400, 1700, 2100, 2400, 2800, 3600, 4500, 5100, 5700, 6400, 7200, 8800, 9500, 10900, 12700 });

            NumMonsterMult.Add(1, 1);
            NumMonsterMult.Add(2, 1.5m);
            NumMonsterMult.Add(3, 2);
            NumMonsterMult.Add(7, 2.5m);
            NumMonsterMult.Add(11, 3);
            NumMonsterMult.Add(15, 4);

            CR0_4Gold.Add(30, new Die[] { new Die(5, 6) });//copper 1/10 of silver, 1/50 of electrum, 1/100 of gold, 1/1000 platinum
            CR0_4Gold.Add(60, new Die[] { new Die(40, 6) });//4d6 silver
            CR0_4Gold.Add(70, new Die[] { new Die(150, 6) });//3d6 electrum
            CR0_4Gold.Add(95, new Die[] { new Die(300, 6) });//3d6 gold
            CR0_4Gold.Add(100, new Die[] { new Die(1000, 6) });//1d6 platinum

            CR5_10Gold.Add(30, new Die[] { new Die(400, 6), new Die(500, 6) });//4d6 * 100 cp, 1d6 * 10 ep
            CR5_10Gold.Add(60, new Die[] { new Die(600, 6), new Die(2000, 6) });
            CR5_10Gold.Add(70, new Die[] { new Die(1500, 6), new Die(2000, 6) });
            CR5_10Gold.Add(95, new Die[] { new Die(4000, 6) });
            CR5_10Gold.Add(100, new Die[] { new Die(2000, 6), new Die(3000, 6) });

            CR11_16Gold.Add(20, new Die[] { new Die(4000, 6), new Die(10000, 6) });
            CR11_16Gold.Add(35, new Die[] { new Die(5000, 6), new Die(10000, 6) });
            CR11_16Gold.Add(75, new Die[] { new Die(20000, 6), new Die(10000, 6) });
            CR11_16Gold.Add(100, new Die[] { new Die(20000, 6), new Die(20000, 6) });

            CR17_Gold.Add(15, new Die[] { new Die(100000, 6), new Die(80000, 6) });
            CR17_Gold.Add(55, new Die[] { new Die(100000, 6), new Die(100000, 6) });
            CR17_Gold.Add(100, new Die[] { new Die(100000, 6), new Die(200000, 6) });

            CommonItemValueMin = 50;
            CommonItemValueMax = 100;
            UncommonItemValueMax = 500;
            RareItemValueMax = 5000;
            VeryRareItemValueMax = 50000;


            ExpValues.Add(new ChallengeRating(0), 10);
            ExpValues.Add(new ChallengeRating(1, 8), 25);
            ExpValues.Add(new ChallengeRating(1, 4), 50);
            ExpValues.Add(new ChallengeRating(1, 2), 100);
            ExpValues.Add(new ChallengeRating(1), 200);
            ExpValues.Add(new ChallengeRating(2), 450);
            ExpValues.Add(new ChallengeRating(3), 700);
            ExpValues.Add(new ChallengeRating(4), 1100);
            ExpValues.Add(new ChallengeRating(5), 1800);
            ExpValues.Add(new ChallengeRating(6), 2300);
            ExpValues.Add(new ChallengeRating(7), 2900);
            ExpValues.Add(new ChallengeRating(8), 3900);
            ExpValues.Add(new ChallengeRating(9), 5000);
            ExpValues.Add(new ChallengeRating(10), 5900);
            ExpValues.Add(new ChallengeRating(11), 7200);
            ExpValues.Add(new ChallengeRating(12), 8400);
            ExpValues.Add(new ChallengeRating(13), 10000);
            ExpValues.Add(new ChallengeRating(14), 11500);
            ExpValues.Add(new ChallengeRating(15), 13000);
            ExpValues.Add(new ChallengeRating(16), 15000);
            ExpValues.Add(new ChallengeRating(17), 18000);
            ExpValues.Add(new ChallengeRating(18), 20000);
            ExpValues.Add(new ChallengeRating(19), 22000);
            ExpValues.Add(new ChallengeRating(20), 25000);
            ExpValues.Add(new ChallengeRating(21), 33000);
            ExpValues.Add(new ChallengeRating(22), 41000);
            ExpValues.Add(new ChallengeRating(23), 50000);
            ExpValues.Add(new ChallengeRating(24), 62000);
            ExpValues.Add(new ChallengeRating(30), 155000);
        }

        public List<Monster> getSortedMonster(List<string> restrictedTypes)
        {
            List<Monster> sortedList = new List<Monster>();
            bool add = true;
            foreach (Monster m in FullMonsterList)
            {
                add = true;
                foreach (string s in restrictedTypes)
                {
                    if(m.MainType == s)
                    {
                        add = false;
                    }
                    if(m.Subtype == s)
                    {
                        add = false;
                    }
                    if (m.MonsterGroup == s)
                    {
                        add = false;
                    }
                }
                if (add == true)
                {
                    sortedList.Add(m);
                }
            }
            return sortedList;
        }
    }
}
