using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.solutions
{
  internal record PossibleAnagram(string firstWord, string secondWord);
  public class Anagram : Solution
  {
    const char WORD_PAIR_SEPARATOR = '-';
    const char ANAGRAM_SET_SEPARATOR = '_';

    public Anagram(Dictionary<string, string> solutionParams, bool? debug = false) : base(solutionParams, debug)
    {
      this.paramsAreValid = this.verifyParams();
    }

    public override bool verifyParams()
    {
      return true;
    }

    public override string[] solve(SolutionType st)
    {
      return [];
    }
  }
}
