using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace cs_coding_questions.solutions
{
  internal record PossibleAnagram(string firstWord, string secondWord);
  public class Anagram : Solution
  {
    private const char WORD_PAIR_SEPARATOR = '-';
    private const char ANAGRAM_SET_SEPARATOR = '_';
    private List<PossibleAnagram> possibleAnagrams = [];

    public Anagram(Dictionary<string, string> solutionParams, bool? debug = false) : base(solutionParams, debug)
    {
      this.debugLog("Calling verifyParams()");
      this.paramsAreValid = this.verifyParams();
    }

    public override bool verifyParams()
    {
      var wordsParam = this.SolutionParams.GetValueOrDefault("words", "");
      if (wordsParam == "") { return false; }
      var possibleAnagramsUnsplit = wordsParam.Split(ANAGRAM_SET_SEPARATOR);
      foreach (var wordPair in possibleAnagramsUnsplit)
      {
        var words = wordPair.Split(WORD_PAIR_SEPARATOR);
        if (words.Length != 2)
        {
          this.debugLog($"Possible anagrams consist of two words. Received: {words.Length}");

          return false;
        }
        this.possibleAnagrams.Add(new PossibleAnagram(words[0], words[1]));
      }

      this.debugLog($"Received this many pairs to check: {this.possibleAnagrams.Count}");

      return true;
    }

    public override List<string> solve(SolutionType st)
    {
      return [];
    }
  }
}
