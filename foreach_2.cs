﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = 1;

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        //IEnumerator
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        //IEnumerator
        public bool MoveNext()
        {
            if(position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        //IEnumerable
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
            }
        }
    }


    class MainApp
    {
        static void Main()
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            foreach (int e in list)
                Console.WriteLine(e);
        }
    }
}
