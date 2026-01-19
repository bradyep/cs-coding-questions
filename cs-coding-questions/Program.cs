using cs_coding_questions;
using cs_coding_questions.solutions;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine($"Number of args: {args.Length}");
    var loader = new Loader(args);
    loader.Run();
  }
}
