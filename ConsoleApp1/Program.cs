using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fila_hosp
{
    class Paciente
    {
        public string nome;
        public int idade;
        public bool preferencial;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Paciente[] filaPacientes = new Paciente[15];
            int quantidade = 0;
            string opcao;

        menu:
            Console.WriteLine("menu:");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Atender");
            Console.WriteLine("4 - Alterar");
            Console.WriteLine("q - Sair");
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                if (quantidade == 15)
                {
                    Console.WriteLine("Fila cheia!");
                    goto menu;
                }

                Paciente paciente = new Paciente();

                Console.Write("Nome: ");
                paciente.nome = Console.ReadLine();

                Console.Write("Idade: ");
                paciente.idade = int.Parse(Console.ReadLine());

                Console.Write("Preferencial? (s/n): ");
                string resposta = Console.ReadLine();
                if (resposta == "s")
                {
                    paciente.preferencial = true;
                }
                else
                {
                    paciente.preferencial = false;
                }

                if (paciente.preferencial == true)
                {
                    for (int i = quantidade; i > 0; i--)
                    {
                        filaPacientes[i] = filaPacientes[i - 1];
                    }
                    filaPacientes[0] = paciente;
                }
                else
                {
                    filaPacientes[quantidade] = paciente;
                }

                quantidade++;
                Console.WriteLine("Paciente cadastrado!\n");
                goto menu;
            }

            if (opcao == "2")
            {
                Console.WriteLine("\nFila:");
                if (quantidade == 0)
                {
                    Console.WriteLine("Nenhum paciente.\n");
                }
                else
                {
                    for (int i = 0; i < quantidade; i++)
                    {
                        if (filaPacientes[i].preferencial == true)
                        {
                            Console.WriteLine((i + 1) + ". " + filaPacientes[i].nome + " - " + filaPacientes[i].idade + " anos [P]");
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + ". " + filaPacientes[i].nome + " - " + filaPacientes[i].idade + " anos");
                        }
                    }
                }
                goto menu;
            }

            if (opcao == "3")
            {
                if (quantidade == 0)
                {
                    Console.WriteLine("Ninguém na fila.\n");
                }
                else
                {
                    Console.WriteLine("Atendendo: " + filaPacientes[0].nome + " - " + filaPacientes[0].idade + " anos");

                    for (int i = 0; i < quantidade - 1; i++)
                    {
                        filaPacientes[i] = filaPacientes[i + 1];
                    }

                    filaPacientes[quantidade - 1] = null;
                    quantidade--;
                }
                goto menu;
            }

            if (opcao == "4")
            {
                if (quantidade == 0)
                {
                    Console.WriteLine("Fila vazia.\n");
                    goto menu;
                }

                for (int i = 0; i < quantidade; i++)
                {
                    Console.WriteLine((i + 1) + ". " + filaPacientes[i].nome + " - " + filaPacientes[i].idade + " anos");
                }

                Console.Write("Número do paciente: ");
                int posicao = int.Parse(Console.ReadLine()) - 1;

                if (posicao < 0 || posicao >= quantidade)
                {
                    Console.WriteLine("Número inválido!\n");
                    goto menu;
                }

                Console.Write("Novo nome: ");
                filaPacientes[posicao].nome = Console.ReadLine();

                Console.Write("Nova idade: ");
                filaPacientes[posicao].idade = int.Parse(Console.ReadLine());

                Console.WriteLine("Alterado.\n");
                goto menu;
            }

            if (opcao == "q")
            {
                Console.WriteLine("Saindo...");
                return;
            }

            Console.WriteLine("Opção errada.\n");
            goto menu;
        }
    }
}
