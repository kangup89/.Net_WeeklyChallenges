using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    public class FileProcessor
    {
        public static string path = @"D:\workspace\Visual Studio\weekly\TextFileChallengeStarterCode\TextFileChallenge";
        public static String[] allLines = File.ReadAllLines($"{ path }\\StandardDataSet.csv");
        public static string[] firstLine = allLines[0].Split(',');

        public static BindingList<UserModel> readFile()
        {
            
            String[] lines = new string[allLines.Length - 1];

            BindingList<UserModel> userModels = new BindingList<UserModel>();
            
            Array.ConstrainedCopy(allLines, 1, lines, 0, lines.Length);
            int[] propsOrder = getPropsOrder(firstLine);

            foreach (String s in lines)
            {
                String[] props = s.Split(',');

                bool isAlive = true;

                if (props[propsOrder[3]] == "0")
                {
                    isAlive = false;
                }

                userModels.Add(new UserModel { FirstName = props[propsOrder[0]], LastName = props[propsOrder[1]], Age = int.Parse(props[propsOrder[2]]), IsAlive = isAlive });

            }

            foreach (UserModel u in userModels)
            {
                Console.WriteLine(u.DisplayText);
            }

            return userModels;
        }

        public static void writeStandardFile(BindingList<UserModel> userModels)
        {
            List<String> lines = new List<string>();
            lines.Add(allLines[0]);
            String[] props = new string[4];

            int[] propsOrder = getPropsOrder(firstLine);

            foreach (UserModel u in userModels)
            {
                props[propsOrder[0]] = u.FirstName;
                props[propsOrder[1]] = u.LastName;
                props[propsOrder[2]] = u.Age.ToString();
                props[propsOrder[3]] = "1";
                if (!u.IsAlive)
                {
                    props[propsOrder[3]] = "0";
                }

                String line = $"{props[0] },{ props[1] },{ props[2] },{ props[3] }";
                lines.Add(line);
            }

            File.WriteAllLines($"{ path }\\StandardDataSet.csv", lines);
        }

        public static int[] getPropsOrder(String[] line)
        {
            int[] propsOrder = new int[4];

            for (int i = 0; i < firstLine.Length; i++)
            {
                if (firstLine[i] == "FirstName")
                {
                    propsOrder[0] = i;
                }
                else if (firstLine[i] == "LastName")
                {
                    propsOrder[1] = i;
                }
                else if (firstLine[i] == "Age")
                {
                    propsOrder[2] = i;
                }
                else if (firstLine[i] == "IsAlive")
                {
                    propsOrder[3] = i;
                }
            }

            return propsOrder;
        }
    }
}
