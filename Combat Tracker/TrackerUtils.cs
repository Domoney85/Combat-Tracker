using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using RandomNameGenerator;

namespace Combat_Tracker
{
    class TrackerUtils
    {
        private static int characterIds = 0;

        //Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        internal static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        internal static List<Character> ReadCSVFile(string filename)
        {
            var characters = new List<Character>();
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    characters.Add(new Character(
                        getCharacterId(),
                        fields[0],
                        Convert.ToInt32(fields[1]),
                        Convert.ToInt32(fields[2]),
                        Convert.ToInt32(fields[3]),
                        Convert.ToInt32(fields[4]))
                    {
                        InCombat = false
                    });
                }
            }
            return characters;
        }

        internal static void WriteCSVFile(string filename, List<Character> characters)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Character x in characters)
                {
                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                        x.Name, x.Skill, x.Complexity, x.Perception, x.Will));
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal static int getCharacterId()
        {
            return Interlocked.Increment(ref characterIds);
        }

        internal static Gender RandomGender()
        {
            if (RandomNumber(0, 2) > 0)
                return Gender.Male;
            return Gender.Female;
        }

    }
}
