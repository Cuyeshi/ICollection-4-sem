using System;
using ICollectionLibrary;

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию
        CustomCollection<int> collection = new CustomCollection<int>
        {
            // Добавляем элементы в коллекцию
            1,
            3,
            5,
            7,
            9
        };

        // Создаем массив для выполнения поиска
        int[] array = new int[collection.Count];
        int index = 0;
        foreach (int item in collection)
        {
            array[index++] = item;
        }

        // Выполняем поиск элемента в коллекции
        int elementToFind = 5;
        index = BinarySearch.Search(array, elementToFind);

        // Проверяем результат поиска
        if (index != -1)
        {
            Console.WriteLine($"Element {elementToFind} found at index {index}");
        }
        else
        {
            Console.WriteLine($"Element {elementToFind} not found in the collection");
        }
    }
}
