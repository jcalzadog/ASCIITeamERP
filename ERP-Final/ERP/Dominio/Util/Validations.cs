using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERP.Dominio.Util
{
    class Validations
    {
        public static bool validateEmpty(String objeto)
        {
            if (objeto.Equals(""))
            {
                return false;
            } else
            {
                return true;
            }
        }
        public static bool validateEmail(String email)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_!#$%&’*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$");
            return regex.IsMatch(email);
        }

        public static bool validateDNI(String dni)
        {
            Regex regex = new Regex("[0-9]{8,8}[A-Za-z]");
            return regex.IsMatch(dni);
        }

        public static bool validatePrice(String number)
        {
            Regex regex = new Regex("^[0-9]+([.][0-9]+)?$");
            return regex.IsMatch(number);
        }
    }
}
