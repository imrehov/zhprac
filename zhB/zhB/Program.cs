using System.Reflection.PortableExecutable;

namespace zhB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. feladat

            string[] input = File.ReadAllLines("data.txt");

            List<string> inputFirstHalf = new List<string>();

            List<string> inputSecondHalf = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                inputFirstHalf.Add(input[i].Split(',')[0]);

                inputSecondHalf.Add(input[i].Split(',')[1]);

            }

            //for (int i = 0; i < inputFirstHalf.Count; i++)
            //{
            //    Console.WriteLine(inputFirstHalf[i] + " and " + inputSecondHalf[i]);
            //}


            // 2. feladat

            // végig z egész felezett cuccon

            for (int i = 0; i < inputFirstHalf.Count; i++)
            {
                // csak formázás táblaszerűre

                Console.WriteLine(new string('_', 100));

                // végigmenni a számokon 1-99 és ahol nem dolgoztak azt kipontozni a többit megjeleníteni, majd ugyanez a másik listából
                for (int j = 1; j < 100; j++)
                {
                    int startIdx = int.Parse(inputFirstHalf[i].Split('-')[0]);
                    int endIdx = int.Parse(inputFirstHalf[i].Split('-')[1]);

                    if (startIdx == j)
                    {
                        for (int k = startIdx; k < endIdx + 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                    }
                    Console.Write(".");
                }
                Console.WriteLine(" | " + inputFirstHalf[i]);

                for (int k = 1; k < 100; k++)
                {
                    int startIdx2 = int.Parse(inputSecondHalf[i].Split('-')[0]);
                    int endIdx2 = int.Parse(inputSecondHalf[i].Split('-')[1]);

                    if (startIdx2 == k)
                    {
                        for (int l = startIdx2; l < endIdx2 + 1; l++)
                        {
                            Console.Write(l + " ");
                        }
                    }
                    Console.Write(".");
                }
                Console.WriteLine(" | " + inputSecondHalf[i]);
                Console.WriteLine(new string('_', 100));
            }



            // 3. feladat

            // csinálok két listát minden párhoz, majd megnézni hogy valamelyik telibe lefedi-e a másikat

            List<int> firstElf = new List<int>();
            List<int> secondElf = new List<int>();

            string filename = "winner.txt";


            for (int i = 0; i < inputFirstHalf.Count; i++)
            {
                int startIdx = int.Parse(inputFirstHalf[i].Split('-')[0]);
                int endIdx = int.Parse(inputFirstHalf[i].Split('-')[1]);


                for (int j = startIdx; j < endIdx + 1; j++)
                {
                    firstElf.Add(j);

                }

                int startIdx2 = int.Parse(inputSecondHalf[i].Split('-')[0]);
                int endIdx2 = int.Parse(inputSecondHalf[i].Split('-')[1]);

                for (int k = startIdx2; k < endIdx2 + 1; k++)
                {
                    secondElf.Add(k);
                }

                //végiloop mind 2 listán mind2 irányból megnézni h az egyik tökéletesen lefedi e a másikat
                // elég lett vna megnézni h benne van-e a start és az end idx xd

                bool containsAll = true;

                if (firstElf.Count >= secondElf.Count)
                {
                    foreach (int num in secondElf)
                    {
                        bool found = false;

                        foreach (int num1 in firstElf)
                        {
                            if (num == num1)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            containsAll = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (int num1 in firstElf)
                    {
                        bool found = false;

                        foreach (int num in secondElf)
                        {
                            if (num1 == num)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            containsAll = false;
                            break;
                        }
                    }
                }

                if (containsAll)
                {
                    string notALoser = $"{startIdx} - {endIdx} and {startIdx2} - {endIdx2} YEP" + new string('=', 25) + "\n";
                    File.AppendAllText(filename, notALoser);
                    Console.WriteLine(notALoser);
                }
                else
                {
                    string loser = $"{startIdx} - {endIdx} and {startIdx2} - {endIdx2} NOP \n";
                    File.AppendAllText (filename, loser);
                    Console.WriteLine(loser);
                }

                firstElf.Clear();
                secondElf.Clear();

            }

            // 4. feladat
            // copy paste az elejét fentebbről

            for (int i = 0; i < inputFirstHalf.Count; i++)
            {
                int startIdx = int.Parse(inputFirstHalf[i].Split('-')[0]);
                int endIdx = int.Parse(inputFirstHalf[i].Split('-')[1]);


                for (int j = startIdx; j < endIdx + 1; j++)
                {
                    firstElf.Add(j);

                }

                int startIdx2 = int.Parse(inputSecondHalf[i].Split('-')[0]);
                int endIdx2 = int.Parse(inputSecondHalf[i].Split('-')[1]);

                for (int k = startIdx2; k < endIdx2 + 1; k++)
                {
                    secondElf.Add(k);
                }

                if (endIdx < startIdx2 || endIdx2 < startIdx)
                {
                    string matching = $"{startIdx} - {endIdx} and {startIdx2} - {endIdx2} NO OVERLAP " + new string('#', 25) + "\n";
                    File.AppendAllText(filename, matching);
                    Console.WriteLine(matching);
                }
                //else if ()
                //{
                //    string matching = $"{startIdx} - {endIdx} and {startIdx2} - {endIdx2} NO OVERLAP " + new string('#', 25) + "\n";
                //    File.AppendAllText(filename, matching);
                //    Console.WriteLine(matching);
                //}
                else
                {
                    string notmatching = $"{startIdx} - {endIdx} and {startIdx2} - {endIdx2}  OVERLAP";
                    File.AppendAllText(filename, notmatching);
                    Console.WriteLine(notmatching);
                }




                firstElf.Clear();
                secondElf.Clear();
            }







        }
    }
}
