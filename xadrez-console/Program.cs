using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro Tab;

                Tab = new Tabuleiro(8, 8);

                Tab.colocarPeca(new Torre(Tab, Cor.Black), new Posicao(0, 0));
                Tab.colocarPeca(new Torre(Tab, Cor.Red), new Posicao(1, 3));
                Tab.colocarPeca(new Rei(Tab, Cor.Green), new Posicao(2, 4));
                Tab.colocarPeca(new Rei(Tab, Cor.Blue), new Posicao(3, 3));



                Tela.imprimirTabuleiro(Tab);

                //PosicaoXadrez Posicao = new PosicaoXadrez('c', 7);

                //Console.WriteLine(Posicao);
                //Console.WriteLine(Posicao.toPosicao()); 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.ReadLine();
        }
    }
}
