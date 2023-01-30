using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp
{
    internal static class Utils
    {
        public static List<int> FindIndeksFromText(string text)
        {
            List<int> list = new();

            string tempString = "";

            foreach (char c in text)
            {
                if (Char.IsAsciiDigit(c))
                {
                    tempString += c;

                    if (tempString.Length == 7)
                    {
                        list.Add(int.Parse(tempString));
                        tempString = "";
                    }
                }
                else
                {
                    tempString = "";
                }

            }

            return list;
        }
    }
}
