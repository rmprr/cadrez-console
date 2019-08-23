using System;
using tabuleiro;


namespace xadrez_console
{
    class Tela
    {

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            int quadricula = 1;

            for (int i = 0; i < tab.linhas; i++)
            {
                quadricula *= -1;

                Console.Write( 8 - i + "* ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (quadricula == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    if (tab.peca(i, j) == null)
                    {
                        Console.Write(" " + " ");
                    }
                    else
                    {
                        ConsoleColor auxColorBack = Console.BackgroundColor;
                        imprimirPeca(tab.peca(i, j));
                        Console.BackgroundColor = auxColorBack;
                        Console.Write(" ");
                    }

                    Console.ResetColor();
                    quadricula *= -1;
                }
                Console.WriteLine("");
            }

            Console.Write("   ");
            for (int k = 1; k <= tab.linhas; k++)
            {
                Console.Write((char)(k + 64) + " ");
            }
        }


        public static void imprimirPeca(Peca peca)
        {
            ConsoleColor aux = Console.ForegroundColor;

            switch (peca.cor)
            {
                case Cor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    break;
                case Cor.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(peca);
                    break;
                case Cor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    break;
                case Cor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(peca);
                    break;
                case Cor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                    break;
                default:
                    break;
            }

            Console.ForegroundColor = aux;
            Console.ResetColor();
        }
    }
}
