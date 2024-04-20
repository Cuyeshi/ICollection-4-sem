using ICollectionLibrary;
using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
            string[] stringArray = { "apple", "banana", "cherry", "date", "elderberry" };
            float[] floatArray = { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };

            Console.WriteLine(MyCollection<object>.BinarySearch(intArray, 1)); // Выводит: 0
            Console.WriteLine(MyCollection<object>.BinarySearch(stringArray, "date")); // Выводит: 3
            Console.WriteLine(MyCollection<object>.BinarySearch(floatArray, 5.5f)); // Выводит: 4

            Console.ReadLine();
        }
    }
}