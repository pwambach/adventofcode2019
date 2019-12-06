using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019 {
  public class Node {
    public Node parent;
    public string id;

    public Node(string id) {
      this.id = id;
    }
  }

  class Day6 {
    private List<Node> nodes;

    public Day6(string path) {
      string[] lines = System.IO.File.ReadAllLines(@path);
      var orbits = lines.Select(line => line.Split(")"));
      nodes = new List<Node>();

      // create all nodes
      foreach (var orbit in orbits) {
        string nodeId = orbit[1];

        if (findNode(nodeId) == null) {
          nodes.Add(new Node(nodeId));
        }
      }

      // add the first parent manually
      nodes.Add(new Node(orbits.First() [0]));

      // set parents
      foreach (var orbit in orbits) {
        string parentId = orbit[0];
        string nodeId = orbit[1];
        Node node = findNode(nodeId);
        node.parent = findNode(parentId);
      }

      Console.WriteLine("Part 1: " + getTotalOrbits(nodes));
      Console.WriteLine("Part 2: " + getPathCount("YOU", "SAN"));
    }

    private Node findNode(string id) {
      return nodes.Find(n => n.id.Equals(id));
    }

    int getTotalOrbits(List<Node> nodes) {
      int total = 0;

      foreach (Node n in nodes) {
        total += getParentsIds(n).Count();
      }

      return total;
    }

    private List<string> getParentsIds(Node node) {
      var parents = new List<string>();

      while (node.parent != null) {
        parents.Add(node.parent.id);
        node = node.parent;
      }

      return parents;
    }

    private int getPathCount(string start, string end) {
      var parentIds1 = getParentsIds(findNode("YOU"));
      var parentIds2 = getParentsIds(findNode("SAN"));
      var intersections = parentIds1.Intersect(parentIds2);
      var firstIntersection = intersections.First();
      var p1Index = parentIds1.FindIndex(x => x.Equals(firstIntersection));
      var p2Index = parentIds2.FindIndex(x => x.Equals(firstIntersection));
      return p1Index + p2Index;
    }
  }
}
