public class Day2
{


    public static void Part1(string filePath)
    {
        Dictionary<string, int> totalCubes = new Dictionary<string, int>{
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        string[] lines = File.ReadAllLines(filePath);
        int total = 0;
        foreach (var line in lines)
        {
            var part1 = line.Split(':');
            var gameId = int.Parse(part1[0].Replace("Game ", ""));
            var sets = part1[1].Split(';');
            bool isValid = true;
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    var cubeArr = cube.Trim().Split(' ');
                    var cubeNumber = int.Parse(cubeArr[0].Trim());
                    var cubeColor = cubeArr[1];
                    if (cubeNumber > totalCubes[cubeColor])
                    {
                        isValid = false;

                        Console.WriteLine(cube);
                        break;
                    }
                }
                if (!isValid)
                {
                    break;
                }
            }
            if (isValid)
            {
                total += gameId;
                Console.WriteLine(gameId);
            }
        }
        Console.WriteLine($"Total: {total}");
    }


    
    public static void Part2(string filePath)
    {

        string[] lines = File.ReadAllLines(filePath);
        int total = 0;
        foreach (var line in lines)
        {
            Dictionary<string, int> minCubes = new Dictionary<string, int>{
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
            var part1 = line.Split(':');
            var gameId = int.Parse(part1[0].Replace("Game ", ""));
            var sets = part1[1].Split(';');
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    var cubeArr = cube.Trim().Split(' ');
                    var cubeNumber = int.Parse(cubeArr[0].Trim());
                    var cubeColor = cubeArr[1];
                    if (cubeNumber > minCubes[cubeColor])
                    {
                        minCubes[cubeColor] = cubeNumber;
                    }
                }

            }
            Console.WriteLine($" Red: {minCubes["red"]} Blue: {minCubes["blue"]} Green: {minCubes["green"]}");
            var power = minCubes["red"] * minCubes["green"] * minCubes["blue"];
            Console.WriteLine(power);
            total += power;
        }
        Console.WriteLine($"Total: {total}");
    }


    
}