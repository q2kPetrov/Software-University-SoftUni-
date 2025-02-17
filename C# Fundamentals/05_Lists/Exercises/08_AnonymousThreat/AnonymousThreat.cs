using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArray = command.Split().ToArray();
                string action = commandArray[0];

                if (action == "merge")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int endIndex = int.Parse(commandArray[2]);
                    input = MergeTheList(input, startIndex, endIndex);
                }

                else if (action == "divide")
                {
                    int index = int.Parse(commandArray[1]);
                    int partitions = int.Parse(commandArray[2]);
                    input = DivideTheList(input, index, partitions);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        static List<string> MergeTheList(List<string> input, int startIndex, int endIndex)
        {

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                input[i] = input[i] + input[i + 1];
                input.RemoveAt(i + 1);
                i--;
                endIndex--;
            }

            return input;
        }
        static List<string> DivideTheList(List<string> input, int index, int portions)
        {
            string currentArray = input[index];
            input.RemoveAt(index);

            int partitionSize = currentArray.Length / portions;
            int partionReminder = currentArray.Length % portions;

            string sub = string.Empty;
            List<string> temp = new List<string>();

            for (int i = 1; i < portions; i++)
            {
                sub = currentArray.Substring(0, partitionSize);
                currentArray = currentArray.Substring(partitionSize);
                temp.Add(sub);
            }

            temp.Add(currentArray.Substring(0));
            input.InsertRange(index, temp);
            return input;
        }
    }
}
