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
    private string[] solutionArgs = [];
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

        this.solutionArgs = args.Skip(2).ToArray();

        return new ProcessArgsResult(true, $"Successfully read in params -> Solution: {this.solutionName} | SolutionType: {this.solutionType} | SolutionArgs: {string.Join(", ", this.solutionArgs)}");
      }
    }

    public void Run()
    {
      string[] consoleOutput = [];

      if (this.processArgsResult.Success == false || this.solutionName == null)
      {
        Console.WriteLine($"Could not process args. Shutting down.");

        return;
      }

      switch (this.solutionName.Trim().ToLower())
      {
        case "anagram":
          // load and run anagram
          break;
        default:
          Console.WriteLine($"Could not find solution name");
          break;
      }

      if (consoleOutput.Length > 0)
      {
        // Write it out
      }

      return;
    }

  }
}
