using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.BLL.Services
{
   public class OtpService
    {
        public OtpService()
        {

        }

        public static string GenerateOTP()
        {
            char[] charArr = "0123456789".ToCharArray();

            var rnd = new Random();
            var strngRand = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                int pos = rnd.Next(1, charArr.Length);
                if (!strngRand.Contains(charArr.GetValue(pos).ToString()))
                    strngRand += charArr.GetValue(pos);
                else i--;
            }

            return strngRand;
        }

        public static bool SendOTP(string phone)
        {

            try
            {
                var otp = GenerateOTP();

                var msg = $"{otp} is your otp and will expire in ten minutes";

                if (!string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(msg))
                {
                    //call sms sending API service

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool ValidateOPT(string code)
        {

            try
            {

                if (!string.IsNullOrEmpty(code))
                {
                    //call sms sending API service for otp validation

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
