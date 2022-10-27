
public class ResultData
{
    public int Range { get; private set; }
    public List<int>? Iterations { get; set; }

    public ResultData(int range)
    {
        Range = range;
        Iterations = new List<int>();
    }

    public void DisplayResults()
    {
        double average = Iterations!.Sum()/Iterations!.Count;
        
        Console.WriteLine($"Average raw: {average}");
        Console.WriteLine($"Over {Iterations.Count} cycles with a range of {Range},\n"+
            $"the average iterations to find a match was {Math.Round(average,2)}\n" +
            $"the mode iterations to find a match was (Iterations: {Mode().Item2}, Value: {Mode().Item1})\n" +
            $"the median iterations to find a match was value: {Median()} \n" +
            $"with a standard deviation of {Math.Round(StandardDeviation(),3)}");
        if (Iterations.Count >= 1000)
        {
            Console.WriteLine($"The sorted values of iterations per cycle (value:count): \n");
            var dict = ListToDictionary();
            foreach (var item in dict)
            {
                Console.Write($"{item.Key}:{item.Value},");
            }
        }
        if (Iterations.Count < 1000)
        {
            Console.WriteLine($"The sorted values of iterations per cycle: \n");
            var s = Iterations;
            s.Sort();
            foreach (var item in s)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("\n");
        }
    }

    private (int, int) Mode()
    {
        int currentMed = 0;
        int currentCount = 0;
        for (int i = 0; i < Iterations!.Count; i++)
        {
            int thisValue = Iterations[i];
            int thisCount = 0;
            for (int j = 0; j < Iterations!.Count; j++)
            {
                if (thisValue == Iterations[j])
                {
                    thisCount++;
                }
            }
            if (thisCount > currentCount)
            {
                currentMed = thisValue;
                currentCount = thisCount;
            }
        }
        return (currentMed, currentCount);
    }

    private int Median()
    {
        var list = Iterations;
        int count = list.Count;
        list.Sort();
        int mid = count / 2;
        if (count % 2 == 0)
        {
            return list[mid + 1];
        }
        return list[mid];

    }

    private double StandardDeviation()
    {
        int count = Iterations!.Count;
        double mean = Iterations.Average();
        List<double> temp = new List<double>();
        foreach (var sample in Iterations)
        {
            var diffSq = Math.Pow(sample - mean, 2);
            temp.Add(diffSq);
        }
        var sumSq = temp.Sum();
        var sumSqMean = sumSq / (count - 1);
        var output = Math.Sqrt(sumSqMean);

        return output;
    }

    private Dictionary<int, int> ListToDictionary()
    {
        var copy = Iterations;
        var result = copy!.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
        return result;
    }
}