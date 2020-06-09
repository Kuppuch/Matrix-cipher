using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCode2._0 {



    class Program {
        static char[] alpha = new char[] {'а',  'б',  'в',  'г',  'д',  'е', 'ё', 'ж',  'з',  'и', 'й', 'к',  'л',  'м', 'н',  'о',  'п',  'р',  'с',  'т', 'у',  'ф',  'х',  'ц',  'ч',  'ш', 'щ', 'ъ', 'ы',
            'ь',  'э',  'ю',  'я' }; // 31 буква
        static string text = "Помехоустойчивое кодирование это кодирование с возможностью восстановления потерянных или ошибочно принятых данных";
        


        static void Main(string[] args) {

            double[,] matrix = new double[,] { { 5, 12, -4, 8 }, { 3, 0, 7, 21 }, { 5, 2, 1, 1 }, { 5, 3, 2, 9 } };
            double[,] umatrix = new double[,] { { -0.16, -0.29, -0.321, 0.855 }, { 0.294, 0.448, 0.838, -1.401 }, { 0.286, 0.697, 1.323, -2.027 }, { -0.0725, -0.143, -0.395, 0.553 } };
            text = text.Replace(" ", "").ToLower();
            int[] vector = new int[4];
            string code = "";

            for (int i = 0; i < text.Length; i++) {
                if (i % vector.Length == 0 && i > 0)
                    code += Multiply(matrix, vector);
                if (i == 0) {
                    vector[i] = Array.IndexOf(alpha, text[i]);
                    continue;
                }
                vector[i % vector.Length] = Array.IndexOf(alpha, text[i]);
            }

            code = code.Trim();

            string uncode = "";
            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(code +"\n");


            int[] dparse = DeCrypt(code);
            for (int i = 0; i < dparse.Length; i++) {
                if (i % vector.Length == 0 && i > 0)
                    uncode += Multiply(umatrix, vector);
                vector[i % vector.Length] = dparse[i];
            }

            dparse = DeCrypt(uncode.Trim());
            uncode = "";

            for (int i = 0; i < dparse.Length; i++) {
                uncode += alpha[dparse[i]];
            }

            Console.WriteLine("Расшифрованный текст:");
            Console.WriteLine(uncode);

            Console.ReadKey();
        }

        public static string Multiply(double[,] matrix, int[] vector) {

            double result;
            string answ = "";
            for (int i = 0; i < vector.Length; i++) {
                result = 0;
                for (int j = 0; j < vector.Length; j++) {
                    result += matrix[i, j] * vector[j];
                }
                answ += Math.Round(result) + " ";
            }
            // Для просмотра векторов расскоментировать следующую строку
            // Console.WriteLine("Тут д.б. шифрованная строка      " + answ);
            return answ;
        }

        public static int[] DeCrypt(string code) {

            string[] parse = code.Split(' ');
            int[] dparse = new int[parse.Length];

            for (int i = 0; i < parse.Length; i++) {
                dparse[i] = Convert.ToInt32(parse[i]);
            }

            return dparse;
        }
    }

}
