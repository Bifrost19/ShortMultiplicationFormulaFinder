using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ShortMultiplicationFormulaFinder
{
    class Program
    {

        static void Main()
        {

            char sign;

            int var;
            string componentsSpace;
            string[] components = new string[5000];
            string[] varString = new string[1000];

            StringBuilder numberBuilder = new StringBuilder();
            StringBuilder varBuilder = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Enter a number(n) for the expression (x +/- a)^n : ");
            var = int.Parse(Console.ReadLine());

            Console.Write("Choose the sign of the expression('+' or '-'): ");
            sign = char.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            if(sign == '+')
            {
                Console.WriteLine("(x + a)^" + var + " = ");
            }
            if (sign == '-')
            {
                Console.WriteLine("(x - a)^" + var + " = ");
            }

            Console.WriteLine();

            for (int i = 0; i <= var; i++)
            {



                if (i == 0)
                {
                    numberBuilder.Append("1");
                }
                else if (i == 1)
                {
                    numberBuilder.Append("1 1");
                }

                else
                {
                    for (int m = 0; m <= i; m++)
                    {
                        
                        if(m == 0)
                        {
                            numberBuilder.Append("1 ");
                        }
                        else if (m == i)
                        {
                            numberBuilder.Append("1");
                        }
                        else
                        {

                             numberBuilder.Append((BigInteger.Parse(components[m - 1]) + BigInteger.Parse(components[m])) + " ");
                        }
                    } 
                }

                    components = numberBuilder.ToString().Split(' ');
                    componentsSpace = numberBuilder.ToString();




                if (i == var && var != 0 && var != 1)
                {
                    if (var % 2 == 0)
                    {
                        for (int q = 1; q <= var / 2 + 1; q++)
                        {
                            if(q == 1)
                            {
                                varBuilder.Append("*x^" + var + " ");
                            }
                            else if (q == var / 2 + 1)
                            {
                                varBuilder.Append("*x^" + var / 2 + "*a^" + var / 2 + " ");
                            }
                            else
                            {
                                varBuilder.Append("*x^" + (var - q + 1) + "*a^" + (q - 1) + " ");
                            }
                        }
                        for (int q = 1; q <= var/2; q++)
                        {
                            if(q == var / 2)
                            {
                                varBuilder.Append("*a^" + var);
                            }
                            else
                            {
                                varBuilder.Append("*x^" + (var - q - var/2) + "*a^" + (var + q - var/2) + " ");
                            }
                        }
                    }
                    else
                    {
                        for (int q = 1; q <= components.Length / 2; q++)
                        {
                            if (q == 1)
                            {
                                varBuilder.Append("*x^" + var + " ");
                            }
                            else
                            {
                                varBuilder.Append("*x^" + (var - q + 1) + "*a^" + (q - 1) + " ");
                            }
                        }
                        for (int q = 1; q <= components.Length / 2; q++)
                        {
                            if (q == components.Length / 2)
                            {
                                varBuilder.Append("*a^" + var);
                            }
                            else
                            {
                                varBuilder.Append("*x^" + (var - q - components.Length / 2 + 1) + "*a^" + (var + q - components.Length / 2) + " ");
                            }
                        }

                    }

                    varString = varBuilder.ToString().Split(' ');

                    for (int n = 0; n < components.Length; n++)
                    {
                        if (n != componentsSpace.Length - 1 && n != 0)
                        {
                            if (sign == '+')
                            {
                                Console.Write(" + ");
                            }
                            else if(sign == '-')
                            {
                                if(n % 2 == 0)
                                {
                                    Console.Write(" + ");
                                }
                                else
                                {
                                    Console.Write(" - ");
                                }
                            }
                        } 

                            Console.Write(components[n]);

                        if(n < varString.Length)
                        Console.Write(varString[n]);

                    }

                }

                else if(var == 0)
                {
                    Console.WriteLine(" 1 ");
                }

                else if(var == 1 && i == 1)
                {
                    Console.WriteLine(" 1x + 1a ");
                }

                numberBuilder.Clear();
                varBuilder.Clear();
            }

            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
