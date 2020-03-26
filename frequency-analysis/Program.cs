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
            string pathForNormalText = @"c:\text\textForStatistics.txt";
            string pathForEncodedText = @"c:\text\textForEncoding.txt";


            string NormalTextFromMetod = ReadТNormalTextFromFile(pathForNormalText);
            string EncodingText = CodingText(NormalTextFromMetod);
         //   Console.WriteLine(EncodingText);


            string[] ukA = { "А", "Б", "В", "Г", "Ґ", "Д", "Є", "Ж", "З", "И", "І", "Ї", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ь", "Ю", "Я" };
            string[] rusA = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            double[] appearanceOfTheSymbolInTheories1 = new double[rusA.Length];
            double[] appearanceOfTheSymbolInTheories2 = new double[rusA.Length];
            double[] appearanceOfTheSymbolInTheories3 = new double[rusA.Length];


          CountOfCharactersInNormalText(rusA, NormalTextFromMetod,  appearanceOfTheSymbolInTheories1);


        }

        public static string ReadТNormalTextFromFile(string pathForNormalText)
        {
            string[] readText = File.ReadAllLines(pathForNormalText);
            string text = "";
            for (int i = 0; i < readText.Length; i++)
            {
                text = text + readText[i];
            }
            return text;
        }


        public static void CountOfCharactersInNormalTextExample(string[] rusA, string NormalTextFromMetod, double[] appearanceOfTheSymbolInTheories1)
        {
            int i = 0;
            foreach (var c in rusA)
            {
                double prc = (double)(100 * NormalTextFromMetod.ToUpper().Count(s => s.ToString() == c)) / (double)(NormalTextFromMetod.ToUpper().Count(s => rusA.Any(p => p == s.ToString())));
                appearanceOfTheSymbolInTheories1[i] = prc;
                i++;
                Console.WriteLine("{0}  {1}", prc, c);
            }
        }


        public static void CountOfCharactersInNormalText(string[] rusA, string NormalTextFromMetod, double[] appearanceOfTheSymbolInTheories1)
        {
            string NormalTextFromMetodUp = NormalTextFromMetod.ToUpper();
            char[] textInChar = NormalTextFromMetodUp.ToCharArray();
            double count2 = 0;
            for (int i = 0; i < textInChar.Length; i++)
            {
                if (char.IsLetter(textInChar[i]))
                {
                    count2++;
                }
            }
            foreach (var c in rusA)
            {
                int count1 = 0;
                foreach (char s in textInChar)
                {
                    if (s.Equals(Convert.ToChar(c)))
                    {
                        count1++;
                    }
                }
                double Freq = (double)count1 * 100 / count2;
                Console.WriteLine("{0}  {1}", Freq, c);
            }
        }





        public static string CodingText(string NormalTextFromMetod)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] bytes = Encoding.UTF8.GetBytes(NormalTextFromMetod);
            byte[] newBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(866), bytes); 
            string newStr = Encoding.GetEncoding(1251).GetString(newBytes);
            return newStr;
        }






      



    }
}
