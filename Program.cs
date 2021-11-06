using System;

namespace Problema22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserte la primera palabra: ");
            string wordOne = InputString();
            
            Console.Write("Inserte la segunda palabra: ");
            string wordTwo = InputString();

            if (Anagram(wordOne, wordTwo))
            {
                Console.WriteLine($"\nLas palabras {wordOne} y {wordTwo} son anagramas.");
            }
            else
            {
                Console.WriteLine($"\nLas palabras {wordOne} y {wordTwo} no son anagramas.");
            }
        }

        static bool Anagram(string wordOne, string wordTwo)
        {
            char[] lettersOne = wordOne.ToCharArray();
            char[] lettersTwo = wordTwo.ToCharArray();

            if (lettersOne.Length != lettersTwo.Length)
            {
                return false;
            }

            Array.Sort(lettersOne);
            Array.Sort(lettersTwo);

            for (int i = 0; i < lettersOne.Length; i++)
            if (lettersOne[i] != lettersTwo[i])
                return false;
            
            return true;
        }

        static string InputString()
        {
            string letra = null;
            
            ConsoleKeyInfo tecla;

            do
            {
                //Obtener la tecla presionada por el usuario.
                tecla = Console.ReadKey(true);
                //Verificar si el letra, numero, espacio, simbolo o puntuacion.
                if (char.IsLetterOrDigit(tecla.KeyChar) || tecla.Key == ConsoleKey.Spacebar || char.IsPunctuation(tecla.KeyChar) || char.IsSymbol(tecla.KeyChar))
                {
                    //Añadiendo la tecla presionada a el string letra.
                    letra += tecla.KeyChar;
                    //Mostrar por pantalla la tecla.
                    Console.Write(tecla.KeyChar);
                }
                else
                {   //Verificar si se presiono el backspace
                    if (tecla.Key == ConsoleKey.Backspace && letra.Length > 0)
                    {
                        //Eliminando el ultimo caracter del string letra.
                        letra = letra.Substring(0, letra.Length - 1);
                        //Mostrar el cambio por consola
                        Console.Write("\b \b");
                    }
                }
                //Si se presiona enter sale del bucle
            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return letra;
        }
    }
}
