using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormatNumbers
{
    public static string[] format_name = new[]
    {
        "", "K", "M", "B", "S"
    };

    public static string FormatNumber(float num)
    {
        if (num == 0)
            return "0";

        int i = 0;
        while(i+1 < format_name.Length && num >= 1000f)
        {
            num /= 1000f;
            i++;
        }

        return num.ToString("#.##") + format_name[i];
    }


    //to use this format call
    //FormatNumbers.FormatNumber(100500);
}
