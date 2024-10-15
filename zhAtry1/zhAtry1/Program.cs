using System.IO;
using System.IO.Enumeration;

namespace zhAtry1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat lol

            string[] input = File.ReadAllLines("input.txt");


            // 2. feladat megnézni hogy melyik egyezik a 2 rekeszben

            List<string> inputSplit0List = new List<string> ();

            List<string> inputSplit1List = new List<string> ();

            int middleIdx = 0;

            for (int i = 0; i < input.Length; i++)
            {
                middleIdx = input[i].Length / 2;

                inputSplit0List.Add(input[i].Substring(0, middleIdx));

                inputSplit1List.Add(input[i].Substring(middleIdx));
            }

            List<string> inBothBags = new List<string> ();

            

            for (int i = 0; i < inputSplit0List.Count; i++)
            {
                char[] bagCheck0 = inputSplit0List[i].ToCharArray();

                char[] bagCheck1 = inputSplit1List[i].ToCharArray();


                for (int k = 0; k < bagCheck1.Length; k++)
                {
                    

                    for (global::System.Int32 j = 0; j < bagCheck1.Length; j++)
                    {

                        

                        if (bagCheck0[k] == bagCheck1[j])
                        {
                            inBothBags.Add(bagCheck0[k].ToString());
                        }
                    }
                }
            }


            

            //foreach (var item in inBothBags)
            //{
            //    Console.Write(item);
            //}


            //foreach (var itemm in inputSplit0List)
            //{
            //    Console.WriteLine(itemm);
            //}

            //Console.WriteLine("\n============================================================\n");

            //foreach (var itemm in inputSplit1List)
            //{
            //    Console.WriteLine(itemm);
            //}


            // 3. feladat megszámolni  ÉS KIÍRNI a cumókat


            List<string> countedEq = new List<string>();
            List<int> eqCount = new List<int>();

            string filename = "zhAsolved.txt";

            File.WriteAllText(filename, "");

            for (int i = 0; i < inBothBags.Count; i++)
            {
                int eqCounter = 0;

                if (!countedEq.Contains(inBothBags[i]))
                {
                    countedEq.Add(inBothBags[i]);


                    for (int j = 0; j < inBothBags.Count; j++)
                    {
                        if (inBothBags[i] == inBothBags[j])
                        {
                            eqCounter++;
                        }
                    }

                }              
                eqCount.Add(eqCounter);

                if (eqCount[i] != 0)
                {

                    string winner = $"There are {eqCount[i]} pieces of duplicated equipment \"{inBothBags[i]}\"\n";


                    File.AppendAllText(filename, winner);

                    Console.WriteLine(winner);
                }
            }

            // 4. feladat

            string[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            List<int> values = new List<int>();

            for (int i = 2; i < 54; i++)
            {
                values.Add(i);
            }

            string[,] table = new string[abc.Length, 2];


            for (int i = 0; i < abc.Length; i++)
            {   
                table[i,0] = abc[i];

                table[i, 1] = values[i].ToString();
            }

            List<int> dupedVList = new List<int>();

            for (int i = 0; i < countedEq.Count; i++)
            {
                int dupedValues = 0;

                for (int j = 0; j < abc.Length; j++)
                {
                    if (countedEq[i] == abc[j])
                    {
                        dupedValues += int.Parse(table[j, 1]);

                    }
                }

                dupedVList.Add(dupedValues);

                string winner2 = $"{dupedVList[i]} ({countedEq[i]})";
                File.AppendAllText(filename, winner2);

                Console.WriteLine(winner2);
            }




        }
    }
}
