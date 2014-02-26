using StarDotOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace StarDotOne
{
    public static class PersonGenerator
    {
        static Random rng = new Random(Guid.NewGuid().GetHashCode());

        static PersonGenerator()
        {
        }

        public static IEnumerable<Person> GeneratePeople(int quantity)
        {
            for (int i = 1; i < quantity; i++)
            {
                yield return new Person
                {
                    FirstName = "Bob",
                    LastName = GenerateSurname(),
                    Age = rng.Next(5, 100)
                };
            }
        }

        // http://weblogs.asp.net/jgalloway/archive/2007/01/12/code-puzzle-2-generate-random-fake-surnames-recap.aspx
        private static string GenerateSurname()
        {
            string name = string.Empty;
            string[] currentConsonant;
            string[] vowels = "a,a,a,a,a,e,e,e,e,e,e,e,e,e,e,e,i,i,i,o,o,o,u,y,ee,ee,ea,ea,ey,eau,eigh,oa,oo,ou,ough,ay".Split(',');
            string[] commonConsonants = "s,s,s,s,t,t,t,t,t,n,n,r,l,d,sm,sl,sh,sh,th,th,th".Split(',');
            string[] averageConsonants = "sh,sh,st,st,b,c,f,g,h,k,l,m,p,p,ph,wh".Split(',');
            string[] middleConsonants = "x,ss,ss,ch,ch,ck,ck,dd,kn,rt,gh,mm,nd,nd,nn,pp,ps,tt,ff,rr,rk,mp,ll".Split(',');
            //Can't start    
            string[] rareConsonants = "j,j,j,v,v,w,w,w,z,qu,qu".Split(',');
            int[] lengthArray = new int[] { 2, 2, 2, 2, 2, 2, 3, 3, 3, 4 };
            //Favor shorter names but allow longer ones    
            int length = lengthArray[rng.Next(lengthArray.Length)];
            for (int i = 0; i < length; i++)
            {
                int letterType = rng.Next(1000);
                if (letterType < 775) currentConsonant = commonConsonants;
                else if (letterType < 875 && i > 0) currentConsonant = middleConsonants;
                else if (letterType < 985) currentConsonant = averageConsonants;
                else currentConsonant = rareConsonants;
                name += currentConsonant[rng.Next(currentConsonant.Length)];
                name += vowels[rng.Next(vowels.Length)];
                if (name.Length > 4 && rng.Next(1000) < 800) break;
                //Getting long, must roll to save        
                if (name.Length > 6 && rng.Next(1000) < 950) break;
                //Really long, roll again to save        
                if (name.Length > 7) break;
                //Probably ridiculous, stop building and add ending    
            } int endingType = rng.Next(1000);
            if (name.Length > 6) endingType -= (name.Length * 25);
            //Don't add long endings if already long    
            else endingType += (name.Length * 10);
            //Favor long endings if short    
            if (endingType < 400) { }
            // Ends with vowel    
            else if (endingType < 775) name += commonConsonants[rng.Next(commonConsonants.Length)];
            else if (endingType < 825) name += averageConsonants[rng.Next(averageConsonants.Length)];
            else if (endingType < 840) name += "ski";
            else if (endingType < 860) name += "son";
            else if (Regex.IsMatch(name, "(.+)(ay|e|ee|ea|oo)$") || name.Length < 5)
            {
                name = "Mc" + name.Substring(0, 1).ToUpper() + name.Substring(1);
                return name;
            }
            else name += "ez";
            name = name.Substring(0, 1).ToUpper() + name.Substring(1);
            //Capitalize first letter    
            return name;
        }
    }
}