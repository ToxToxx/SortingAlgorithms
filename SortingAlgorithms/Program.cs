namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 1, 5, 2, 40, 23, 96, 28 };

            Console.WriteLine("Original array: ");
            foreach (var num in numbersArray)
            {
                Console.Write(num + " ");
            }

            InsertionSort(numbersArray);
            BubbleSort(numbersArray);
            SelectionSort(numbersArray);

        }

        static int[] InsertionSort(int[] numbers)
        {
            for (int j = 2; j < numbers.Length; j++)
            {
                int key = numbers[j];
                int i = j - 1;
                while(i >= 0 && numbers[i] > key)
                {
                    numbers[i + 1] = numbers[i];
                    i -= 1;
                }
                numbers[i + 1] = key;
            }
            Console.WriteLine();
            Console.WriteLine("Insertion sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }

        static int[] BubbleSort(int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                for (int j = numbers.Length - 1 - 1; j >= 0; j--)
                {
                    if (numbers[j] <= numbers[j + 1]) continue;
                    int temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Bubble sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }

        static int[] SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minNumber = i;
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minNumber])
                    {
                        minNumber = j;
                    }
                }
                int temp = numbers[minNumber];
                numbers[minNumber] = numbers[i];
                numbers[i] = temp;
            }
            Console.WriteLine();
            Console.WriteLine("Selection sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }
    }
}