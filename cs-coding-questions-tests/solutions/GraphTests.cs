using cs_coding_questions.solutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions_tests.solutions
{
  public class GraphTests
  {
    [Fact]
    public void CanTraverseUsingDFS()
    {
      var args = new Dictionary<string, string>
      {
        { "graph", "1,2,3|0,4,5|0|0|1|1" }
      };
      var graph = new Graph(args);
      var initialResult = graph.solve(SolutionType.initial);
      Assert.Equal(["0", "1", "4", "5", "2", "3"], initialResult);
    }

    [Fact]
    public void CanTraverseUsingBFS()
    {
      var args = new Dictionary<string, string>
      {
        { "graph", "1,2,3|0,4,5|0|0|1|1" }
      };
      var graph = new Graph(args);
      var initialResult = graph.solve(SolutionType.alternateinitial);
      Assert.Equal(["0", "1", "2", "3", "4", "5"], initialResult);
    }
  }
}
