using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC_Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////Setup////////////////////////////////////////

            //string[] input = File.ReadAllLines(@"F:\benre\Documents\Visual Studio 2015\Projects\Advent of Code\Day 02\AoC_Day2\input.txt");
            string[] input = File.ReadAllLines(@"C:\Users\ben.rendall\Drive Documents\Visual Studio\Projects\Advent of Code 2017\AoC_Day2\input.txt");
            Console.WriteLine(input.Count());
            int[,] grid = new int[input.Count(), input.Count()];

            int countRow = 0;
            int countCol = 0;

            foreach(string x in input)
            {
                string[] inputSplit = input[countRow].Split('\t');

                foreach(string y in inputSplit)
                {
                    grid[countRow, countCol] = Convert.ToInt32(inputSplit[countCol]);
                    countCol++;
                }

                countCol = 0;
                countRow++;
            }

            countRow = 0;
            countCol = 0;
            string tmp = "";

            Console.WriteLine("Input grid looks like this..");
            while (countRow < 16)
            {
                for(int f = 0; f <= input.Count()-1; f++)
                {
                    tmp = tmp + Convert.ToString(grid[countRow, countCol]) + "/";
                    countCol++;
                }
                tmp = tmp + '\n';
                countRow++;
                countCol = 0;
            }

            Console.WriteLine(tmp);

            //Grid is now imported and collated
            //Moving onto the first task

            ////////////////////////////////////////Section 1////////////////////////////////////////

            int finalSum = 0;
            countCol = 0;
            countRow = 0;
            int currentHi = 0;
            int currentLo = 0;

            while (countRow < 16)
            {
                try
                {
                    currentHi = grid[countRow, countCol];
                    currentLo = grid[countRow, countCol];
                }
                catch
                {

                }
                

                for (int f = 0; f <= input.Count() - 1; f++)
                {
                    try
                    {
                        if (grid[countRow, countCol] <= currentLo)
                        {
                            currentLo = grid[countRow, countCol];
                        }
                    }
                    catch(IndexOutOfRangeException)
                    {
                        //Do nothing because im lazy and this prevents errors
                    }
                    catch(Exception err)
                    {
                        Console.WriteLine(err.ToString());
                    }

                    try
                    {
                        if (grid[countRow, countCol] >= currentHi)
                        {
                            currentHi = grid[countRow, countCol];
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Do nothing because im lazy and this prevents errors
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.ToString());
                    }
                    countCol++;
                }

                string output = string.Format("Row {0}: Highest value:{1} \t Lowest value:{2} \tDifference:{3}", countRow, currentHi, currentLo, currentHi-currentLo);
                Console.WriteLine(output);
                finalSum = finalSum + (currentHi - currentLo);

                countCol = 0;
                countRow++;
            }

            Console.WriteLine("Section 1 - Final sum of all differences: " + finalSum);

            ////////////////////////////////////////Section 2////////////////////////////////////////

            countRow = 0;
            int countColPos1 = 0;
            int countColPos2 = 0;
            finalSum = 0;
            int divis1;
            int divis2;

            while(countRow < 16)
            {
                Console.WriteLine(string.Format("\nSearching row {0} for evenly dividing pair...", (countRow + 1)));

                for (int i = 0; i <= input.Count(); i++)
                {
                    for (int j = 0; j <= input.Count(); j++)
                    {
                        try
                        {
                            decimal intHolder1 = grid[countRow, countColPos1];
                            decimal intHolder2 = grid[countRow, countColPos2];
                            decimal divisCheck = (intHolder1 / intHolder2);
                            
                            if (divisCheck % 1 == 0 && divisCheck != 1)
                            {
                                finalSum = finalSum + Convert.ToInt32(divisCheck);
                                Console.WriteLine(string.Format("Found! columns {0} & {1} divide evenly into {2}. \nNew final sum is {3}", countColPos1, countColPos2, divisCheck, finalSum));
                            }

                            countColPos2++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //Still lazy
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.ToString());
                        }
                        

                    }
                    countColPos1++;
                    countColPos2 = 0;
                }
                countRow++;
                countColPos1 = 0;
            }

            Console.WriteLine(string.Format("Search complete, Section 2 final sum worked out to be: {0}", finalSum));
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
