namespace Services
{
    public class DataChecker
    {
        public static bool IsPasswordCorrect(string password)
        {
            bool HaveUpcaseLetter = false;
            bool HaveNumber = false;

            if (password.Length >= 8)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] >= 'A' && password[i] <= 'Z')
                    {
                        HaveUpcaseLetter = true;
                    }
                    else if (password[i] >= '0' && password[i] <= '9')
                    {
                        HaveNumber = true;
                    }
                }

                if (HaveNumber && HaveUpcaseLetter) return true;
            }

            return false;
        }

        public static bool IsLoginCorrect(string login)
        {
            for (int i = 0; i < login.Length; i++)
            {
                if (!((login[i] >= 'A' && login[i] <= 'Z') || (login[i] >= 'a' && login[i] <= 'z')))
                    return false;
            }

            return true;
        }

        public static bool IsEmailCorrect(string email)
        {
            if (email.Split('@').Length == 2)
            {
                string[] splitedStrings = email.Split('@')[1].Split('.');

                if (splitedStrings.Length == 2)
                {
                    for (int i = 0; i < splitedStrings[0].Length; i++)
                    {
                        if (!(splitedStrings[0][i] >= 'a' && splitedStrings[0][i] <= 'z'))
                            return false;
                    }

                    for (int i = 0; i < splitedStrings[1].Length; i++)
                    {
                        if (!(splitedStrings[1][i] >= 'a' && splitedStrings[1][i] <= 'z'))
                            return false;
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        public static bool IsPhoneNumberCorrect(string phoneNumber, char region)
        {
            if (phoneNumber[0] == '+' && phoneNumber[1] == region)
            {
                phoneNumber = phoneNumber.Trim('+');

                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (!(phoneNumber[i] >= '0' && phoneNumber[i] <= '9'))
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}
