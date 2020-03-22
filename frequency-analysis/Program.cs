using System;
using System.Text;
using System.IO;
using System.Linq;

namespace frequency_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = @"c:\text\text1.txt";
            string[] readText = File.ReadAllLines(path);
            string text = "";
            string textFromLetters = "";
            for (int i = 0; i < readText.Length; i++)
            {
                text = text + readText[i];
            }
            char[] textFromfiel = text.ToCharArray();

            for (int i = 0; i < readText.Length; i++)
            {
                if (Char.IsLetter(textFromfiel[i]))
                {
                    textFromLetters = textFromLetters + readText[i];
                }
            }
            Console.WriteLine(textFromLetters);
            string[] A = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            foreach (var c in A)
            {
                double prc = (double)(100 * text.ToUpper().Count(s => s.ToString() == c)) / (double)(text.ToUpper().Count(s => A.Any(p => p == s.ToString())));
                Console.WriteLine("{0} {1}", prc, c);
            }

            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
        }
    }
}
