using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;


namespace xadrez_console
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.Write("Aguardando a jogada: "); Console.WriteLine(partida.jogadorAtual); // TODO: meter isto com a mudar de cor

            if (partida.xeque)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("#---------- VOCÊ ESTÁ EM XEQUE ----------#");
                Console.ResetColor();
            }
        }


        private static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.White));
            Console.WriteLine();
            Console.ForegroundColor = aux;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Black));
            Console.WriteLine();
            Console.ResetColor();
        }


        private static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca item in conjunto)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
        }


        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine();
            int quadricula = 1;

            for (int i = 0; i < tab.linhas; i++)
            {
                quadricula *= -1;

                Console.Write( 8 - i + " ");
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

            Console.Write("  ");
            for (int k = 1; k <= tab.linhas; k++)
            {
                Console.Write((char)(k + 64) + " ");
            }
        }


        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            Console.WriteLine();
            int quadricula = 1;

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.Magenta;

            for (int i = 0; i < tab.linhas; i++)
            {
                quadricula *= -1;

                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        if (quadricula == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
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

            Console.BackgroundColor = fundoOriginal;
            Console.Write("  ");
            for (int k = 1; k <= tab.linhas; k++)
            {
                Console.Write((char)(k + 64) + " ");
            }
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            // vai ler a posicao de input dada pelo utilizador
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                case Cor.White:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
