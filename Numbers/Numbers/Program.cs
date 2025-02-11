
internal class Program
{
    private static void Main(string[] args)
    {
        char[] delimiter = new char[] { '\t' };

        List<int> valuesCollection = new List<int>();

        using (var f = new StreamReader(@"Data/numbers.txt"))
        {
            string line = string.Empty;
            while ((line = f.ReadLine()) != null)
            {
                var parts = line.Split(delimiter);

                foreach (var part in parts)
                {
                    string[] numbers = part.Split(' ');

                    foreach (var val in numbers)
                    {
                        var isNumeric = int.TryParse(val, out int n);
                        if (isNumeric)
                        {
                            valuesCollection.Add(n);
                        }
                    }
                }
            }
        }

        var Top5Numbers = valuesCollection
        .GroupBy(x => x)
        .Select(x => new { Number = x.Key, Count = x.Count() })
        .OrderByDescending(x => x.Count)
        .ToArray().Take(5);
        foreach (var number in Top5Numbers)
        {
            Console.WriteLine(number);
        }
    }
}