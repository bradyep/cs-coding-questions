using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

    private (string left, string right) SplitBranches(string content)
    {
      int depth = 0;
      for (int i = 0; i < content.Length; i++)
      {
        if (content[i] == '(') depth++;
        else if (content[i] == ')') depth--;
        else if (content[i] == ',' && depth == 0)
        {
          return (content.Substring(0, i), content.Substring(i + 1));
        }
      }
      return ("", "");
    }

    /// <summary>
    /// Recursive method used to generate binary tree nodes from a string
    /// </summary>
    /// <param name="nodeDesc"></param>
    /// <returns></returns>
    private bool CreateBinaryTreeNodeFromString(string nodeDesc)
    {
      debugLog($"nodeDesc: {nodeDesc}");
      // Start of string tells us the int value for this node
      Match valueMatch = Regex.Match(nodeDesc, @"^\d+");
      if (valueMatch.Success)
      {
        int nodeValue = int.Parse(valueMatch.Value);
        debugLog($"Set node value to: {nodeValue}");
        
        // Extract content between the outer parentheses
        Match childMatch = Regex.Match(nodeDesc, @"^\d+\((.+)\)$");
        string left = "";
        string right = "";
        
        if (childMatch.Success)
        {
          string innerContent = childMatch.Groups[1].Value;
          (left, right) = SplitBranches(innerContent);
        }

        debugLog($"Left value: {left} | Right value: {right}");
      } 
      else
      {
        this.debugLog($"Could not get value for the node");
        return false;
      }

      return false;
    }

    public override bool verifyParams()
    {
      var nodesParam = this.SolutionParams.GetValueOrDefault("nodes", "");
      if (nodesParam == "")
      {
        this.debugLog($"No nodes supplied");

        return false;
      }
      //var nodeValues = nodesParam.Split(NODE_DATA_SEPARATOR).ToList();
      CreateBinaryTreeNodeFromString(nodesParam);
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
