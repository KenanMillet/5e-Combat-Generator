using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class Die
    {
        Random dieRand = new Random();
        public int DieSides { get; set; }
        public int NumDice { get; set; }

        public Die(int sides_on_die)
        {
            DieSides = sides_on_die;
            NumDice = 1;
        }

        public Die(int number_of_dice, int sides_on_die)
        {
            DieSides = sides_on_die;
            NumDice = number_of_dice;
        }

        public int Roll(int newNumDice, int modifier)
        {
            int total = 0;
            for (int i = 0; i < newNumDice; i++)
            {
                total += dieRand.Next(1, DieSides);
            }
            total += modifier;
            return total;
        }
        public int RollInternal(int modifier)
        {
            return Roll(NumDice, modifier);
        }

        public override string ToString()
        {
            return NumDice + "d" + DieSides;
        }
    }
}
