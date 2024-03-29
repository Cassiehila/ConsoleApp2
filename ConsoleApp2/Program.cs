// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // string dictionnairePath = "noms.txt";
    static List<string> listeMots; // Liste de mots en français

    static void Main(string[] args)
    {
        // Demande à l'utilisateur d'entrer les lettres
        Console.Write("Entrez les lettres (sans espace) : ");
        string lettresEntrees = Console.ReadLine();

        // Lecture des mots à partir du fichier texte
        listeMots = File.ReadAllLines("mots.txt").ToList();

        // Recherche des mots correspondants
        List<string> motsTrouves = TrouverMots(lettresEntrees);

        // Affichage des résultats
        if (motsTrouves.Any())
        {
            Console.WriteLine("Les mots correspondants sont :");
            foreach (string mot in motsTrouves)
            {
                Console.WriteLine(mot);
            }
        }
        else
        {
            Console.WriteLine("Aucune correspondance trouvée.");
        }
    }

    // Fonction pour vérifier si un mot peut être formé à partir des lettres données
    static List<string> TrouverMots(string lettres)
    {
        lettres = new string(lettres.OrderBy(c => c).ToArray()); // Trie les lettres entrées en ordre alphabétique
        List<string> correspondances = new List<string>();
        foreach (string mot in listeMots)
        {
            if (new string(mot.OrderBy(c => c).ToArray()) == lettres)
            {
                correspondances.Add(mot);
            }
        }
        return correspondances;
    }
}