
var nums = new int[20];

generateRandom:
for (var i = 0; i < nums.Length; i++)
    nums[i] = Random.Shared.Next() % 100;


PrintArray(ref nums);
InsertionSort(ref nums);
PrintArray(ref nums);

Console.Write("Press ENTER "); Console.ReadKey(); goto generateRandom;

void PrintArray<T>(ref T[] arr)
{
    Console.Write("[ ");
    foreach (var item in arr)
        Console.Write($"{item, 2} ");
    Console.WriteLine("]");
}

bool BinarySearch<T>(T[] arr, T item) where T : IComparable<T>
{
    if (arr.Length == 0)
        return false;
    
    var midpoint = (arr.Length - 1) / 2;

    return arr[midpoint].CompareTo(item) switch
    {
        0 => true,
        < 0 => BinarySearch(arr[(midpoint + 1) ..], item),
        > 0 => BinarySearch(arr[.. midpoint], item)
    };
}

T[] QuickSort<T>(IReadOnlyList<T> arr) where T : IComparable<T>
{
    (T[] lt, T[] gt, T[] repeats) Partition(T pivot)
    {
        var lt = Array.Empty<T>();
        var gt = Array.Empty<T>();
        var repeats = Array.Empty<T>();

        foreach (var item in arr)
        {
            switch (pivot.CompareTo(item))
            {
                case 0:
                    Array.Resize(ref repeats, repeats.Length + 1);
                    repeats[^1] = pivot;
                    break;
                case < 0:
                    Array.Resize(ref gt, gt.Length + 1);
                    gt[^1] = item;
                    break;
                case > 0:
                    Array.Resize(ref lt, lt.Length + 1);
                    lt[^1] = item;
                    break;
            }
        }

        return (lt, gt, repeats);
    }

    var partition = Partition(arr[^1]);

    if (partition.lt.Length > 1)
        partition.lt = QuickSort(partition.lt);
    if (partition.gt.Length > 1)
        partition.gt = QuickSort(partition.gt);

    return partition.lt.Concat(partition.repeats).Concat(partition.gt).ToArray();
}

void BubbleSort<T>(ref T[] arr) where T : IComparable<T>
{
    var swapsCount = 1;
    while (swapsCount > 0)
    {
        swapsCount = 0;
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(arr[i - 1]) >= 0) continue;
            
            (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
            swapsCount++;
        }
    }
}

T[] MergeSort<T>(T[] arr) where T : IComparable<T>
{
    if (arr.Length == 1)
        return arr;

    var midpoint = arr.Length / 2;
    
    var left = MergeSort(arr[..midpoint]);
    var leftIter = 0;
    
    var right = MergeSort(arr[midpoint..]);
    var rightIter = 0;

    var merged = new T[left.Length + right.Length];
    var mergedIter = 0;

    while (leftIter != left.Length && rightIter != right.Length)
    {
        if (left[leftIter].CompareTo(right[rightIter]) <= 0)
        {
            merged[mergedIter] = left[leftIter];
            mergedIter++;
            leftIter++;
        }
        else
        {
            merged[mergedIter] = right[rightIter];
            mergedIter++;
            rightIter++;
        }
    }

    if (leftIter != left.Length)
    {
        for (var i = leftIter; i < left.Length; i++)
        {
            merged[mergedIter] = left[i];
            mergedIter++;
        }
    }
    if (rightIter != right.Length)
    {
        for (var i = rightIter; i < right.Length; i++)
        {
            merged[mergedIter] = right[i];
            mergedIter++;
        }
    }

    return merged;
}

void InsertionSort<T>(ref T[] arr) where T : IComparable<T>
{
    for (var i = 1; i < arr.Length; i++)
    {
        var j = i;
        while (j > 0 && arr[j - 1].CompareTo(arr[j]) > 0)
        {
            (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
            j--;
        }
    }
}
