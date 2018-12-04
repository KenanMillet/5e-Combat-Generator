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

        public decimal Total { get; set; }

        public ChallengeRating(int leftNum, int rightNum)
        {
            Numerator = leftNum;
            Denominator = rightNum;

            Total = Numerator / Denominator;
        }

        public ChallengeRating(int num)
        {
            Numerator = 1;
            Denominator = 1;
            Total = num;
        }

        public override string ToString()
        {
            if(Denominator != 1)
            {
                return  Numerator + "/" + Denominator;
            }
            else
            {
                return Total.ToString();
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
            // STEP 4: Possibly check for equivalent hash codes
            if (this.GetHashCode() != obj.GetHashCode())
            {
                return false;
            }
            // STEP 5: Check base.Equals if base overrides Equals()
            System.Diagnostics.Debug.Assert(
                base.GetType() != typeof(object));

            if (!base.Equals(obj))
            {
                return false;
            }

            // STEP 6: Compare identifying fields for equality.
            return this.Total.Equals(obj.Total);
        }
        public override int GetHashCode()
        {
            if (Denominator == 1)
            {
                return Convert.ToInt32(Total) * 0x00010000;
            }
            else
            {
                return 0+Convert.ToInt32(Total) * 0x00010000;
            }
            
        }
    }
}
