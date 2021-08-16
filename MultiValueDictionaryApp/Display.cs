using System;
using System.Collections.Generic;
namespace MultiValueDictionaryApp
{
    public static class Display
    {
        static Display()
        {
        }

        public static void DisplayText(String text)
        {
            Console.WriteLine(") " + text);
        }

        public static void DisplayList(List<String> list)
        {
            if(list.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }

            for(int count = 0; count < list.Count; count++)
            {
                Console.WriteLine("{0}) {1}", count+1, list[count]);
            }
        }
    }
}
