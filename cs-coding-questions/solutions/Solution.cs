using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.solutions
{
  public abstract class Solution(Dictionary<string, string> solutionParams, bool? debug = false)
  {
    protected Dictionary<string, string> SolutionParams { get; } = solutionParams;
    protected bool paramsAreValid = false;
    public abstract bool verifyParams();
    public abstract List<string> solve(SolutionType st);
    public void debugLog(string text)
    {
      if (debug == true)
      {
        Console.WriteLine(text);
      }
    }
  }
}
