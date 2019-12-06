using System;
using System.Linq;

namespace adventofcode2019 {
    class Day1 {
        public Day1(string path) {
            string[] lines = System.IO.File.ReadAllLines(@path);
            double total = 0;
            var masses = lines.Select(numberString => double.Parse(numberString));
            var fuels = masses.Select(getFuel);

            foreach (var fuel in fuels) {
                total += (int) fuel;
                double ff = fuel;

                while (getFuel(ff) > 0) {
                    var newFuel = getFuel(ff);
                    total += newFuel;
                    ff = newFuel;
                    Console.WriteLine(ff);
                }
            }

            Console.WriteLine(total);
        }

        double getFuel(double mass) {
            return Math.Floor(mass / 3) - 2;
        }
    }
}
