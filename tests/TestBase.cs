using NUnit.Framework;
using System.Text;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;

        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        /*public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            // Гарантируем минимум 1 символ
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                // Только буквы и цифры (A-Z, a-z, 0-9)
                int randomValue = Convert.ToInt32(rnd.NextDouble() * 62);

                if (randomValue < 26) // A-Z
                {
                    builder.Append(Convert.ToChar(65 + randomValue));
                }
                else if (randomValue < 52) // a-z
                {
                    builder.Append(Convert.ToChar(97 + (randomValue - 26)));
                }
                else // 0-9
                {
                    builder.Append(Convert.ToChar(48 + (randomValue - 52)));
                }
            }
            return builder.ToString();
        }*/
    }
}

