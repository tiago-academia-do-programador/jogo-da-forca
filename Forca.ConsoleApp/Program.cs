namespace Forca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palavraEncontrada;
            string palavraSecreta = EscolherPalavraAleatoria();

            char[] letrasEncontradas = InicializarLetrasEncontradas(palavraSecreta.Length);

            int erros = 0;

            ApresentarTitulo();

            do
            {
                DesenharForca(erros);

                ApresentarLetrasEncontradas(letrasEncontradas);

                bool letraFoiEncontrada = VerificarAcerto(palavraSecreta, letrasEncontradas);

                if (letraFoiEncontrada == false)
                    erros++;

                palavraEncontrada = new string(letrasEncontradas);

                if (JogadorAcertou(palavraEncontrada, palavraSecreta))
                    Console.WriteLine($"Você acertou a palavra {palavraSecreta}, parabéns!");

                else if (JogadorPerdeu(erros))
                    Console.WriteLine("Que azar! Tente novamente!");

            } while (!JogadorAcertou(palavraEncontrada, palavraSecreta) && !JogadorPerdeu(erros));

            Console.ReadLine();
        }

        static bool JogadorPerdeu(int erros)
        {
            return erros == 5;
        }

        private static bool VerificarAcerto(string palavraSecreta, char[] letrasEncontradas)
        {
            bool letraFoiEncontrada = false;

            char chute = ObterPalpite();

            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                bool chuteAcertouLetra = chute == palavraSecreta[i];

                if (chuteAcertouLetra)
                {
                    letrasEncontradas[i] = chute;
                    letraFoiEncontrada = true;
                }
            }

            return letraFoiEncontrada;
        }

        static bool JogadorAcertou(string palavraEncontrada, string palavraSecreta)
        {
            return palavraEncontrada == palavraSecreta;
        }

        private static char ObterPalpite()
        {
            Console.Write("Qual o seu chute? ");
            char chute = Convert.ToChar(Console.ReadLine());
            return chute;
        }

        static char[] InicializarLetrasEncontradas(int tamanhoDoArray)
        {
            char[] letrasEncontradas = new char[tamanhoDoArray];

            for (int caractere = 0; caractere < letrasEncontradas.Length; caractere++)
                letrasEncontradas[caractere] = '_';

            return letrasEncontradas;
        }

        private static void ApresentarLetrasEncontradas(char[] letrasEncontradas)
        {
            Console.WriteLine();
            Console.WriteLine(letrasEncontradas);
            Console.WriteLine();
        }

        private static void ApresentarTitulo()
        {
            Console.WriteLine("/****************/");
            Console.WriteLine("/ Jogo de Forca */");
            Console.WriteLine("/****************/");
        }

        private static string EscolherPalavraAleatoria()
        {
            string[] palavras = {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "ACAI",
                "ARACA",
                "ABACATE",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJA",
                "CAJU",
                "CARAMBOLA",
                "CUPUACU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MACA",
                "MANGABA",
                "MANGA",
                "MARACUJA",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };

            Random random = new Random();

            int indiceEscolhido = random.Next(palavras.Length);

            return palavras[indiceEscolhido];
        }

        private static void DesenharForca(int quantidadeErros)
        {
            // operação ternária
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }
    }
}