using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;

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
      switch (st)
      {
        default:
          return this.HeadNode is { } hn ? Initial(this.HeadNode) : [];
      }
    }

    private List<string> Initial(LinkedListNode headNode)
    {
      if (this.HeadNode is null)
      {
        this.debugLog($"HeadNode is null, returning empty array");

        return [];
      }

      var output = new List<string>();
      LinkedListNode lastNode = this.HeadNode;
      LinkedListNode currentNode = this.HeadNode;

      var continueWork = true;
      while (continueWork)
      {
        if (lastNode == currentNode) // Dealing with the HeadNode
        {
          // Head becomes the tail
          currentNode.NextNode = null;
          if (lastNode.NextNode is null)
          {
            this.debugLog($"Only had one node in the list, we're done");
            continueWork = false;
          }
          else
          {
            // On to the next ...
            currentNode = lastNode.NextNode;
          }
        }
        else
        {
          if (currentNode is null)
          {
            this.debugLog($"current node is null, this should not happen");
            continueWork = false;
          }
          else
          {
            if (currentNode.NextNode is null)
            {
              // We've reached the old tail
              continueWork = false;
            }
            currentNode.NextNode = lastNode;
            // On to the next
            currentNode = currentNode.NextNode;
          }
        }
      }

      return output;
    }
  }
}
