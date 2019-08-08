using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericsChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>() { "a", "b", "c", "d", "e" };
            List<string> list2 = new List<string>() { "f", "g", "h", "i", "j", "k" };
            List<int> list3 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> list4 = new List<int>() { 7, 8, 9, 10, 11 };

            List<int> output = IntermixLists(list3, list4);

            foreach (var item in output)
            {
                //Console.Write($"{ item }, ");
            }
            //Console.WriteLine(); Console.WriteLine();

            GenericObject<string> ob1 = new GenericObject<string>() { Title = "title11111", GenericProperty = "generic1"};
            GenericObject<string> ob2 = new GenericObject<string>() { Title = "title2222", GenericProperty = "generic2" };

            GenericObject<string> output2 = GetLongerTitle2(ob1, ob2);

            //Console.WriteLine(output2.Title);

            //Console.WriteLine(ob1.GenericProperty);
            //Console.WriteLine(ob2.GenericProperty);

            //Console.WriteLine(); Console.WriteLine();

            IObject ob3 = new Object() { Title = "title11111" };
            IObject ob4 = new Object2() { Title = "title2222" };

            IObject output3 = GetLongerTitle2<IObject>(ob3, ob4);

            Console.WriteLine(output3.Title);

            Console.ReadLine();
        }

        public static List<T> IntermixLists<T>(List<T> list1, List<T> list2)
        {
            List<T> output = new List<T>();

            if (list1.Count >= list2.Count)
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    output.Add(list1[i]);
                    if (list2.Count > i)
                    {
                        output.Add(list2[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    output.Add(list2[i]);
                    if (list1.Count > i)
                    {
                        output.Add(list1[i]);
                    }
                }
            }

            return output;
        }

        public static string GetLongerTitle<T>(GenericObject<T> ob1, GenericObject<T> ob2)
        {
            if (ob1.Title != null && ob2.Title != null)
            {
                if (ob1.Title.Length >= ob2.Title.Length)
                {
                    return ob1.Title;
                }
                else
                {
                    return ob2.Title;
                }
            }
            else
            {
                return "Object has no Title property";
            }
        }

        public static T GetLongerTitle2<T> (T ob1, T ob2) where T : class
        {            
            string out1 = (string)ob1.GetType().GetProperty("Title").GetValue(ob1, null);
            string out2 = (string)ob2.GetType().GetProperty("Title").GetValue(ob2, null);

            if (out1 != null && out2 != null)
            {
                if (out1.Length >= out2.Length)
                {
                    return ob1;
                }
                else
                {
                    return ob2;
                }
            }
            else
            {
                return null;
            }
        }
    }

    public class GenericObject<T>
    {
        public T GenericProperty { get; set; }
        public string Title { get; set; }
    }

    public interface IObject
    {
        string Title { get; set; }
    }

    public class Object : IObject
    {
        public string Title { get; set; }
    }

    public class Object2 : IObject
    {
        public string Title { get; set; }
    }
}
