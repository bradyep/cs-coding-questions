using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.solutions
{
  internal class LinkedListNode
  {
    private readonly string data;

    public LinkedListNode(string data, LinkedListNode? nextNode = null)
    {
      this.data = data;
      this.NextNode = nextNode;
    }

    public string Data => data;
    public LinkedListNode? NextNode { get; set; }

    public override string ToString()
    {
      return NextNode is { } nn ? $"{data} {nn.Data} " : $"{data}";
    }
  }
  public class LinkedList : Solution
  {
    private const char NODE_DATA_SEPARATOR = '_';
    private LinkedListNode? HeadNode;

    public LinkedList(Dictionary<string, string> solutionParams, bool? debug = false) : base(solutionParams, debug)
    {
      this.paramsAreValid = this.verifyParams();
    }

    private void CreateLinkedListFromValues(List<string> values)
    {
      var firstValue = values.FirstOrDefault("");
      this.HeadNode = new LinkedListNode(firstValue);
      this.debugLog($"Set HeadNode value to: {firstValue}");
      var lastNode = this.HeadNode;
      var remainingValues = values.Skip(1).ToList();
      foreach (var value in remainingValues)
      {
        lastNode.NextNode = new LinkedListNode(value);
        this.debugLog($"Added a node with value: {value}");
      }
    }

    public override bool verifyParams()
    {
      var valuesParam = this.SolutionParams.GetValueOrDefault("values", "");
      if (valuesParam == "")
      {
        this.debugLog($"No values to use");

        return false;
      }
      var nodeValues = valuesParam.Split(NODE_DATA_SEPARATOR).ToList();
      CreateLinkedListFromValues(nodeValues);

      return true;
    }

    public override List<string> solve(SolutionType st)
    {
      return [];
    }
  }
}
