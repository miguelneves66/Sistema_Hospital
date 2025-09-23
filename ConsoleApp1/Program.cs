using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sitema_hosp
{
    class Paciente
    {
        public string Nome;
        public int Idade;
        public virtual bool Preferencial { get { return false; } }
        public override string ToString()
        {
            return Nome + " - " + Idade + " anos";
        }
    }

    class PacientePreferencial : Paciente
    {
        public override bool Preferencial { get { return true; } }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Paciente[] fila = new Paciente[15];
            int quantidade = 0;
            string opcao;

        menu:
            Console.WriteLine("menu:\n");
            Console.WriteLine("1-Cadastrar paciente");
            Console.WriteLine("2-Listar fila");
            Console.WriteLine("3-Atender paciente");
            Console.WriteLine("4-Alterar paciente");
            Console.WriteLine("q-Sair\n");
            Console.Write(": ");
            opcao = Console.ReadLine();
            if (opcao == "1")
            {
                if (quantidade >= 15)
                {
                    Console.WriteLine("Fila cheia.\n");
                    goto menu;
                }

                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Idade: ");
                int idade = int.Parse(Console.ReadLine());
                Console.Write("Preferencial? (s/n): ");
                string pref = Console.ReadLine();

                Paciente p;
                if (pref == "s")
                {
                    p = new PacientePreferencial();
                }
                else
                {
                    p = new Paciente();
                }

                p.Nome = nome;
                p.Idade = idade;

                if (p.Preferencial == true)
                {
                    for (int i = quantidade; i > 0; i--)
                    {
                        fila[i] = fila[i - 1];
                    }
                    fila[0] = p;
                }
                else
                {
                    fila[quantidade] = p;
                }

                quantidade = quantidade + 1;
                Console.WriteLine("Paciente cadastrado.\n");
                goto menu;
            }

            if (opcao == "2")
            {
                Console.WriteLine("\nFila:");
                if (quantidade == 0)
                {
                    Console.WriteLine("Fila vazia.\n");
                }
                else
                {
                    for (int i = 0; i < quantidade; i++)
                    {
                        string tipo;
                        if (fila[i].Preferencial == true)
                        {
                            tipo = "[P]";
                        }
                        else
                        {
                            tipo = "";
                        }

                        Console.WriteLine((i + 1) + ". " + fila[i] + " " + tipo);
                    }
                }
                goto menu;
            }

            if (opcao == "3")
            {
                if (quantidade == 0)
                {
                    Console.WriteLine("Nenhum paciente.");
                }
                else
                {
                    Console.WriteLine("Atendendo: " + fila[0]);

                    for (int i = 0; i < quantidade - 1; i++)
                    {
                        fila[i] = fila[i + 1];
                    }

                    fila[quantidade - 1] = null;
                    quantidade = quantidade - 1;
                }
                goto menu;
            }

            if (opcao == "4")
            {
                if (quantidade == 0)
                {
                    Console.WriteLine("Fila vazia.");
                    goto menu;
                }

                for (int i = 0; i < quantidade; i++)
                {
                    Console.WriteLine((i + 1) + ". " + fila[i]);
                }

                Console.Write("Número do paciente: ");
                int pos = int.Parse(Console.ReadLine()) - 1;

                if (pos < 0 || pos >= quantidade)
                {
                    Console.WriteLine("Inválido.\n");
                    goto menu;
                }

                Console.Write("Novo nome: ");
                fila[pos].Nome = Console.ReadLine();
                Console.Write("Nova idade: ");
                fila[pos].Idade = int.Parse(Console.ReadLine());

                Console.WriteLine("Alterado.\n");
                goto menu;
            }

            if (opcao == "q")
            {
                Console.WriteLine("Saindo...\n");
                return;
            }

            Console.WriteLine("Opção errada!\n");
            goto menu;
        }
    }
}
