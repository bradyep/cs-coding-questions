using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace cs_coding_questions.solutions
{
  internal class GraphNode(int id, List<int> adjacencyList)
  {
    public int ID => id;
    public List<int> AdjacencyList => adjacencyList;
    public override string ToString()
    {
      return $"(ID: {ID}, edges: {string.Join(',', AdjacencyList)})";
    }
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

    public bool CheckEdges()
    {
      var validIds = this.Nodes.Select(n => n.ID).ToList();
      var allEdgeIds = this.Nodes.SelectMany(n => n.AdjacencyList).Distinct().ToList();
      foreach (var edgeId in allEdgeIds)
      {
        if (!validIds.Contains(edgeId))
        {
          return false;
        }
      }

      return true;
    }

    public override string ToString()
    {
      return string.Join('|', Nodes.Select(n => n.ToString()));
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

      if (!this.graph.CheckEdges()) 
      {
        debugLog($"Some edges have bad node ids");

        return false; 
      } else
      {
        debugLog($"All edge IDs valid");
      }

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
