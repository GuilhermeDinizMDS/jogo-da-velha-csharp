using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogadorAtual = 1; // 1 para X, 2 para O

        static void Main(string[] args)
        {
            int escolha;
            int status = 0; // 0: jogo rodando, 1: vitória, -1: empate

            do
            {
                Console.Clear();
                Console.WriteLine("=== JOGO DA VELHA EM C# ===\n");
                Console.WriteLine("Jogador 1: X  |  Jogador 2: O\n");

                DesenharTabuleiro();

                Console.WriteLine($"\nVez do Jogador {(jogadorAtual == 1 ? "1 (X)" : "2 (O)")}. Escolha uma posição (1-9): ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out escolha) && escolha >= 1 && escolha <= 9)
                {
                    // Verifica se a posição escolhida ainda não foi ocupada por X ou O
                    if (tabuleiro[escolha - 1] != 'X' && tabuleiro[escolha - 1] != 'O')
                    {
                        tabuleiro[escolha - 1] = (jogadorAtual == 1) ? 'X' : 'O';
                        status = VerificarVitoria();

                        if (status == 0)
                        {
                            // Alterna o jogador
                            jogadorAtual = (jogadorAtual == 1) ? 2 : 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Essa posição já está ocupada! Pressione ENTER para tentar novamente.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Escolha um número de 1 a 9. Pressione ENTER para continuar.");
                    Console.ReadLine();
                }

            } while (status == 0);

            Console.Clear();
            Console.WriteLine("=== JOGO DA VELHA EM C# ===\n");
            DesenharTabuleiro();

            if (status == 1)
            {
                Console.WriteLine($"\n🎉 Parabéns! O Jogador {(jogadorAtual == 1 ? "1 (X)" : "2 (O)")} venceu!");
            }
            else
            {
                Console.WriteLine("\n🤝 O jogo terminou em EMPATE!");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DesenharTabuleiro()
        {
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {tabuleiro[0]}  |  {tabuleiro[1]}  |  {tabuleiro[2]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {tabuleiro[3]}  |  {tabuleiro[4]}  |  {tabuleiro[5]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {tabuleiro[6]}  |  {tabuleiro[7]}  |  {tabuleiro[8]}  ");
            Console.WriteLine($"     |     |     ");
        }

        static int VerificarVitoria()
        {
            // Linhas
            if (tabuleiro[0] == tabuleiro[1] && tabuleiro[1] == tabuleiro[2]) return 1;
            if (tabuleiro[3] == tabuleiro[4] && tabuleiro[4] == tabuleiro[5]) return 1;
            if (tabuleiro[6] == tabuleiro[7] && tabuleiro[7] == tabuleiro[8]) return 1;

            // Colunas
            if (tabuleiro[0] == tabuleiro[3] && tabuleiro[3] == tabuleiro[6]) return 1;
            if (tabuleiro[1] == tabuleiro[4] && tabuleiro[4] == tabuleiro[7]) return 1;
            if (tabuleiro[2] == tabuleiro[5] && tabuleiro[5] == tabuleiro[8]) return 1;

            // Diagonais
            if (tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8]) return 1;
            if (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6]) return 1;

            // Empate (todas as posições preenchidas sem vencedor)
            if (tabuleiro[0] != '1' && tabuleiro[1] != '2' && tabuleiro[2] != '3' &&
                tabuleiro[3] != '4' && tabuleiro[4] != '5' && tabuleiro[5] != '6' &&
                tabuleiro[6] != '7' && tabuleiro[7] != '8' && tabuleiro[8] != '9')
            {
                return -1;
            }

            return 0; // Jogo continua
        }
    }
}