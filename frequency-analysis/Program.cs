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
            string pathForNormalText = @"c:\text\text33.txt";
            string pathForEncodedText = @"c:\text\encodingText3.txt";


            string NormalTextFromMetod = ReadТNormalTextFromFile(pathForNormalText);
                  


            string[] ukA = { "А", "Б", "В", "Г", "Ґ", "Д", "Є", "Ж", "З", "И", "І", "Ї", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ь", "Ю", "Я" };
            string[] rusA = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };



            byte[] bytesUTF8 = Encoding.UTF8.GetBytes(NormalTextFromMetod);
            byte[] bytesWin1251 = Encoding.GetEncoding(1251).GetBytes(NormalTextFromMetod);
            byte[] bytesCp866 = Encoding.GetEncoding(866).GetBytes(NormalTextFromMetod);
            byte[] byteKoiu8 = Encoding.GetEncoding("KOI8-R").GetBytes(NormalTextFromMetod);





            string newStrWin1251 = Encoding.GetEncoding(1251).GetString(bytesWin1251);
            string newStrCp866 = Encoding.GetEncoding(866).GetString(bytesWin1251);
            string newStrUTF8 = Encoding.UTF8.GetString(bytesWin1251);
            string newStrKoui8 = Encoding.GetEncoding("KOI8-U").GetString(byteKoiu8);




            double[] appearanceOfTheSymbolInTheories = new double[ukA.Length];

            //  CountOfCharactersInNormalTextExample(ukA, NormalTextFromMetod, appearanceOfTheSymbolInTheories);
            CountOfCharactersInNormalText(ukA, NormalTextFromMetod, appearanceOfTheSymbolInTheories);

          

            for (int i = 0; i < appearanceOfTheSymbolInTheories.Length; i++)
            {
                Console.WriteLine(appearanceOfTheSymbolInTheories[i]);
            }
        }


        public static string ReadТNormalTextFromFile(string pathForNormalText)
        {
            string[] readText = File.ReadAllLines(pathForNormalText,Encoding.GetEncoding(866));
            string text = "";
            for (int i = 0; i < readText.Length; i++)
            {
                text = text + readText[i];
            }
            return text;
        }

     

        public static void CountOfCharactersInNormalTextExample(string[] ukA, string NormalTextFromMetod, double[] appearanceOfTheSymbolInTheories1)
        {
            int i = 0;
            foreach (var c in ukA)
            {
                double prc = (double)( NormalTextFromMetod.ToUpper().Count(s => s.ToString() == c)) / (double)(NormalTextFromMetod.ToUpper().Count(s => ukA.Any(p => p == s.ToString())));
                appearanceOfTheSymbolInTheories1[i] = prc;
                i++;
                Console.WriteLine("{0}  {1}", prc, c);
            }
        }

        public static void CountOfCharactersInNormalText(string[] ukA, string NormalTextFromMetod, double[] appearanceOfTheSymbolInTheories1)
        {
            int p = 0;
            string NormalTextFromMetodUp = NormalTextFromMetod.ToUpper();
            char[] textInChar = NormalTextFromMetodUp.ToCharArray();
            int count2 = 0;
            for (int i = 0; i < textInChar.Length; i++)
            {
                if (char.IsLetter(textInChar[i]))
                {
                    count2++;
                }
            }
            foreach (var c in ukA)
            {
                int count1 = 0;
                foreach (char s in textInChar)
                {
                    if (s.Equals(Convert.ToChar(c)))
                    {
                        count1++;
                    }
                }
                double Freq = ((double)count1  / (double)count2);
                appearanceOfTheSymbolInTheories1[p] = Freq;
                p++;       
               // Console.WriteLine("{0}  {1}", Freq, c);
            }
        }




       
        }
    }

