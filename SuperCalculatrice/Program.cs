﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Threading;

namespace SuperCalculatrice
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//charge plein de .dll dans un dossier, pour chaque fichier on va voir dedans, une dll en plus pour chaque operation
			Console.WriteLine("=== Bienvenue dans la super calculatrice 3000 ===");
			Console.WriteLine("Les differentes commandes possibles :\nsin, cos, tan, max, min, sum, sub, div, mult");
			Console.WriteLine("Vous devez laisser un espace entre la commande et le parametre");
			Console.WriteLine("Il faut laisser un espace entre les parametres, par exemple : sum 2 4 6 pour faire " +
			                  "la somme de 2, 4 et 6");
			Console.WriteLine("Vous ne pouvez fournir qu'un parametre pour sin, cos et tan");
			Console.WriteLine("Vous pouvez quitter le programme a tout moment en tapant quit\n\n");

			// The output is bin/debug so we have to get back once to the project path and one last time to get back to the solution path
			string solutionpath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
			// Take all libraries in the path
			string[] filePaths = Directory.GetFiles(solutionpath, "*.dll");

			string input = Console.ReadLine();

			bool valid_input = false;
			//bool valid = false;
			while (input != "quit")
			{
				string[] splitinput = input.Split(new Char[] { ' ' });

				if (splitinput[0] != "")
				{
					Console.WriteLine("test2");
					AssemblySearch result;
					foreach (string lib in filePaths)
					{
						// Load assemblies .dll
						Assembly assembly = Assembly.LoadFrom(lib);
						result = new AssemblySearch(assembly, valid_input, splitinput);
						valid_input = result.Compute();
						//Console.WriteLine(valid_input);
					}

					if (valid_input == false)
					{
						Console.WriteLine("Veuillez entrer une fonction valide");
					}
				}
				else 
				{
					Console.WriteLine("Veuillez entrer une commande et un argument");
				}

				input = Console.ReadLine();
				valid_input = false;
			}

		}
	}
}
