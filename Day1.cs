public class Day1
{
    public static void Part1(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int total = 0;
        foreach (var line in lines)
        {
            int first = 0;
            int last = 0;
            Console.WriteLine(line);
            foreach (var item in line.ToCharArray())
            {
                if (Char.IsDigit(item))
                {
                    var digit = int.Parse(item.ToString());
                    if (first == 0)
                    {
                        first = digit;
                    }
                    last = digit;
                }
            }
            Console.WriteLine($"First: {first} Last: {last}");
            int sum = (first * 10) + last;
            Console.WriteLine($"Sum: {sum}");
            total += sum;
        }
        Console.WriteLine($"Total: {total}");
    }

    public static void Part2(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Dictionary<string, int> digits = new Dictionary<string, int> {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        int total = 0;
        foreach (var line in lines)
        {
            int first = 0;
            int last = 0;
            Console.WriteLine(line);
            for (var i = 0; i < line.Length; i++)
            {
                var item = line[i];
                if (Char.IsDigit(item))
                {
                    var digit = int.Parse(item.ToString());
                    if (first == 0)
                    {
                        first = digit;
                    }
                    last = digit;
                    Console.Write($"{digit}, ");
                    continue;
                }

                var restOftheLine = line.Substring(i);
                foreach (var key in digits.Keys)
                {
                    if (restOftheLine.StartsWith(key))
                    {
                        var digit = digits[key];
                        if (first == 0)
                        {
                            first = digit;
                        }
                        last = digit;
                        Console.Write($"{digit}, ");
                        continue;
                    }
                }
            }
            Console.WriteLine($"\nFirst: {first} Last: {last}");
            int sum = (first * 10) + last;
            Console.WriteLine($"Sum: {sum}");
            total += sum;
        }
        Console.WriteLine($"Total: {total}");
    }
}