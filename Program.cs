using System;

namespace AgendaTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados[] n = new Dados[100];
            ConsoleKeyInfo opcao;
            ConsoleKeyInfo opcao2;
            int s = 1;
            int i = 0;
            
            int m = 0;
            string p;

            while (s != 0)
            {
                Console.WriteLine("\nMenu:\n" +
                   "1 - Gerenciar contatos.\n" +
                   "2 - Navegar pelos contatos.\n" +
                   "0 - Sair da agenda.\n" +
                   "Sua opção: ");
                opcao = Console.ReadKey();
                if (opcao.Key == ConsoleKey.NumPad1 || opcao.Key == ConsoleKey.D1)
                {
                    int r = 1;
                    while (r != 0)
                    {
                        Console.WriteLine("\n\nMenu:\n" +
                            "1 - Adicionar contato.\n" +
                            "2 - Remover contato.\n" +
                            "3 - Ordenar agenda.\n" +
                            "0 - Voltar.\n" +
                            "Sua opção: ");
                        opcao2 = Console.ReadKey();
                        if (opcao2.Key == ConsoleKey.NumPad1 || opcao2.Key == ConsoleKey.D1)
                        {
                            i++;
                            n[i] = new Dados();
                            Console.WriteLine("\nDigite o nome: ");
                            n[i].nome = Console.ReadLine();
                            Console.WriteLine("Digite o número: ");
                            n[i].numero = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o email: ");
                            n[i].email = Console.ReadLine();
                            m = i;
                        }
                        else if (opcao2.Key == ConsoleKey.NumPad2 || opcao2.Key == ConsoleKey.D2)
                        {
                            if (m != 0)
                            {
                                Console.WriteLine("\nNome do contato que deseja remover: ");
                                p = Console.ReadLine();
                                int a = 0;
                                for (i = 1; i <= m; i++)
                                {
                                    int b;
                                    if (n[i].nome == p)
                                    {
                                        for (b = i; b <= m; b++)
                                        {
                                            if (b != m)
                                            {
                                                n[b].nome = n[b + 1].nome;
                                                n[b].numero = n[b + 1].numero;
                                                n[b].email = n[b + 1].email;
                                            }
                                            else
                                            {
                                                n[b].nome = null;
                                                n[b].numero = 0;
                                                n[b].email = null;
                                            }
                                        }
                                        m--;
                                        Console.WriteLine("\nContato removido.");
                                        i = m;
                                        a++;
                                    }
                                }
                                if (a == 0)
                                {
                                    Console.WriteLine("\nNome não encontrado.");
                                }
                            }
                            else
                                Console.WriteLine($"\nNão possui nenhum contato salvo.");
                        }
                        else if (opcao2.Key == ConsoleKey.NumPad3 || opcao2.Key == ConsoleKey.D3)
                        {
                            if (m != 0)
                            {
                                string temp, s1, s2;
                                int aux;
                                for (i = 1; i < m; i++)
                                {
                                    s1 = n[i].nome;
                                    s2 = n[i + 1].nome;
                                    if (s1.CompareTo(s2) > 0)
                                    {
                                        n[i].nome = s2;
                                        n[i + 1].nome = s1;

                                        aux = n[i].numero;
                                        n[i].numero = n[i + 1].numero;
                                        n[i + 1].numero = aux;

                                        temp = n[i].email;
                                        n[i].email = n[i + 1].email;
                                        n[i + 1].email = temp;
                                        i = 0;
                                    }
                                }
                                Console.WriteLine("\nAgenda ordenada.");
                            }
                            else
                                Console.WriteLine($"\nNão possui nenhum contato salvo.");
                        }
                        else if (opcao2.Key == ConsoleKey.NumPad0 || opcao2.Key == ConsoleKey.D0)
                        {
                            Console.WriteLine("\nVoltando pro menu anterior.");
                            r--;
                        }
                        else
                            Console.WriteLine($"\nOpção incorreta, tente novamente.");
                    }
                }
                else if (opcao.Key == ConsoleKey.NumPad2 || opcao.Key == ConsoleKey.D2)
                {
                    if (m != 0)
                    {
                        i = 1;
                        int a = 1;
                        ConsoleKeyInfo key;
                        Console.WriteLine($"\nUse as setas para navegar pelos contatos ou 0 para sair.");
                        Console.WriteLine($"\nContato: {i}");
                        Console.WriteLine($"Nome: {n[i].nome}");
                        Console.WriteLine($"Número: {n[i].numero}");
                        Console.WriteLine($"Email: {n[i].email}");
                        while (a != 0)
                        {
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
                            {
                                if (key.Key == ConsoleKey.LeftArrow)
                                {
                                    if (i != 1)
                                        i--;
                                    else
                                        i = m;
                                }
                                else if (key.Key == ConsoleKey.RightArrow)
                                {
                                    if (i != m)
                                        i++;
                                    else
                                        i = 1;
                                }
                                Console.WriteLine($"\nContato {i}");
                                Console.WriteLine($"Nome: {n[i].nome}");
                                Console.WriteLine($"Número: {n[i].numero}");
                                Console.WriteLine($"Email: {n[i].email}");
                            }
                            else if (key.Key == ConsoleKey.NumPad0 || key.Key == ConsoleKey.D0)
                                a--;
                            else
                                Console.WriteLine($"\nOpção incorreta, tente novamente.");
                        }
                    }
                    else
                        Console.WriteLine($"\nNão possui nenhum contato salvo.");
                }
                else if (opcao.Key == ConsoleKey.NumPad0 || opcao.Key == ConsoleKey.D0)
                {
                    Console.WriteLine("\nAdeus.");
                    s--;
                }
                else
                {
                    Console.WriteLine("\nOpção incorreta, tente novamente.");
                }
            }
        }
    }
}
