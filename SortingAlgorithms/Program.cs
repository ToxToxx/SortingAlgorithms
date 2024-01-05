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

            //InsertionSort(numbersArray);
            //BubbleSort(numbersArray);
            //SelectionSort(numbersArray);           
            //WriteQuickSort(numbersArray);
            //WriteBottomUpMergeSort(numbersArray);
            WriteUpDownMergeSort(numbersArray);

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


        static void SwapQuickSort(ref int firstElement, ref int secondElement)
        {
            var temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        static int PartitionQuickSort(int[] numbers, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (numbers[i] < numbers[maxIndex])
                {
                    pivot++;
                    SwapQuickSort(ref numbers[pivot], ref numbers[i]);
                }
            }

            pivot++;
            SwapQuickSort(ref numbers[pivot], ref numbers[maxIndex]);
            return pivot;
        }

        static int[] QuickSort(int[] numbers, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return numbers;
            }

            var pivotIndex = PartitionQuickSort(numbers, minIndex, maxIndex);
            QuickSort(numbers, minIndex, pivotIndex - 1);
            QuickSort(numbers, pivotIndex + 1, maxIndex);

            return numbers;
        }

        static int[] QuickSort(int[] numbers)
        {
            return QuickSort(numbers, 0, numbers.Length - 1);
        }

        static void WriteQuickSort(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Quick Sort: ");
            int[] quickSortOutput = QuickSort(numbers);
            foreach (var num in quickSortOutput)
            {
                Console.Write(num + " ");
            }
        }


        static void BottomUpMergeSort(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                int mid = numbers.Length / 2;
                int[] leftHalf = new int[mid];
                int[] rightHalf = new int[numbers.Length - mid];

                Array.Copy(numbers, 0, leftHalf, 0, mid);
                Array.Copy(numbers, mid, rightHalf, 0, numbers.Length - mid);

                BottomUpMergeSort(leftHalf);
                BottomUpMergeSort(rightHalf);

                int i = 0, j = 0, k = 0;
                while (i < leftHalf.Length && j < rightHalf.Length)
                {
                    if (leftHalf[i] < rightHalf[j])
                    {
                        numbers[k] = leftHalf[i];
                        i++;
                    }
                    else
                    {
                        numbers[k] = rightHalf[j];
                        j++;
                    }
                    k++;
                }

                while (i < leftHalf.Length)
                {
                    numbers[k] = leftHalf[i];
                    i++;
                    k++;
                }

                while (j < rightHalf.Length)
                {
                    numbers[k] = rightHalf[j];
                    j++;
                    k++;
                }
            }
        }
        static void WriteBottomUpMergeSort(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Bottom Up Merge Sort: ");
            BottomUpMergeSort(numbers);
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
        }


        static void Merge(int[] numbers, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (numbers[left] < numbers[right])
                {
                    tempArray[index] = numbers[left];
                    left++;
                }
                else
                {
                    tempArray[index] = numbers[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                numbers[lowIndex + i] = tempArray[i];
            }
        }

        static int[] UpDownMergeSort(int[] numbers, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                UpDownMergeSort(numbers, lowIndex, middleIndex);
                UpDownMergeSort(numbers, middleIndex + 1, highIndex);
                Merge(numbers, lowIndex, middleIndex, highIndex);
            }

            return numbers;
        }

        static int[] UpDownMergeSort(int[] numbers)
        {
            return UpDownMergeSort(numbers, 0, numbers.Length - 1);
        }
        static void WriteUpDownMergeSort(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("UpDownMerge Sort: ");
            int[] mergeSortOutput = UpDownMergeSort(numbers);
            foreach (var num in mergeSortOutput)
            {
                Console.Write(num + " ");
            }
        }

    }
}