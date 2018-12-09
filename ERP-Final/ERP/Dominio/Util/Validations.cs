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
        public static bool validateCategorie(String categorie) {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(categorie);
        }
        public static bool validatePlatforms(String platform)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(platform);
        }

        public static bool validateUser(String cadena)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(cadena);
        }
        public static bool validateRol(String rol)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(rol);
        }
        public static bool validateName(String cadena)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(cadena);
        }
        public static bool validatePhoneorZipcode(String phone)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(phone);
        }
    }
}
