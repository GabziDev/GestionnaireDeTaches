using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceListTaches {
    internal class Program {
        public static string nomTache;
        public static string prioriteTache;
        public static Dictionary<int, string> Tache = new Dictionary<int, string>();
        public static int id = 0;

        static void Main()
        {
            Console.WriteLine("Bienvenue dans le gestionnaire de tâches !\n");
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Ajouter une tâche");
            Console.WriteLine("2. Supprimer une tâche");
            Console.WriteLine("3. Lister les tâches");
            Console.WriteLine("4. Editer une tâche");
            Console.WriteLine("5. Quitter");
            Console.Write("\nVotre choix : ");

            int choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    Console.Clear();
                    AjouterTache();
                    break;
                case 2:
                    Console.Clear();
                    SupprimerTache();
                    break;
                case 3:
                    Console.Clear();
                    ListerTaches();
                    Main();
                    break;
                case 4:
                    Console.Clear();
                    EditerTache();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Main();
                    break;
            }
            Console.ReadKey();
        }

        static void AjouterTache()
        {
            Console.Write("\n\nNom de la tâche : ");
            nomTache = Console.ReadLine();

            id++;

            Tache.Add(id, nomTache);
            Console.Clear();
            Main();
        }

        static void ListerTaches()
        {
            Console.WriteLine("\n\nListe des tâches :");

            foreach (KeyValuePair<int, string> a in Tache)
            {
                if (string.IsNullOrEmpty(a.Value))
                {
               
                    Console.WriteLine("(Vide)");
                } else if (a.Key > 0)
                {
                    Console.WriteLine("{0}. {1}", a.Key, a.Value);
                } else
                {
                    Console.WriteLine("Erreur interne !");
                }
            }
        }

        static void SupprimerTache()
        {
            ListerTaches();

            Console.WriteLine("\n\nEntrez l'ID de la tâche à supprimer : ");

            int idDel = Convert.ToInt32(Console.ReadLine());

            Tache.Remove(idDel);

            Console.Clear();
            Main();
        }

        static void EditerTache()
        {
            ListerTaches();

            Console.WriteLine("Entrez l'ID de la tâche à editer : ");

            int idEdit = Convert.ToInt32(Console.ReadLine());
            Tache.Remove(idEdit);

            Console.WriteLine("Nouveau texte pour la tâche : ");
            string newText = Console.ReadLine();
            Tache.Add(idEdit, newText);
            Console.Write("Tâche éditée avec succès !");

            Console.Clear();
            Main();
        }
    }
}
