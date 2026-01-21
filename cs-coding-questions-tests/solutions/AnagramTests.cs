using cs_coding_questions.solutions;

namespace cs_coding_questions_tests.solutions
{
  public class AnagramTests
  {
    [Fact]
    public void CorrectlyMarksAnagrams()
    {
      var args = new Dictionary<string, string>
      {
        { "words", "evil-vile_apple-paled_flow-wolf_grammer-mergers_slate-least" }
      };
      var ag = new Anagram(args);
      var initialResult = ag.solve(SolutionType.initial);
      Assert.Equal(["evil vile True", "apple paled False", "flow wolf True", "grammer mergers False", "slate least True"], initialResult);
    }
  }
}
