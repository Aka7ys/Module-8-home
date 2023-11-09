using System;
using System.Collections.Generic;

class Indexer
{
    private List<int> values = new List<int>();

    public int this[int index]
    {
        get
        {
            if (index < values.Count)
            {
                return values[index];
            }
            else
            {
                return 0; 
            }
        }
        set
        {
            if (index < values.Count)
            {
                values[index] = value * value;
            }
            else
            {
                while (index >= values.Count)
                {
                    values.Add(0);
                }
                values[index] = value * value;
            }
        }
    }
}

class PaymentCalculator
{
    public double CalculatePayments(int area, int residents, string season, bool hasDiscount)
    {
        double heatingRate = season == "autumn" || season == "winter" ? 10 : 8;
        double waterRate = 5;
        double gasRate = 7;
        double repairRate = 15;

        double heatingCost = area * heatingRate;
        double waterCost = residents * waterRate;
        double gasCost = residents * gasRate;
        double repairCost = area * repairRate;

        double totalCost = heatingCost + waterCost + gasCost + repairCost;

        if (hasDiscount)
        {
            totalCost *= 0.7; 
        }

        return totalCost;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Indexer indexer = new Indexer();
        indexer[0] = 5;
        indexer[1] = 3;
        Console.WriteLine(indexer[0]); 
        Console.WriteLine(indexer[1]); 

        int area = 100; 
        int residents = 3;
        string season = "winter"; 
        bool hasDiscount = true;

        PaymentCalculator calculator = new PaymentCalculator();
        double totalCost = calculator.CalculatePayments(area, residents, season, hasDiscount);

        Console.WriteLine($"Итоговая сумма: {totalCost}");

        Console.ReadLine();
    }
}
