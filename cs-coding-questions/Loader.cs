using cs_coding_questions.solutions;
using cs_coding_questions.utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace cs_coding_questions
{
  internal record ProcessArgsResult(bool Success, string Message);
  internal class Loader
  {
    public Loader(string[] args, bool debug = false)
    {
      this.debug = debug;
      this.processArgsResult = this.ProcessArgs(args);
      if (this.debug)
      {
        Console.WriteLine($"Arg processing result: {this.processArgsResult.Success} | {this.processArgsResult.Message}");
      }
    }

    private string? solutionName;
    private SolutionType solutionType;
    private List<string> solutionArgs = [];
    private ProcessArgsResult processArgsResult;
    private bool debug = false;

    private ProcessArgsResult ProcessArgs(string[] args)
    {
      if (args.Length < 2)
      {
        return new ProcessArgsResult(false, $"Need solution name and type to run. Exiting out.");
      }
      else
      {
        if (this.debug) { Console.WriteLine($"args[0]: {args[0]}, args[1]: {args[1]}"); }
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

        this.solutionArgs = args.Skip(2).ToList();

        return new ProcessArgsResult(true, $"Successfully read in params -> Solution: {this.solutionName} | SolutionType: {this.solutionType} | SolutionArgs: {string.Join(", ", this.solutionArgs)}");
      }
    }

    public void Run()
    {
      List<string> consoleOutput = [];
      var solutionDict = new Dictionary<string, string>();

      if (this.processArgsResult.Success == false || this.solutionName == null)
      {
        Console.WriteLine($"Could not process args. Shutting down.");

        return;
      }

      var normalizedSolutionName = this.solutionName.Trim().ToLower();
      switch (normalizedSolutionName)
      {
        case "anagram":
          Console.WriteLine($"Running: {normalizedSolutionName}");
          if (CommandLineArgs.GetOption(this.solutionArgs, "words", "w") is { } words) solutionDict.Add(words.Key, words.Value);
          var anagram = new Anagram(solutionDict, this.debug);
          consoleOutput = anagram.solve(this.solutionType);
          break;
        case "linkedlist":
          Console.WriteLine($"Running: {normalizedSolutionName}");
          if (CommandLineArgs.GetOption(this.solutionArgs, "values", "v") is { } values) solutionDict.Add(values.Key, values.Value);
          var linkedlist = new LinkedList(solutionDict, this.debug);
          consoleOutput = linkedlist.solve(this.solutionType);
          break;
        default:
          Console.WriteLine($"Could not find solution name");
          break;
      }

      if (consoleOutput.Count > 0)
      {
        foreach (string line in consoleOutput)
        {
          Console.WriteLine(line);
        }
      }
      else
      {
        Console.WriteLine($"Did not receive anything to write to console");
      }

      return;
    }

  }
}
