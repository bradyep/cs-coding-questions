using cs_coding_questions.solutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions
{
  internal record ProcessArgsResult(bool Success, string Message);
  internal class Loader
  {
    public Loader(string[] args) {
      this.processArgsResult = this.ProcessArgs(args);
      Console.WriteLine($"Arg processing result: {this.processArgsResult.Success} | {this.processArgsResult.Message}");
    }

    private string? solutionName;
    private SolutionType solutionType;
    private ProcessArgsResult processArgsResult;

    private ProcessArgsResult ProcessArgs(string[] args)
    {
      if (args.Length < 2)
      {
        return new ProcessArgsResult(false, $"Need solution name and type to run. Exiting out.");
      }
      else
      {
        Console.WriteLine($"args[0]: {args[0]}, args[1]: {args[1]}");
        this.solutionName = args[0];
        int solutionTypeArg;
        if (int.TryParse(args[1], out solutionTypeArg) == false)
        {
          return new ProcessArgsResult(false, $"Did not receive a number for SolutionType: {args[1]}");
        }

        if (Enum.IsDefined(typeof(SolutionType), solutionTypeArg))
        {
          this.solutionType = (SolutionType)solutionTypeArg;
        }
        else
        {
          return new ProcessArgsResult(false, $"Received invalid SolutionType: {solutionTypeArg}");
        }

        Console.WriteLine($"Solution: {this.solutionName} | SolutionType: {this.solutionType}");
        return new ProcessArgsResult(true, "Successfully read in params");
      }
    }

    public void Run()
    {
      if (this.processArgsResult.Success == false)
      {
        Console.WriteLine($"Could not process args. Shutting down.");

        return;
      }
      return;
    }

  }
}
