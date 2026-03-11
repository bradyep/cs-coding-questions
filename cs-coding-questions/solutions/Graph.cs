using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace cs_coding_questions.solutions
{
  internal class GraphNode(int id, List<int> adjacencyList)
  {
    protected int ID => id;
    protected List<int> AdjacencyList => adjacencyList;
  }
  internal class GraphStructure(List<GraphNode> nodes)
  {
    protected List<GraphNode> Nodes = nodes;
    protected List<int> DFS()
    {
      return new List<int>();
    }

    protected List<int> BFS()
    {
      return new List<int>();
    }

    public override string ToString()
    {
      string json = JsonSerializer.Serialize(this.Nodes, new JsonSerializerOptions { WriteIndented = true });
      
      return json;
    }
  }

  internal class Graph : Solution
  {
    private const char NODE_SEPARATOR = '|';
    private const char EDGE_SEPARATOR = ',';
    private GraphStructure? graph;

    public Graph(Dictionary<string, string> solutionParams, bool? debug = false) : base(solutionParams, debug)
    {
      this.paramsAreValid = this.verifyParams();
    }

    public override bool verifyParams()
    {
      var graphParam = this.SolutionParams.GetValueOrDefault("graph", "");
      if (graphParam == "")
      {
        this.debugLog($"No graph data supplied");

        return false;
      }

      var adjacencyLists = graphParam.Split(NODE_SEPARATOR);
      var nodes = new List<GraphNode>();
      var nodeIndex = 0;
      foreach (var adjacencyList in adjacencyLists)
      {
        var edges = adjacencyList.Split(EDGE_SEPARATOR).Select(int.Parse).ToList();
        var node = new GraphNode(nodeIndex, edges);
        nodes.Add(node);
        nodeIndex++;
      }
      this.graph = new GraphStructure(nodes);

      return true;
    }

    public override List<string> solve(SolutionType st)
    {
      if (!this.paramsAreValid) { return ["Invalid Parameters"]; }

      this.debugLog($"SolutionType: {st} | Assembled graph: {this.graph?.ToString() ?? "Null graph"}");

      switch (st)
      {
        default:
          return [];
      }
    }
  }
}
