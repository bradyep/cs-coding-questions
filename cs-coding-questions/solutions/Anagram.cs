using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
      this.debugLog($"SolutionType: {st} | possible anagrams: {this.possibleAnagrams.Count}");

      switch (st)
      {
        default:
          return this.Initial(this.possibleAnagrams);
      }
    }

    private Dictionary<char, int> GetCharacterBreakdown(string word)
    {
      var breakdown = new Dictionary<char, int>();
      for (int i = 0; i < word.Length; i++)
      {
        char character = word[i];
        int currentCount = breakdown.GetValueOrDefault(character, 0);
        breakdown[character] = currentCount + 1;
      }

      return breakdown;
    }

    private bool BreakdownsAreEqual(Dictionary<char, int> breakdown1, Dictionary<char, int> breakdown2)
    {
      if (breakdown1.Count != breakdown2.Count)
      {
        return false;
      }

      foreach (var kvp in breakdown1)
      {
        if (!breakdown2.ContainsKey(kvp.Key))
        {
          return false;
        }
        else
        {
          var testVal = breakdown2[kvp.Key];
          if (testVal != kvp.Value)
          {
            return false;
          }
        }
      }

      return true;
    }

    private List<string> Initial(List<PossibleAnagram> possibleAnagrams)
    {
      var output = new List<string>();
      foreach (var possibleAnagram in possibleAnagrams)
      {
        var firstBreakdown = this.GetCharacterBreakdown(possibleAnagram.firstWord);
        var secondBreakdown = this.GetCharacterBreakdown(possibleAnagram.secondWord);
        var isAnagram = this.BreakdownsAreEqual(firstBreakdown, secondBreakdown);
        output.Add($"{possibleAnagram.firstWord} {possibleAnagram.secondWord} {isAnagram}");
      }

      return output;
    }
  }
}
