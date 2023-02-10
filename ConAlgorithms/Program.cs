
var nums = new[] { 1, 2, 3, 5, 7, 8, 9, 11, 12, 14, 15, 18, 19, 20, 24, 26, 27, 29 };

for (var i = 1; i <= 30; i++)
{
    Console.WriteLine($"{i, 2}: {BinarySearch(nums, i)}");
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
