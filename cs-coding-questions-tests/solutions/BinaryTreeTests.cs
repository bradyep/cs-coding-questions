using cs_coding_questions.solutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions_tests.solutions
{
  public class BinaryTreeTests
  {
    [Fact]
    public void Flips()
    {
      var args = new Dictionary<string, string>
      {
        { "nodes", "50(17(12,23),72(54,76))" }
      };
      var bt = new BinaryTree(args);
      var initialResult = bt.solve(SolutionType.initial);
      Assert.Equal(["50(72(76,54),17(23,12))"], initialResult);
    }

    [Fact]
    public void DetectsValidBST()
    {
      var args = new Dictionary<string, string>
      {
        { "nodes", "50(17(12,23),72(54,76))" }
      };
      var bt = new BinaryTree(args);
      var initialResult = bt.solve(SolutionType.alternateinitial);
      Assert.Equal(["True"], initialResult);
    }

    [Fact]
    public void DetectsInvalidBST()
    {
      var args = new Dictionary<string, string>
      {
        { "nodes", "50(72(76,54),17(23,12))" }
      };
      var bt = new BinaryTree(args);
      var initialResult = bt.solve(SolutionType.alternateinitial);
      Assert.Equal(["False"], initialResult);
    }
  }
}
