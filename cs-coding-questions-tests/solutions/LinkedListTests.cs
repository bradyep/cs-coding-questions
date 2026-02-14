using cs_coding_questions.solutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions_tests.solutions
{
  public class LinkedListTests
  {
    [Fact]
    public void Reverses()
    {
      var args = new Dictionary<string, string>
      {
        { "values", "first_second_third_fourth_fifth" }
      };
      var ag = new LinkedList(args);
      var initialResult = ag.solve(SolutionType.initial);
      Assert.Equal(["fifth, fourth, third, second, first"], initialResult);
    }
  }
}
