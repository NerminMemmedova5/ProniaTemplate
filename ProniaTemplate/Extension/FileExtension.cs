//using System.Text;

//namespace ProniaTemplate.Extension
//{
//    public class FileExtension
//    {
//        public string Capitalize(string word)
//        {

//            StringBuilder capital = new StringBuilder();
//            capital.Append(Char.ToUpper(word[0]));


//            for (int i = 1; i < word.Length; i++)
//            {
//                capital.Append(Char.ToLower(word[i]));
//            }
//            return capital.ToString();
//        }
        
//        public static bool CheckIsDigit(this string value)
//        {
//            int digit = 0;
//            foreach (var item in value)
//            {
//                if (char.IsDigit(item))
//                {
//                    digit++;
//                }
//            }
//            if (digit > 0)
//            {
//                return false;
//            }
//            return true;
//        }

       
//    }
//}
