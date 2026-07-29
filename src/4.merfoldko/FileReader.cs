using _4.merfoldko.Cities;
using _4.merfoldko.Exceptions;
using _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;
namespace _4.merfoldko;

public class FileReader
{

     public static int ReadConditionFromFile(StreamReader reader)
    {
        int condition = 1;
        string? line = reader.ReadLine();
        if (line != null)
        {
            condition = int.Parse(line);
        }
        return condition;

    }

    public static int[,] ReadTouristsFromFile(StreamReader reader)
    {
        List<int[]> rows = new List<int[]>();
        string? line;
        int groupsPerYear = 3;

        while((line = reader.ReadLine()) != null)
        {
            string[] tourists = line.Split(' ');
            int[] row = new int[groupsPerYear];
            for (int j = 0; j < groupsPerYear; j++)
            {
                row[j] = int.Parse(tourists[j]);
            }
            rows.Add(row);
        }

        int[,] matrix = new int[rows.Count, groupsPerYear];
        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < groupsPerYear; j++)
            {
                matrix[i, j] = rows[i][j];
                Console.Write($"{rows[i][j]}");
            }
            Console.WriteLine("\n");
        }

        return matrix;
    }
}
