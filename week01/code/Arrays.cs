using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {

        if (length <= 0)
        {
            return new double[0];
        }

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }
    public static void RotateListRight(List<int> data, int amount)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int n = data.Count;
        if (n == 0)
        {
            return;
        }


        amount = amount % n; 
        if (amount == 0)
        {
            return;
        }

        int splitIndex = n - amount; 

        List<int> right = data.GetRange(splitIndex, amount);
        List<int> left = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(right);
        data.AddRange(left);
    }
}
