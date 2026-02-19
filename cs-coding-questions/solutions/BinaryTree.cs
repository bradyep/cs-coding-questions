using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.solutions
{
  internal class BinaryTreeNode
  {
    private readonly int value;

    public BinaryTreeNode(int value, BinaryTreeNode? left = null, BinaryTreeNode? right = null)
    {
      this.value = value;
      this.Left = left;
      this.Right = right;
    }

    public int Value => value;
    public BinaryTreeNode? Left { get; set; }
    public BinaryTreeNode? Right { get; set; }

    public override string ToString()
    {
      BinaryTreeNode? currentNode = this;
      List<string> output = [];
      while (currentNode is not null)
      {
        output.Add($"({currentNode.Value.ToString()})");
        currentNode = currentNode.Left;
      }
      return String.Join(", ", output);
    }
  }
  internal class BinaryTree : Solution
  {
    private const char NODE_DATA_SEPARATOR = ',';
    private BinaryTreeNode? HeadNode;

    public BinaryTree(Dictionary<string, string> solutionParams, bool? debug = false): base(solutionParams, debug)
    {
      this.paramsAreValid = this.verifyParams();
    }

    private void CreateBinaryTreeFromValues(List<string> values)
    {

    }

    public override bool verifyParams()
    {
      var nodesParam = this.SolutionParams.GetValueOrDefault("nodes", "");
      if (nodesParam == "")
      {
        this.debugLog($"No nodes supplied");

        return false;
      }
      var nodeValues = nodesParam.Split(NODE_DATA_SEPARATOR).ToList();
      CreateBinaryTreeFromValues(nodeValues);
      if (this.HeadNode is null)
      {
        this.debugLog($"HeadNode is null. Something bad happened");

        return false;
      }
      this.debugLog($"Linked Values: {this.HeadNode.ToString()}");

      return true;
    }

    public override List<string> solve(SolutionType st)
    {
      if (!this.paramsAreValid) { return ["Invalid Parameters"]; }

      switch (st)
      {
        default:
          return this.HeadNode is { } ? Initial(this.HeadNode) : [];
      }
    }

    private List<string> Initial(BinaryTreeNode headNode)
    {
      if (this.HeadNode is null)
      {
        this.debugLog($"HeadNode is null, returning empty array");

        return [];
      }

      var output = new List<string>();

      return output;
    }
  }
}
