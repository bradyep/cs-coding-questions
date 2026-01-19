using cs_coding_questions.solutions;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine($"Number of args: {args.Length}");

    if (args.Length < 2)
    {
      Console.WriteLine($"Need solution name and type to run. Exiting out.");
      Environment.Exit(0);
    } else {
      Console.WriteLine($"args[0]: {args[0]}, args[1]: {args[1]}");
      var solutionName = args[0];
      int solutionTypeArg;
      SolutionType solutionType = 0;
      if (int.TryParse(args[1], out solutionTypeArg) == false)
      {
        Console.WriteLine($"Did not receive a number for SolutionType: {args[1]}");
        Environment.Exit(0);
      }

      if (Enum.IsDefined(typeof(SolutionType), solutionTypeArg))
      {
        solutionType = (SolutionType)solutionTypeArg;
      }
      else
      {
        Console.WriteLine($"Received invalid SolutionType: {solutionTypeArg}");
        Environment.Exit(0);
      }

      Console.WriteLine($"Solution: {solutionName} | SolutionType: {solutionType}");
    }
  }
}
