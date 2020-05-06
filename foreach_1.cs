using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;

namespace ConsoleApp1
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
        }
    }


    class foreach가능한_객체
    {
        static void Main()
        {
            var obj = new MyEnumerator();
            foreach (int i in obj)
                Console.WriteLine(i);
        }
    }
}
