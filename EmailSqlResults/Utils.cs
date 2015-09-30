using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmailSqlResults
{

    public static class Extensions
    {
        public static int Search(this string yourString, string yourMarker, int yourInst = 1, bool caseSensitive = true)
        {
            //returns the placement of a string in another string
            int num = 0;
            int currentInst = 1;
            //if optional argument, case sensitive is false convert string and marker to lowercase
            if (!caseSensitive) { yourString = yourString.ToLower(); yourMarker = yourMarker.ToLower(); }
            bool found = false;
            try
            {
                while (num < yourString.Length)
                {
                    string testString = yourString.Substring(num, yourMarker.Length);
                    if (testString == yourMarker)
                    {
                        if (currentInst == yourInst)
                        {
                            found = true;
                            break;
                        }
                        currentInst++;
                    }
                    num++;
                }
            }
            catch
            {
                num = -1;
            }
            num = found ? num : -1;
            return num;
        }
    }
}
  