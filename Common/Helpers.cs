using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Helper
    {
        public static string SoNumeros(string aString)
        {
            if (aString == null)
                return null;

            return new string(aString.Where(c => char.IsDigit(c)).ToArray());
        }
        
        public static string ColocaMascaraRG(string aString)
        {
            if (aString == null)
                return null;

            if (aString.Length == 9)
            {
                return aString.Insert(2, ".").Insert(6, ".").Insert(10, "-");
            }
            else
            {
                return aString;
            }
        }

        public static string ColocaMascaraCPF(string aString)
        {
            if (aString == null)
                return null;

            if (aString.Length == 11)
            {
                return aString.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
            else
            {
                return aString;
            }
        }

        public static string ColocaMascaraCNPJ(string aString)
        {
            if (aString == null)
                return null;

            if (aString.Length == 14)
            {
                return aString.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
            else
            {
                return aString;
            }
        }

        public static string ColocaMascaraCEP(string aString)
        {
            if (aString == null)
                return null;

            if (aString.Length == 8)
            {
                return aString.Insert(5, "-");
            }
            else
            {
                return aString;
            }
        }

        public static string ColocaMascaraIE(string aString)
        {
            if (aString == null)
                return null;

            return aString;
        }

        public static string ColocaMascaraIM(string aString)
        {
            if (aString == null)
                return null;

            return aString;
        }
    }
}
