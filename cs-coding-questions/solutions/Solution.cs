using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.solutions
{
  internal abstract class Solution(Dictionary<string, string> solutionParams, bool? debug = false)
  {
    public bool paramsAreValid = false;
    public abstract bool verifyParams();
    public abstract string[] solve(SolutionType st);
    public void debugLog(string text)
    {
      if (debug == true)
      {
        Console.WriteLine(text);
      }
    }
  }
}
