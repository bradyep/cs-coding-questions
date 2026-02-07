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
      LinkedListNode? currentNode = this;
      List<string> output = [];
      while (currentNode is not null)
      {
        output.Add(currentNode.Data);
        currentNode = currentNode.NextNode;
      }
      return String.Join(", ", output);
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
        var newNode = new LinkedListNode(value);
        lastNode.NextNode = newNode;
        lastNode = newNode;
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
      LinkedListNode? previousPointer = null;
      LinkedListNode? nextPointer = null;
      LinkedListNode currentNode = this.HeadNode;

      var continueWork = true;
      while (continueWork)
      {
        // Save away pointer to next node
        nextPointer = currentNode.NextNode;

        // Create new node with the current node's value except it now points to previousPointer
        var newNode = new LinkedListNode(currentNode.Data, previousPointer);
        string strNewNodeData = newNode?.NextNode?.Data is not null ? newNode.NextNode.Data : "null";
        this.debugLog($"Created a new node with value: {newNode.Data} and is pointing to a node with data: {strNewNodeData}");

        previousPointer = newNode;
        // If nextPointer is null we are done
        if (nextPointer is null) { continueWork = false; }
        else
        {
          // Move on to the next node in the original list
          currentNode = nextPointer;
        }
      }

      var newHeadNode = previousPointer;
      this.debugLog($"Reversed Linked Values: {newHeadNode.ToString()}");

      return output;
    }

    private List<string> Optimized(LinkedListNode headNode)
    {
      if (this.HeadNode is null)
      {
        this.debugLog($"HeadNode is null, returning empty array");

        return [];
      }

      var output = new List<string>();
      LinkedListNode? previousPointer = null;
      LinkedListNode? nextPointer = null;
      LinkedListNode currentNode = this.HeadNode;

      var continueWork = true;
      while (continueWork)
      {
        if (previousPointer is null) // Dealing with the HeadNode
        {
          // Save away pointer to next node
          nextPointer = currentNode.NextNode;
          // Head becomes the tail
          currentNode.NextNode = null;
          if (currentNode.NextNode is null)
          {
            this.debugLog($"Only had one node in the list, we're done");
            continueWork = false;
          }
          else
          {
            // On to the next ...
            currentNode = previousPointer.NextNode;
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
            currentNode.NextNode = previousPointer;
            // On to the next
            currentNode = currentNode.NextNode;
          }
        }
      } // /while (continueWork)

      return output;
    }
  }
}
