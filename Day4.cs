using System;
using System.Linq;

namespace adventofcode2019
{
    class Day4
    {
        public Day4 () {

          int total = 0;

          for (int min = 124075; min < 580769; min++)
          {
              int[] digits = min
                .ToString()
                .ToCharArray()
                .Select(x => Int32.Parse(x.ToString()))
                .ToArray();

              int lastDigit = digits.First();
              bool allIncreasing = digits.Skip(1).All(x => {
                bool increases = x >= lastDigit;
                lastDigit = x;
                return increases;
              });

              bool oneDigitExistsExactlyTwice = Enumerable.Range(0, 10)
                // .Where(x => digits.Where(y => y == x).Count() > 1) // part 1
                .Where(x => digits.Where(y => y == x).Count() == 2) // part 2
                .Count() > 0;

              if (allIncreasing && oneDigitExistsExactlyTwice) {
                total++;
              }
          }
          Console.WriteLine(total);
        }

    }
}
