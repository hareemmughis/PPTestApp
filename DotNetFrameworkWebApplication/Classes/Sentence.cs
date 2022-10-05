using System.Linq;

namespace DotNetFrameworkWebApplication.Classes
{
    public class Sentence
    {
        private static bool CheckStartsWithCapital(string sentence)
        {
            //checking first character of string is upper or not
            return char.IsUpper(sentence.First());
        }

        private static bool CheckEvenQuotationMarks(string sentence)
        {
            //counting number of " in string and then taking the modulus by 2 in order to check it is even or not
            return sentence.Count(it=>it=='"') % 2 == 0;
        }

        private static bool CheckSentenceTermination(string sentence)
        {
            //checking whether last character of string is . ? or !
            return  sentence.Last().Equals('.') || sentence.Last().Equals('?') || sentence.Last().Equals('!');
        }

        private static bool CheckNoPeriodMidSentence(string sentence)
        {
            //checking apart from last character, there is no other occurence of . in the string
            return !sentence.Remove(sentence.Length - 1).Contains(".");
        }

        private static bool CheckNumberBelow13(string sentence)
        {
            //checking does string contains any digit char or not
            if (!sentence.Any(char.IsDigit))
                return true;
            else
            {
                int result;
                foreach (var word in sentence.Split(' '))
                {
                    //removing any non-alphanumeric character from word
                    string wordWithOutNonAlphaNumericCharacters = new string(word.Where(c => char.IsLetterOrDigit(c)).ToArray());

                    //try to parse word into int, in order to check whether it is a number or not
                    if (int.TryParse(wordWithOutNonAlphaNumericCharacters, out result))
                    {
                        //word is number, checking if it is below 13 or not
                        if (int.Parse(wordWithOutNonAlphaNumericCharacters) < 13)
                            return false;
                    }
                }

                return true;
            }
        }

        public bool IsValidSentence(string sentence)
        {
            //first check whether string is empty or null. Otherwise no point of running any other valid sentence checks
            if (string.IsNullOrEmpty(sentence))
                return false;
            //now the sentence is not empty or null, checking whether sentence pass all validation rules or not
            return CheckStartsWithCapital(sentence) && CheckEvenQuotationMarks(sentence) && CheckSentenceTermination(sentence) 
                   && CheckNoPeriodMidSentence(sentence) && CheckNumberBelow13(sentence);
        }
    }
}