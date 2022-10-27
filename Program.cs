
int value, maxRange;

var argz = Environment.GetCommandLineArgs();

var input = argz[1];
maxRange = Convert.ToInt32(input);

input = argz[2];
var cycles = Convert.ToInt64(input);

var results = new ResultData(maxRange);
var previousValues = new List<int>();
int n = 0;

Console.BackgroundColor = ConsoleColor.Magenta;
Console.WriteLine("Running....");
while (n < cycles)
{
    bool match = false;
    n++;
    int iteration = 0;
    previousValues.Clear();
    while (!match)
    {
        value = Random.Shared.Next(0,maxRange + 1);             // because it's exclusive need + 1 to max
        iteration++;
        foreach (var val in previousValues)
        {
            if (val == value)
            {
                // Console.WriteLine($"Found match for value {value} on iteration {iteration}. Range was {maxRange}.");
                // Console.WriteLine($"Cycle: {n}");
                results.Iterations!.Add(iteration);
                // Console.WriteLine($"Iteration on match raw: {iteration}");
                match = true;
                break;
            }
        }
        previousValues.Add(value);
    }
}

results.DisplayResults();
Console.ResetColor();
