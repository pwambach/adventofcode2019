using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019 {
  class Day8 {
    int width = 25;
    int height = 6;

    public Day8(string path) {
      var digits = System.IO.File
        .ReadAllText(@path)
        .Trim()
        .ToCharArray()
        .Select(c => Int32.Parse(c.ToString()))
        .ToList();

      int numLayers = digits.Count() / (width * height);

      var layers = Enumerable
        .Range(0, numLayers)
        .Select(i => digits.GetRange(i * width * height, width * height));

      // Part 1
      var layerWithFewestZeros = layers
        .OrderBy(layer => layer.Where(value => value == 0).Count())
        .First();
      var numOnes = layerWithFewestZeros.Where(value => value == 1).Count();
      var numTwos = layerWithFewestZeros.Where(value => value == 2).Count();

      Console.WriteLine("{0} * {1} = {2}", numOnes, numTwos, numOnes * numTwos);

      // Part 2
      var pixels = Enumerable
        .Range(0, width * height)
        .Select(index => layers
          .Select(layer => layer[index])
          .Where(value => value < 2)
          .First()
        ).ToArray();

      for (int h = 0; h < height; h++) {
        for (int w = 0; w < width; w++) {
          int index = h * width + w;
          Console.Write(pixels[index] > 0 ? "X" : " ");
        }
        Console.WriteLine("");
      }
    }
  }
}
