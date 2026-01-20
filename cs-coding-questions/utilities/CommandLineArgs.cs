using System;
using System.Collections.Generic;
using System.Text;

namespace cs_coding_questions.utilities
{
  internal static class CommandLineArgs
  {
    public static KeyValuePair<string, string>? GetOption(List<string> args, string flag, string? alias)
    {
      var lowerCaseArgs = args.Select(arg => arg.ToLowerInvariant()).ToArray();
      int optionIndex = Math.Max(lowerCaseArgs.IndexOf("--" + flag), lowerCaseArgs.IndexOf("-" + alias));

      if (optionIndex < 0)
      {
        return null;
      }
      // If a flag or alias is present without a value, treat it as a toggle and return true
      if (optionIndex >= lowerCaseArgs.Length - 1 || lowerCaseArgs[optionIndex + 1].StartsWith("-"))
      {
        return new KeyValuePair<string, string>(flag, "true");
      } else
      {
        return new KeyValuePair<string, string>(flag, args[optionIndex + 1]);
      }
    }
  }
}
