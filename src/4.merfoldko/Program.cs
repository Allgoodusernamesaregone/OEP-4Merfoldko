using _4.merfoldko.Cities;
using _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;

namespace _4.merfoldko;

internal class Program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader("C:\\Users\\kothe\\OneDrive\\Asztali gép\\ELTE\\OEP\\4.merfoldko\\4.merfoldko\\TextFile1.txt");

        int cityCondition = FileReader.ReadConditionFromFile(sr);
        long cityWealth = 20_000_000_000;
        City city = new City(cityCondition, cityWealth);

        int[,] tourists = FileReader.ReadTouristsFromFile(sr);
        Tourist tourist;
        for (int i = 0; i < tourists.GetLength(0); i++) {
            
            tourist = new JapaneseTourists(tourists[i, 0]);
            Console.WriteLine($" ----Japanese tourists arrive----");
            city.Accept(tourist);
            Console.WriteLine($"Status: {tourist.Visiting} Japanese are visiting.");
            Console.WriteLine($"City -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
            city.UpdateState();

            tourist = new WesternTourists(tourists[i, 1]);
            Console.WriteLine($" ----Western tourists arrive----");
            city.Accept(tourist);
            Console.WriteLine($"Status: {tourist.Visiting} Western are visiting.");
            Console.WriteLine($"City -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
            city.UpdateState();

            tourist = new OtherTourists(tourists[i, 2]);
            Console.WriteLine($" ----Other tourists arrive----");
            city.Accept(tourist);
            Console.WriteLine($"Status: {tourist.Visiting} Other are visiting.");
            Console.WriteLine($"City -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
            city.UpdateState();
            
            Console.WriteLine($" ----End Of Year {i + 1}----");
            Console.WriteLine($"CanRenovate: {city.CanRenovate()}");
            city.Renovate();
            Console.WriteLine($"City -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
        }




        // Uncomment if you wish to test by hand
        /*
        string cityName;
        int cityCondition;
        long cityWealth;
        Console.WriteLine("Adja meg a város nevét, állapotát, és vagyonát");
        string[] line = Console.ReadLine()!.Split(' ');
        cityName = line[0];
        cityCondition = int.Parse(line[1]);
        cityWealth = long.Parse(line[2]);

        City city = new City(cityCondition, cityWealth);

        Console.WriteLine("Adja meg az adott évben látogató túristacsoportokat");
        int years = int.Parse(Console.ReadLine()!)!;

        Console.WriteLine("Adja meg a túristák típusát, és menyiségét: ");
        Console.WriteLine("(Japanese Western Other)");
        for (int i = 0; i < years; i++)
        {
            Console.WriteLine($"Adja meg a {i + 1}. túristacsoport típusát, és menyiségét: ");
            string[] touristLine = Console.ReadLine()!.Split(' ');
            string touristType = touristLine[0];
            int touristCount = int.Parse(touristLine[1]);
            Tourist tourist;
            switch (touristType)
            {
                case "Japanese":
                    tourist = new JapaneseTourists(touristCount);
                    break;
                case "Western":
                    tourist = new WesternTourists(touristCount);
                    break;
                case "Other":
                    tourist = new OtherTourists(touristCount);
                    break;
                default:
                    Console.WriteLine("Invalid tourist type, skipping.");
                    continue;
            }
            Console.WriteLine($" ----{touristType} tourists arrive----");
            city.Accept(tourist);
            Console.WriteLine($"Status: {tourist.Visiting} {touristType} are visiting.");
            Console.WriteLine($"{cityName} -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
            city.UpdateState();

        }
        Console.WriteLine($"CanRenovate: {city.CanRenovate()}");
        city.Renovate();
        Console.WriteLine($"{cityName} -> Condition: {city.Condition}, Wealth: {city.Wealth}\n");
        */
    }
}
