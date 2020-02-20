using System;
using System.Globalization;
using System.Collections.Generic;
using Secao06.Vetores;
using Secao06.Listas;

namespace Secao06
{
    class Program
    {
        static void Main(string[] args)
        {

            //ExercicioFixacaoVetores();
            //ExercicioFixacaoListas();
            //ExercicioFixacaoMatrizes();
            ExercicioFixacaoConjuntos();

        }

        static void ExercicioFixacaoVetores()
        {
            Console.Write("Quantos quartos serão alugados? ");
            int n = int.Parse(Console.ReadLine());

            Estudante[] vect = new Estudante[10];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Aluguel #" + (i + 1));

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Quarto: ");
                int quarto = int.Parse(Console.ReadLine());

                vect[quarto-1] = new Estudante(nome, email);
            }


            Console.WriteLine("\nQuartos ocupados: ");

            for (int i = 0; i < vect.Length; i++)
            {
                if (vect[i] != null)
                {
                    Console.WriteLine((i+1) + ": " + vect[i].ToString());
                }
            }
        }

        static void ExercicioFixacaoListas()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("How many employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nEmployee #" + i + ": ");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                employees.Add(new Employee(id, name, salary));
            }

            Console.Write("\nEnter the employee id tha will have salary increase: ");
            int idIncrease = int.Parse(Console.ReadLine());
            Employee em = employees.Find(x => x.Id == idIncrease);
            if (em != null)
            {
                Console.Write("Enter the percentage: ");
                double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                em.IncreaseSalary(percentage);
            }
            else
            {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine("\nUpdated list of employees:");

            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }
        }

        static void ExercicioFixacaoMatrizes()
        {
            string[] nums = Console.ReadLine().Split(' ');

            int M = int.Parse(nums[0]);
            int N = int.Parse(nums[1]);

            int[,] mat = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                string[] linha = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = int.Parse(linha[j]);
                }
            }

            int X = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (mat[i, j] == X)
                    {
                        Console.WriteLine("Position " + i + "," + j + ":");
                        if (j - 1 >= 0) Console.WriteLine("Left: " + mat[i, j - 1]);
                        if (i - 1 >= 0) Console.WriteLine("Up: " + mat[i - 1, j]);
                        if (j + 1 < N) Console.WriteLine("Right: " + mat[i, j + 1]);
                        if (i + 1 < M) Console.WriteLine("Down: " + mat[i + 1, j]);
                    }
                }
            }
        }

        static void ExercicioFixacaoConjuntos()
        {
            HashSet<int> idA = new HashSet<int>();
            HashSet<int> idB = new HashSet<int>();
            HashSet<int> idC = new HashSet<int>();

            Console.Write("O curso A possui quantos alunos? ");
            int numAluno = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite os Códigos dos alunos do curso A");
            for (int i = 0; i < numAluno; i++)
            {
                idA.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("\nO curso B possui quantos alunos? ");
            numAluno = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite os Códigos dos alunos do curso B");
            for (int i = 0; i < numAluno; i++)
            {
                idB.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("\nO curso C possui quantos alunos? ");
            numAluno = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite os Códigos dos alunos do curso C");
            for (int i = 0; i < numAluno; i++)
            {
                idC.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> todosAlunos = new HashSet<int>();

            todosAlunos.UnionWith(idA);
            todosAlunos.UnionWith(idB);
            todosAlunos.UnionWith(idC);

            Console.WriteLine("\nTotal de alunos: " + todosAlunos.Count);
        }
    }
}
