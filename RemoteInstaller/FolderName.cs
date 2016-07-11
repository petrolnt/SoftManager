using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftManager
{
    /// <summary>
    /// класс, метод GetDirName которого генерит случайное имя для временной папки, которая будет создана на целевом компьютере для размещения устанавливаемого
    /// дистрибутива, после установки программы папка будет удалена(смотри WMIProcess).
    /// Непомню зачем я это вывел в отдельный класс, переделывать неохота:)
    /// </summary>

    class FolderName
    {
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static string GetDirName()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        } 
    }
}
