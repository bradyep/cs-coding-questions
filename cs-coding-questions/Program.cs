using cs_coding_questions;
using cs_coding_questions.solutions;

class Program
{
  static void Main(string[] args)
  {
    bool debug = false;

    if (args.Select(a => a.ToLowerInvariant()).Contains("--debug"))
    {
      debug = true;
    }
    if (debug == true)
    {
      Console.WriteLine($"Number of args: {args.Length}");
    }
    var loader = new Loader(args, debug);
    loader.Run();
  }
}
