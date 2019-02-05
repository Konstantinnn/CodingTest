using System;
using System.Collections.Generic;
using System.IO;

namespace CodingTestForTJBSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new List<String>();
            String line;

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(@"C:\CodingTestForTJBSoftware\Fragment\fragment1.txt");

            //Read the first line of text
            line = sr.ReadLine();

            //Add line into array
            while (line != null)
            {
                //Write the lie to console window
                arrayList.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }

            //Console result
            var consoleDisplay = CreateString(arrayList);
            Console.WriteLine(consoleDisplay);
            Console.ReadKey();
        }

        //Function concatanate strings with max overlaping until the only one line is left
        public static String CreateString(List<String> strings)
        {
            while (strings.Count > 1)
            {
                var maxOverlap = 0;
                String msi = strings[0], msj = strings[1];
                foreach (String si in strings)
                {
                    foreach (String sj in strings)
                    {
                        if (si.Equals(sj)) continue;
                        var curOverlap = Overlap(si, sj);
                        if (curOverlap > maxOverlap)
                        {
                            maxOverlap = curOverlap;
                            msi = si; msj = sj;
                        }
                    }
                }
                strings.Add(Merge(msi, msj, maxOverlap));
                strings.Remove(msi);
                strings.Remove(msj);
            }
            return strings[0];
        }

        // Function finds max length of a suffix s1 matching with a prefix s2 (overlap length s1 to s2)
        public static int Overlap(String s1, String s2)
        {
            var s1Last = s1.Length - 1;
            var s2Len = s2.Length;
            var overlap = 0;
            for (int i = s1Last, j = 1; i > 0 && j < s2Len; i--, j++)
            {
                String suff = s1.Substring(i);
                String pref = s2.Substring(0, j);
                if (suff.Equals(pref))
                {
                    overlap = j;
                }
            }
            return overlap;
        }

        // The function merges strings s1 and s2 by len length, calculated with using the overlap function(s1, s2)
        public static String Merge(String s1, String s2, int length)
        {
            s2 = s2.Substring(length);
            return s1 + s2;
        }
    }
}
