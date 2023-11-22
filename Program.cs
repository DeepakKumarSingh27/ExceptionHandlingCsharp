using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExceptionHandling
{
    public class AgeCategoryException : Exception
    {
        public AgeCategoryException(string message) : base(message) { }
    }
    public class AgeCategorizer
    {
        public static string CategorizeAge(int? age )
        {
            
            if (!age.HasValue || age <= 0 || age.HasValue == null)
            {
               throw new AgeCategoryException("Invalid age provided. Age must be a positive number.");
            }
            else if (age >= 1 && age <= 14)
            {
                return "Children";
            }
            else if (age >= 15 && age <= 24)
            {
                return "Youth";
            }
            else if (age >= 25 && age <= 64)
            {
                return "Adults";
            }
            else
            {
                return "Seniors";
            }
        }
    }
    public class notValid:Exception
    {
        public notValid(string s) : base(s) 
        {
            
        }
    }
    public class Program
    { 
        static void checkage(int i)
        {
            if(i < 18)
            {
                throw new notValid("age is not valid");
            }
        }
       public static void Main(string[] args) 
        {
            Console.WriteLine("Enter the Number if Want to Execute: ");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    int i = 10;
                    Console.WriteLine("Enter the Number you want to Divide ");
                    int j = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        int result = i / j;
                        Console.WriteLine("Result is: " + result);
                    } catch(DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 2:
                    int a = 10;
                    Console.WriteLine("Enter the Number you want to Divide ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        int result = a / y;
                        Console.WriteLine("Result is: " + result);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    } finally
                    {
                        Console.WriteLine("Finally Block");
                    }
                    break;

                case 3:
                    try
                    {
                        checkage(16);
                    } catch(notValid ne)
                    {
                        Console.WriteLine(ne);
                    }
                    break;
                    case 4:
                    Console.WriteLine("Enter the age ");
                    int? age = Convert.ToInt32(Console.ReadLine()); // Change this value to test different scenarios
                    try
                    {
                        string category = AgeCategorizer.CategorizeAge(age);
                        Console.WriteLine($"The person falls into the category: {category}");
                    }
                    catch (AgeCategoryException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                default: Console.WriteLine("case don't match");
                    break;
            }
            Console.ReadLine();
        }
    }
}
