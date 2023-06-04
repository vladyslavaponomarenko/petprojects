using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Math;

class Program
{
    static void Main(string[] args)
    {
        List<double> sample = GenerateSample(100); // Генерувати вибірку на 100 значень
        sample.Sort(); // Ранжувати вибірку

        WriteLine("\n---------------------------");
        Console.WriteLine("Ranked Sample:");
        PrintRangedSample(sample);

        double range = CalculateRange(sample); // Розмах вибірки
        WriteLine("\nThe range of sample:" + range);

        double interval_width = CountIntervalWidth(range);
        WriteLine("The width of the interval: " + interval_width + "\nSo k = " + Round(interval_width));

        int x_start = count_x_start(sample[0], interval_width);
        WriteLine("Starting x = " + x_start);

        Dictionary<string, List<double>> intervals = GroupData(sample, x_start, (int)interval_width); // Вивести згрупований ранжований ряд у вигляді таблиці
        Console.WriteLine("---------------------------");
        
        Console.ReadLine();
    }

    static int count_x_start (double x_min, double interval_width)
    {
        int x_start = (int)Round(x_min - interval_width / 2);
        return x_start;
    }

    static double CountIntervalWidth(double range)
    {
        double interval_number = 1 + 3.3221 * Log10(100);
        double interval_width = range / (1 + 3.3221 * Log10(100));
        return interval_width;
    }
    static List<double> GenerateSample(int sampleSize)
    {
        Random random = new Random();
        List<double> sample = new List<double>();

        WriteLine("Random sample:");
        for (int i = 0; i < sampleSize; i++)
        {
            double randomValue = random.Next(80,120) + random.NextDouble();
            sample.Add(randomValue);
            Write(randomValue + ", ");
        }

        return sample;
    }

    static double CalculateRange(List<double> data)
    {
        double min = data.Min();
        double max = data.Max();
        double range = max - min;
        return range;
    }
   
    static Dictionary<string, List<double>> GroupData(List<double> data, int x_start, int interval_width)
    {
        Dictionary<string, List<double>> groupedData = new Dictionary<string, List<double>>();

        double intervalStart = x_start;
        double intervalEnd = x_start + interval_width;
        double sum = 0;
        double mean;
        double dispersion;
        Dictionary<double, double> intervalMidpoints = new Dictionary<double, double>();

        WriteLine($"Intervals\tMiddle\tFrequency\tRelative frequency\tCumulative Frequency\tCmulative relative frequency");

        // Визначаємо інтервали
        for (int i = 0; intervalStart < data[data.Count-1]; i++) 
        {
            string intervalKey = $"{intervalStart} - {intervalEnd}";
            groupedData[intervalKey] = new List<double>();

            // Групуємо значення відповідно до інтервалу
            foreach (double value in data)
            {
                if (value >= intervalStart && value <= intervalEnd)
                {
                    groupedData[intervalKey].Add(value);
                }
            }

            // Розраховуємо кількість значень у інтервалі
            int frequency = groupedData[intervalKey].Count;

            // Розраховуємо середину інтервалу
            double intervalMidpoint = (intervalStart + intervalEnd) / 2;
            intervalMidpoints.Add(intervalMidpoint, frequency);

            // Розраховуємо частоту, частість, накопичену частоту та накопичену частість
            int cumulativeFrequency = groupedData.Values.SelectMany(x => x).Count(v => v <= intervalEnd);
            double relativeFrequency = (double)frequency / data.Count;
            double cumulativeRelativeFrequency = (double)cumulativeFrequency / data.Count;
            double temp = intervalMidpoint * frequency;
            sum += temp;

            // Виводимо значення в таблицю
            WriteLine($"{intervalStart:F1}-{intervalEnd:F1}\t{intervalMidpoint:F2}\t{frequency}\t\t{relativeFrequency}\t\t\t{cumulativeFrequency}\t\t\t{cumulativeRelativeFrequency}");

            // Оновлюємо значення для наступного інтервалу
            intervalStart = intervalEnd;
            intervalEnd += interval_width;
        }
        mean = sum / 100;
        WriteLine("Average: " + mean);
        double temp2 = 0;
        
        foreach(var item in intervalMidpoints)
        {
            temp2 = temp2 + Pow((item.Key - mean), 2) * item.Value;
        }
        dispersion = temp2 / 100;
        WriteLine("Dispersion = " + dispersion);
        WriteLine("Standard deviation = " + Sqrt(dispersion));
        WriteLine("Coefficient of variation = " + Sqrt(dispersion)/mean * 100 + "%");

        return groupedData;
    }

    static void PrintRangedSample(List<double> data)
    {
        Dictionary<double, int> frequencyTable = new Dictionary<double, int>();

        foreach (double value in data)
        {
            if (frequencyTable.ContainsKey(value)) 
                frequencyTable[value]++;
            else
                frequencyTable[value] = 1;
        }

        foreach (var kvp in frequencyTable.OrderBy(x => x.Key))
        {
            Write(kvp.Key + ", ");
        }
        WriteLine();
    }
}