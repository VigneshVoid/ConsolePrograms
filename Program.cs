using System;
using System.Collections.Generic;
/// <summary>
/// Find minimum number of swaps to bring largest number to centre
/// 
/// Sample Input
/// 7
///3 3
///1 2 3
///4 5 6
///7 8 9
///4 3
///9 7 7
///4 2 8
///9 6 6
///8 3 2
///1 6
///1 5 2 3 4 5
///6 1
///3
///2
///1
///1
///2
///3
///2 2
///1 1
///1 1
///1 7
///2 3 1 2 1 2 3
///1 1
///2
/// </summary>
public class Solution
{
    public static void Main()
    {
        int number = System.Convert.ToInt32(Console.ReadLine());
        List<string> answers = new List<string>();
        for (var i = 0; i < number; i++)
        {
            List<string> centres = new List<string>();
            List<string> positions = new List<string>();

            var mnValues = Console.ReadLine();
            string[] mn = mnValues.Split(' ');
            double m = System.Convert.ToDouble(mn[0]) - 1;
            double n = System.Convert.ToDouble(mn[1]) - 1;
            int largestNumber = 0;
            if (m % 2 == 0 && n % 2 == 0)
            {
                centres.Add((m / 2).ToString() + "," + (n / 2).ToString());
            }
            else if (m % 2 > 0 && n % 2 == 0)
            {
                centres.Add(Math.Floor((double)(m / 2)).ToString() + "," + (n / 2).ToString());
                centres.Add(Math.Ceiling((double)(m / 2)).ToString() + "," + (n / 2).ToString());
            }
            else if (m % 2 == 0 && n % 2 < 0)
            {
                centres.Add((m / 2).ToString() + "," + Math.Floor((double)(n / 2)).ToString());
                centres.Add((m / 2).ToString() + "," + Math.Ceiling((double)(n / 2)).ToString());
            }
            else
            {
                centres.Add(Math.Floor((double)(m / 2)).ToString() + "," + Math.Floor((double)(n / 2)).ToString());
                centres.Add(Math.Floor((double)(m / 2)).ToString() + "," + Math.Ceiling((double)(n / 2)).ToString());
                centres.Add(Math.Ceiling((double)(m / 2)).ToString() + "," + Math.Floor((double)(n / 2)).ToString());
                centres.Add(Math.Ceiling((double)(m / 2)).ToString() + "," + Math.Ceiling((double)(n / 2)).ToString());

            }
            for (var r = 0; r <= m; r++)
            {
                var rowValues = Console.ReadLine();
                string[] rowValuesString = rowValues.Split(' ');
                for (var c = 0; c < rowValuesString.Length; c++)
                {
                    int array = System.Convert.ToInt32(rowValuesString[c]);
                    if (array > largestNumber)
                    {
                        largestNumber = array;
                        positions.Clear();
                        positions.Add(r.ToString() + "," + c.ToString());
                    }
                    else if (array == largestNumber)
                    {
                        positions.Add(r.ToString() + "," + c.ToString());
                    }
                }
            }
            int leastSwap = int.MaxValue;
            foreach (var centre in centres)
            {
                var centrevalues = centre.Split(',');
                int cRow = System.Convert.ToInt32(centrevalues[0]);
                int cCol = System.Convert.ToInt32(centrevalues[1]);
                foreach (var position in positions)
                {
                    var positionvalues = position.Split(',');

                    int pRow = System.Convert.ToInt32(positionvalues[0]);
                    int pCol = System.Convert.ToInt32(positionvalues[1]);

                    var Sol1 = Math.Abs(cRow - pRow);
                    var Sol2 = Math.Abs(cCol - pCol);
                    var currentSwapCount = Sol1 + Sol2;

                    leastSwap = leastSwap > currentSwapCount ? currentSwapCount : leastSwap;

                }

            }

            answers.Add(leastSwap.ToString());
        }
        foreach (var answer in answers)
        {
            Console.WriteLine(answer);
        }
    }
    
}