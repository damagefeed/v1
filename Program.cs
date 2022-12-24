class v1
{
    static void Main()
    {
        var random = new Random(DateTime.Now.Millisecond);
        int[] returningArray = SortRandomArray(-((int)Math.Pow(10, 9)), (int)Math.Pow(10, 9) + 1, random.Next(1, (int)Math.Pow(10, 5) + 1), random);

        int leftBorder = random.Next(0, returningArray.Length - 1);
        int rightBorder = random.Next(leftBorder + 1, returningArray.Length);

        Console.WriteLine($"Bottom left border is: {leftBorder}");
        Console.WriteLine($"Top right border is: {rightBorder}\n");
        int x = int.Parse(Console.ReadLine());
        int result = BinSearch(returningArray, leftBorder, rightBorder, x);
        Console.WriteLine(result);
    }

    static int BinSearch(int[] newArray, int leftBorder, int rightBorder, int x)
    {
        int mid;
        if (x < newArray[leftBorder] && x > newArray[rightBorder])
            return -1;


        while (leftBorder < rightBorder)
        {
            mid = (leftBorder + rightBorder) / 2;

            if (x < newArray[mid])
                rightBorder = mid - 1;

            else if (x > newArray[mid])
                leftBorder = mid + 1;
        }
        mid = (leftBorder + rightBorder) / 2;
        return mid;
    }
    static int[] SortRandomArray(int min, int max, int length, Random? random = null)
    {
        //Проверка левой и правой границы на соответствие условию
        if (min >= max)
            Console.WriteLine($"Error:\t{min} > {max}");

        if (max - min < length)
            Console.WriteLine($"Error: ({max} - {min}) <= {length}");

        random = random ?? new Random(DateTime.Now.Millisecond);
        int[] array = new int[length];

        for (var i = 0; i < length; i++)
        {
            int arrayNum = 0;
            arrayNum = random.Next(min, max);
            array[i] = arrayNum;
        }

        //Пузырьковая сортировка
        for (int i = 0; i < array.Length; i++)
        {
            for (int k = 0; k < array.Length - 1 - i; k++)
            {
                if (array[k] > array[k + 1])
                {
                    int replacingNum = array[k];
                    array[k] = array[k + 1];
                    array[k + 1] = replacingNum;
                }
            }
        }
        return array;
    }
}
