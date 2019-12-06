using System;
using System.Linq;

namespace adventofcode2019 {
  class Day2 {
    int[] intCodes;

    public Day2(string path) {
      string input = System.IO.File.ReadAllText(@path);
      intCodes = input.Split(',').Select(s => Int32.Parse(s)).ToArray();
      int[] intCodesCopy = (int[]) intCodes.Clone();

      int noun = 0;
      int verb = 0;

      for (noun = 0; noun < 100; noun++) {
        for (verb = 0; verb < 99; verb++) {
          intCodes = (int[]) intCodesCopy.Clone();
          var result = calculate(noun, verb);

          if (result == 19690720) {
            Console.WriteLine("Noun: " + noun + " Verb: " + verb);
          }
        }
      }
    }

    private int calculate(int noun, int verb) {
      int currentIndex = 0;
      intCodes[1] = noun;
      intCodes[2] = verb;

      while (currentIndex < intCodes.Length) {
        var opCode = intCodes[currentIndex];

        if (opCode == 99) {
          return intCodes[0];
        } else if (opCode == 1) {
          Add(
            intCodes,
            intCodes[currentIndex + 1],
            intCodes[currentIndex + 2],
            intCodes[currentIndex + 3]
          );
        } else if (opCode == 2) {
          Multiply(
            intCodes,
            intCodes[currentIndex + 1],
            intCodes[currentIndex + 2],
            intCodes[currentIndex + 3]
          );
        } else {
          Console.WriteLine("Wrong opcode:" + opCode);
          return 0;
        }

        currentIndex += 4;
      }

      return 0;
    }

    private void Add(int[] sequence, int index1, int index2, int dest) {
      var summand1 = sequence[index1];
      var summand2 = sequence[index2];
      sequence[dest] = summand1 + summand2;
    }

    private void Multiply(int[] sequence, int index1, int index2, int dest) {
      var mul1 = sequence[index1];
      var mul2 = sequence[index2];
      sequence[dest] = mul1 * mul2;
    }
  }
}
