using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineWordsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] S = new string[]
            {
                "4 5 6 - 7 +",
                "13 DUP 4 POP 5 DUP + DUP + -",
                "5 6 + -",
                "5 6 + -",
                "3 DUP - -"
            };


            foreach (var item in S)
            {
                Console.WriteLine($"\"{item}\" => Resultado: {MachineWords(item)}");
            }
        }

        public static int MachineWords(string S)
        {
            try
            {
                var operations = S.Split(" ");
                string error = string.Empty;

                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "POP":
                            if (stack.Count > 0)
                                stack.Pop();

                            else
                                error = operations[i];

                            break;
                        case "DUP":
                            var lastElement = stack.Peek();

                            if (lastElement > 0)
                                stack.Push(stack.Peek());

                            else
                                error = operations[i];
                            break;
                        case "+" or "-":
                            if (stack.Count > 0)
                            {
                                var lastElements = stack.Take(2);
                                int operation;

                                if (operations[i].Equals("+"))
                                    operation = lastElements.Sum();

                                else
                                    operation = lastElements.First() - lastElements.Last();

                                stack.Pop();
                                stack.Pop();

                                stack.Push(operation);
                            }
                            else
                            {
                                error = operations[i];
                            }

                            break;
                        default:
                            int itemToAdd = Convert.ToInt32(operations[i].ToString());
                            stack.Push(itemToAdd);
                            break;
                    }
                }

                return stack.First();
            }
            catch
            {
                return -1;
            }
        }
    }
}

