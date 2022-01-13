namespace MaxZeroProduct;

using System.Collections.Generic;
using System;
using System.Linq;

class Solution
{    
    public int solution(int[] input)
    {
        var pairs = input.Select(number => Pair.FromInt(number));

        if (pairs.Count() == 3)
        {
            var sum = Pair.Sum(
                pairs.ElementAt(0),
                pairs.ElementAt(1),
                pairs.ElementAt(2));
            return sum.ZerosCount();
        }

        var set = new HashSet<Pair>();
        set.UnionWith(pairs
            .OrderByDescending(t => t.Twos)
            .Take(2));
        set.UnionWith(pairs
            .OrderByDescending(t => t.Fives)
            .Take(2));
        set.UnionWith(pairs
            .OrderByDescending(t => Math.Min(t.Fives, t.Twos))
            .Take(2));
        set.UnionWith(pairs
            .OrderByDescending(t => t.Fives + t.Twos)
            .Take(2));        

        return FindMaxZerosCount(set.ToArray());
    }

    private static int FindMaxZerosCount(Pair[] arr)
    {
        var result = 0;

        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    var sum = Pair.Sum(arr[i], arr[j], arr[k]);
                    if (sum.ZerosCount() > result)
                    {
                        result = sum.ZerosCount();
                    }
                }
            }
        }

        return result;
    }
}

class Pair
{
    public int Twos;
    public int Fives;

    public int ZerosCount()
    {
        return Math.Min(Fives, Twos);
    }

    public override string ToString()
    {
        return $"[{Twos},{Fives}]";
    }

    public static Pair FromInt(int number)
    {
        var result = new Pair();        
        if (number == 0)
        {
            return result;
        }
        
        while (IsDividedBy(number, 5))
        {
            result.Fives++;
            number /= 5;
        }

        while (IsDividedBy(number, 2))
        {
            result.Twos++;
            number /= 2;
        }

        return result;
    } 

    public static Pair Sum(Pair pair1, Pair pair2, Pair pair3)
    {
        return new Pair
        {
            Fives = pair1.Fives + pair2.Fives + pair3.Fives,
            Twos = pair1.Twos + pair2.Twos + pair3.Twos
        };
    }

    private static bool IsDividedBy(int number, int divider)
    {
        return number % divider == 0;
    }    
}
