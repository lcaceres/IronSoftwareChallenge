using System.Text;

namespace IronSoftwareChallenge.Utils
{
    public class TextDecoder
    {
        public static string Decode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            input = input.TrimEnd('#');

            var result = new StringBuilder();
            var currentSequence = new StringBuilder();
            char? previousKey = null;

            foreach (char key in input)
            {
                if (key == '*')
                {
                    if (currentSequence.Length > 0)
                    {
                        currentSequence.Clear();
                    }
                    else if (result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1);
                    }
                    continue;
                }

                if (key == ' ')
                {
                    LetterFromSequence(currentSequence.ToString(), result);
                    currentSequence.Clear();
                    previousKey = null;
                    continue;
                }

                if (previousKey == null || key == previousKey)
                {
                    currentSequence.Append(key);
                }
                else
                {
                    LetterFromSequence(currentSequence.ToString(), result);
                    currentSequence.Clear();
                    currentSequence.Append(key);
                }

                previousKey = key;
            }

            LetterFromSequence(currentSequence.ToString(), result);

            return result.ToString();
        }

        private static void LetterFromSequence(string sequence, StringBuilder result)
        {
            if (sequence.All(c => c == '0'))
            {
                result.Append(" ");
                return;
            }

            switch (sequence)
            {
                case "1": result.Append("&"); break;
                case "11": result.Append("'"); break;
                case "111": result.Append("("); break;
                case "2": result.Append("A"); break;
                case "22": result.Append("B"); break;
                case "222": result.Append("C"); break;
                case "3": result.Append("D"); break;
                case "33": result.Append("E"); break;
                case "333": result.Append("F"); break;
                case "4": result.Append("G"); break;
                case "44": result.Append("H"); break;
                case "444": result.Append("I"); break;
                case "5": result.Append("J"); break;
                case "55": result.Append("K"); break;
                case "555": result.Append("L"); break;
                case "6": result.Append("M"); break;
                case "66": result.Append("N"); break;
                case "666": result.Append("O"); break;
                case "7": result.Append("P"); break;
                case "77": result.Append("Q"); break;
                case "777": result.Append("R"); break;
                case "7777": result.Append("S"); break;
                case "8": result.Append("T"); break;
                case "88": result.Append("U"); break;
                case "888": result.Append("V"); break;
                case "9": result.Append("W"); break;
                case "99": result.Append("X"); break;
                case "999": result.Append("Y"); break;
                case "9999": result.Append("Z"); break;
                default:
                    result.Append('?');
                    break;
            }
        }
    }
}
