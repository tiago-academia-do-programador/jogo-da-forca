namespace Forca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forca jogo = new Forca();

            while (true)
            {
                ApresentarTitulo();

                DesenharForca(jogo.Erros);

                ApresentarMensagem("As letras encontradas até agora são: " + jogo.PalavraParcial);

                char palpite = ObterPalpite();

                if (jogo.JogadorAcertou(palpite) || jogo.JogadorPerdeu())
                {
                    ApresentarMensagem(jogo.mensagemFinal);
                    break;
                }
            }

            Console.ReadLine();
        }

        static void ApresentarTitulo()
        {
            Console.Clear();

            Console.WriteLine("/****************/");
            Console.WriteLine("/ Jogo de Forca */");
            Console.WriteLine("/****************/");
        }

        static void DesenharForca(int quantidadeErros)
        {
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";

            Console.WriteLine();
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

        static void ApresentarMensagem(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem);
        }

        static char ObterPalpite()
        {
            Console.WriteLine();
            Console.Write("Qual o seu palpite? ");
            char palpite = Convert.ToChar(Console.ReadLine());

            return palpite;
        }
    }
}