using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    public class UtilsHelper
    {
        public static string GetOtp(int OtpSize)
        {
            return RandomNumber(100000, 999999).ToString();
        }
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
