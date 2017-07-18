using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    public static class PrintArray
    {
        public static void printArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }
    }
    class Program
    {
        int[] array = new int[10] { 3, 2, 1, 7, 10, 6, 4, 9, 5, 8 };

        public void printArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }

        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.WriteLine("Basic array:");
            prog.printArray();
            //Console.WriteLine("\n----------------------");
            //Console.WriteLine("Bubble sort");
            //prog.BubbleSort();

            //Console.WriteLine("\n----------------------");
            //Console.WriteLine("Insertion sort");
            //prog.InsertionSort();

            //Console.WriteLine("\n----------------------");
            //Console.WriteLine("Selection sort");
            //prog.SelectionSort();

            //Console.WriteLine("\n----------------------");
            //Console.WriteLine("ShellSort sort");
            //prog.ShellSort();

           // Console.WriteLine("\n----------------------");
           // Console.WriteLine("MergeSort sort");
           //int[] a = prog.MergeRecursionDivide(prog.array);
           // foreach (int item in a)
           // {
           //     Console.Write(item.ToString() + " ");
           // }
           // Console.Read();

            Console.WriteLine("\n----------------------");
            Console.WriteLine("Quick Sort");
            prog.QuckSort(prog.array, 0, prog.array.Length-1);

            foreach (int item in prog.array)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.Read();

            //lastEl = array.Length - 1;
            //firstEl = array.Length - lastEl;

            //Console.WriteLine("\n----------------------");
            //Console.Write("Recursia Factorial Count");
            //Console.Write("Recursia Factorial Count: Factorial from number - " + prog.array.Length + " is :");
            //Console.WriteLine(prog.RecursiaFactorialCount(prog.array.Length));

            Console.ReadKey();
        }

        // { 3, 2, 1, 7, 10, 6, 4, 9, 5, 8 };
        public void BubbleSort()//*********************BUBBLESORT
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                bool changed = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        changed = true;
                    }
                }
                PrintArray.printArray(array); // just show every sort step
                Console.WriteLine();
                if (!changed)
                {
                    break;
                }
            }
        }

        public void SelectionSort()//Выборка, когда принимаем что один елемент уже минимальный The time complexity of selection sort is O(n2)
        {
            int k;
            int v;
            for (int i = 0; i < array.Length - 1; i++)
            {
                k = i;                                  //Set Index For Min Value
                v = array[i];                           //Set Min item
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < v)
                    {
                        k = j;
                        v = array[j];
                    }
                }
                array[k] = array[i];
                array[i] = v;
                PrintArray.printArray(array); // just show every sort step
                Console.WriteLine();
            }
        }

        public void InsertionSort()//**********************Вставками
        {
            int Temp;
            for (int i = 1; i < array.Length; i++)
            {
                Temp = array[i];      // JUST SET Value in TEMP
                int j = i - 1;        // Previos [i] element is already SORTED
                while (j >= 0 && Temp < array[j])// j >= 0 important becouse forbiden [-1];
                {
                    array[j + 1] = array[j]; // [j+1] is Next after [j], in First STEP [j+1] == [i], but after second cicle step [j+1] != [i] VERY IMPORTANT
                    j--;
                }
                array[j + 1] = Temp; //WE USE [j+1] becouse the Last action in cicle j-- AND after second step [j+1] != [i]                           
                PrintArray.printArray(array); // just show every sort step
                Console.WriteLine();
            }
        }

        public void ShellSort()            //SHELL SHORT
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2) // Divide Array with gap(разрыв) n/2
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int temp = array[i];// JUST SET Value in TEMP
                    int j = i - gap;
                    while (j >= 0 && temp < array[j])
                    {
                        array[j + gap] = array[j];
                        j -= gap;
                    }
                    array[j + gap] = temp;
                    PrintArray.printArray(array);
                    Console.WriteLine();
                }
            }
        }


        //QuckSort Hoara's Sort
        public void QuckSort(int[] array, int firstEl, int lastEl)
        {          
            //lastEl = array.Length - 1;
            //firstEl = array.Length - lastEl;
            int midEl = (firstEl + lastEl) / 2;
            int i = firstEl;
            int j = lastEl;
            int temp;

            while (i <= j)
            {
                while(array[i] < array[midEl])
                {
                    i++;
                }
                while(array[j] > array[midEl])
                {
                    j--;
                }
                if(i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (firstEl < j)
            {
                QuckSort(array,firstEl,j);
            }

            if(lastEl > i)
            {
                QuckSort(array,i,lastEl);
            }
        }



        //Слияние MergeSort  (recursion way)
        public int[] MergeRecursionDivide(int[] array) //Слияние
        {
            if (array.Length > 1)
            {
                //Parts of new arrays is empty
                int[] left = new int[array.Length / 2]; //Created two parts of array after divided
                int[] right = new int[array.Length - left.Length];//Important, second part is ar.length - first.Length

                for (int i = 0; i < left.Length; i++)//add value from array in first left Arr
                {
                    left[i] = array[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = array[left.Length + i];
                }

                //if arrays part is more than 1, we call Recursion Divide
                if (left.Length > 1)
                {
                    left = MergeRecursionDivide(left);
                }
                if (right.Length > 1)
                {
                    right = MergeRecursionDivide(right);
                }
                array = MergeSort(left, right);
            }

            return array;
        }

        public int[] MergeSort(int[] lPart , int[] rPart)
        {
            int[] newArray = new int[lPart.Length + rPart.Length]; //Add NEW third Array Which combine separate parts
            int i = 0; //index for third common array
            int lP = 0; // index for LeftPartArr
            int rP = 0; // index for RightPartArr

            //Sort by compare
            for (; i < newArray.Length; i++)
            {
                //если правая часть уже использована, дальнейшее движение происходит только в левой
                //проверка на выход правого массива за пределы
                if (rP >= rPart.Length)
                {
                    newArray[i] = lPart[lP];
                    lP++;
                }
                //проверка на выход за пределы левого массива и сравнение текущих значений обоих массивов
                else if (lP < lPart.Length && lPart[lP] < rPart[rP])
                {
                    newArray[i] = lPart[lP];
                    lP++;
                }
                else//(rPart[rP] < lPart[lP])
                {
                    newArray[i] = rPart[rP];
                    rP++;
                }
            }

            return newArray;
        }

        public int RecursiaFactorialCount(int factorialParams)
        {
            if (factorialParams == 1)
            {
                return factorialParams;
            }
            else
            {
                return factorialParams * RecursiaFactorialCount(factorialParams - 1);
            }
        }

    }
}
