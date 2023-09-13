using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.UseCases
{
    public class test1
    {
        public int AssignmentWithStack(string instructions)
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                char[] instructionsArray = instructions.ToCharArray();
                
                for (int i = 0; i < instructionsArray.Length; i++)
                {
                    if (instructionsArray[i] == ' ')
                    {
                        continue;
                    }
                    switch (instructionsArray[i])
                    {
                        case '+':
                            stack.Push(stack.Pop() + stack.Pop());
                            break;
                        case '-':
                            stack.Push(stack.Pop() - stack.Pop());
                            break;
                        case '*':
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                        default:
                            int itemToAdd = Convert.ToInt32(instructionsArray[i].ToString());
                            stack.Push(itemToAdd);
                            break;
                    }
                }
                return stack.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public int AssignmentWithArray(string instructions)
        {
            try
            {
                int index = 0;
                int[] stack = new int[instructions.Length - Regex.Matches(instructions, @"[^\d]").Count];

                char[] instructionsArray = instructions.ToCharArray();
                for (int i = 0; i < instructionsArray.Length; i++)
                {
                    if (instructionsArray[i] == ' ')
                    {
                        continue;
                    }
                    switch (instructionsArray[i])
                    {
                        case '+':
                            stack[index - 2] = stack[index - 1] + stack[index - 2];
                            index--;
                            break;
                        case '-':
                            stack[index - 2] = stack[index - 1] + stack[index - 2];
                            index--;
                            break;
                        case '*':
                            stack[index - 2] = stack[index - 1] * stack[index - 2];
                            index--;
                            break;
                        default:
                            stack[index] = Convert.ToInt32(instructionsArray[i].ToString());
                            index++;
                            break;
                    }
                }
                return stack[index - 1];
            }
            catch
            {
                return -1;
            }
        }
    }
}
