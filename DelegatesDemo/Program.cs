using System;
namespace DelegatesDemo
{
    public delegate string onWordDelegate(string word);
    public delegate string onNumberDelegate(string number);
    public delegate string onJunkDelegate(string symbol);
    public class ConsoleReader
    {
        public string run()
        {
            Console.WriteLine("Enter the string");
            return Console.ReadLine();
        }
        public string OnWord(string wrd)
        {
            Console.WriteLine("From OnWord method {0}",wrd);
            return "From OnWord Method";
        }
        public string OnNumber(string num)
        {
           Console.WriteLine("From OnNumber method {0}",num);
            return "From OnNumber method ";
        }
        public string OnJunk(string sym)
        {
            Console.WriteLine("From OnJunk method {0}",sym);
            return "From OnJunk method ";
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            onWordDelegate onWordObj;
            onNumberDelegate onNumObj;
            onJunkDelegate onJunkObj;
            ConsoleReader consoleReader = new ConsoleReader();
            string strEntered=consoleReader.run();
            if (strEntered.ToCharArray().All(char.IsDigit))
            {
                onNumObj = consoleReader.OnNumber;
                onNumObj.Invoke(strEntered);
            }
            else if (strEntered.ToCharArray().All(char.IsLetterOrDigit))
            {
                onWordObj = consoleReader.OnWord;
                onWordObj.Invoke(strEntered);
            }
            else if (!strEntered.ToCharArray().All(char.IsLetterOrDigit))
            {
                onJunkObj = consoleReader.OnJunk;
                onJunkObj.Invoke(strEntered);
            }
            else
            {
                onWordObj = consoleReader.OnWord;
                onWordObj.Invoke(strEntered);
            }
        }
    }
}