using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    //if (result == null)
                    //{
                    //    throw new IndexOutOfRangeException();
                    //}

                    Console.WriteLine(result.TransactionAmount);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Null value for item { i }");
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Payment skipped for payment with { i } items");
                //}
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Skipped invalid record");
                }
                catch (FormatException ex)
                {
                    if (i != 5)
                    {
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Formatting Issue we have a hard time multiplying odd numbers");
                        }
                        else
                        {
                            Console.WriteLine($"Formatting Issue");
                        }          
                    }
                    else
                    {
                        Console.WriteLine($"Payment skipped for payment with { i } items");
                    }
                    
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine($"Payment skipped for payment with { i } items");
                }


            }
            Console.ReadLine();
        }
    }
}
