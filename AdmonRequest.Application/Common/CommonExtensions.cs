using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AdmonRequest.Application.Common
{
    public static class CommonExtensions
    {
        /// <summary>
        /// Convert string to base64 string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            byte[] data = ASCIIEncoding.ASCII.GetBytes(value);

            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// Convert base64 to plain text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromBase64(this string value)
        {

            if (string.IsNullOrEmpty(value)) return string.Empty;

            byte[] data = Convert.FromBase64String(value);

            return ASCIIEncoding.ASCII.GetString(data);

        }


        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }

        /// <summary>
        /// Get substring of specified number of characters on the left.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(0, length);
        }


        /// <summary>
        ///     Converts string to its boolean equivalent
        /// </summary>
        /// <param name="value">string to convert</param>
        /// <returns>boolean equivalent</returns>
        /// <remarks>
        ///     <exception cref="ArgumentException">
        ///         thrown in the event no boolean equivalent found or an empty or whitespace
        ///         string is passed
        ///     </exception>
        /// </remarks>
        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value");
            }
            string val = value.ToLower().Trim();
            switch (val)
            {
                case "false":
                    return false;
                case "f":
                    return false;
                case "true":
                    return true;
                case "t":
                    return true;
                case "yes":
                    return true;
                case "no":
                    return false;
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Invalid boolean");
            }
        }

        /// <summary>
        ///     Gets first character in string
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>System.string</returns>
        public static string FirstCharacter(this string val)
        {
            if (string.IsNullOrEmpty(val)) return string.Empty;

            return (val.Length >= 1)
                    ? val.Substring(0, 1)
                    : val;
        }

        /// <summary>
        ///     Gets last character in string
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>System.string</returns>
        public static string LastCharacter(this string val)
        {
            if (string.IsNullOrEmpty(val)) return string.Empty;

            return (val.Length >= 1)
                   ? val.Substring(val.Length - 1, 1)
                   : val;

        }

        /// <summary>
        ///     Validate email address
        /// </summary>
        /// <param name="email">string email address</param>
        /// <returns>true or false if email if valid</returns>
        public static bool IsValidEmailAddress(this string email)
        {
            string pattern =
                "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.Match(email, pattern).Success;
        }

        /// <summary>
        ///     Convert a string to its equivalent byte array
        /// </summary>
        /// <param name="val">string to convert</param>
        /// <returns>System.byte array</returns>
        public static byte[] ToBytes(this string val)
        {
            var bytes = new byte[val.Length * sizeof(char)];
            Buffer.BlockCopy(val.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public static string BytesToBase64String(this byte[] val)
        {
            return Convert.ToBase64String(val);
        }


        /// <summary>
        ///     Convert string to Hash using Sha512
        /// </summary>
        /// <param name="val">string to hash</param>
        /// <returns>Hashed string</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToSha512(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException("val");
            }
            var sb = new StringBuilder();
            using (SHA512 hash = SHA512.Create())
            {
                byte[] data = hash.ComputeHash(val.ToBytes());
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Convert string to Hash using Sha256
        /// </summary>
        /// <param name="val">string to hash</param>
        /// <returns>Hashed string</returns>
        public static string ToSha256(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException("val");
            }
            var sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                byte[] data = hash.ComputeHash(val.ToBytes());
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        private static long lastTimeStamp = DateTime.UtcNow.Ticks;
        public static string UniqueDigits
        {
            get
            {
                long original, newValue;
                do
                {
                    original = lastTimeStamp;
                    long now = DateTime.UtcNow.Ticks;
                    newValue = Math.Max(now, original + 1);
                } while (Interlocked.CompareExchange
                             (ref lastTimeStamp, newValue, original) != original);

                return newValue.ToString();
            }
        }

        /// <summary>
        ///     Remove Characters from string
        /// </summary>
        /// <param name="s">string to remove characters</param>
        /// <param name="chars">array of chars</param>
        /// <returns>System.string</returns>
        public static string RemoveChars(this string s, params char[] chars)
        {
            var sb = new StringBuilder(s.Length);
            foreach (char c in s.Where(c => !chars.Contains(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a valid date from string
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator"></param>
        /// <returns></returns>

        public static DateTime ToDateFromString(this string date, string separator)
        {

            var splitDate = date.Split(separator);

            int day = int.Parse(splitDate[0]);
            int month = int.Parse(splitDate[1]);
            int year = int.Parse(splitDate[2]);

            return new DateTime(year, month, day);

        }

       
        public static string ToSemicolonSeparated(this List<string> value)
        {
            if (!value.Any()) return string.Empty;

            if(value.Count==1) return value[0];

            return string.Join(";", value);
        }


        public static bool IsAllowedFileType(this string fileExtension, string[] extensionsToCompare)
        {
            return extensionsToCompare.Contains(fileExtension);
        }


        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DaysInMonth());
        }

        //public static async Task<byte[]> GetBytes(this IFormFile formFile)
        //{
        //    await using var memoryStream = new MemoryStream();
        //    await formFile.CopyToAsync(memoryStream);
        //    return memoryStream.ToArray();
        //}
    }
}
