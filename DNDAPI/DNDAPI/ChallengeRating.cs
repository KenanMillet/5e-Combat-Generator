using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class ChallengeRating
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public decimal Total => (decimal)Numerator / Denominator;//lamda function--this is essentially an inline function. I also cast 

        public ChallengeRating(int leftNum, int rightNum)
        {
            Numerator = leftNum;
            Denominator = rightNum;
        }

        public ChallengeRating(int num)
        {
            Numerator = num;
            Denominator = 1;
        }

        public override string ToString()
        {
            if(Denominator != 1)
            {
                return  Numerator + "/" + Denominator;
            }
            else
            {
                return Numerator.ToString();
            }
        }

        public override bool Equals(object obj)//https://stackoverflow.com/questions/567642/how-to-best-implement-equals-for-custom-types
        {
            // STEP 1: Check for null
            if (obj == null)
            {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((ChallengeRating)obj);
        }

        public bool Equals(ChallengeRating obj)
        {
            // STEP 1: Check for null if nullable (e.g., a reference type)
            if (obj == null)
            {
                return false;
            }
            // STEP 2: Check for ReferenceEquals if this is a reference type
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // STEP 6: Compare identifying fields for equality.
            return this.Total == obj.Total;
        }
        public override int GetHashCode()
        {
            return (int)(Total * 43);//hashcodes gave theoretically infinite objects recognizable, small IDs. A hashcode must always equal other hashcodes if their ibjects values are the same.
        }
    }
}
