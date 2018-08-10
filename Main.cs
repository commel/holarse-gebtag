using System;
using System.IO;
using System.Collections.Generic;

namespace Holarse 
{

	public class App 
	{

		static void Main(string[] args) 
		{
			GameSource gs = new GameSource("games.txt");
			foreach(string game in gs.GetGames()) 
			{
				Console.WriteLine(game);
			}

			ParticipantSource ps = new ParticipantSource("users.txt");
			foreach(Participant p in ps.GetParticipants())
			{
				Console.WriteLine(p.name);
			}
		}	
	}

	public class Participant
	{
		public string name { get; set; }
		public List<string> ignoreGames { get; } = new List<string>();
	
		public Participant() {}
		public Participant(string name)
		{
			this.name = name;
		}


		public void AddIgnoreGame(string game)
		{
			ignoreGames.Add(game);
		}
	}

	public class ParticipantSource
	{
		private string filename { get; }		

		public ParticipantSource(string filename) 
		{
			this.filename = filename;
		}

		public List<Participant> GetParticipants()
		{
			List<Participant> participants = new List<Participant>();
			try 
			{
				StreamReader sr = new StreamReader(this.filename);
				string line = "";
				while ( (line = sr.ReadLine()) != null)
				{
					if (line.StartsWith("#")) { continue; }
					string[] items = line.Split(',');
					
					Participant p = new Participant(items[0]);
					participants.Add(p);
				}
			} catch (IOException e) 
			{
				Console.WriteLine("Read error {0}", e);
			}

			return participants;
		}
	}

	public class GameSource
	{
		private string filename { get; }
	
		public GameSource(string filename)
		{
			this.filename = filename;
		}

		public List<string> GetGames()
		{
			List<string> games = new List<string>();

			try {
				StreamReader sr = new StreamReader(this.filename);
				string line = "";
				while ( (line = sr.ReadLine()) != null) 
				{
					string game = line.Trim();
					if (game.Length > 0) {
						games.Add(game);
					}	
				}
			} catch (IOException e) {
				Console.WriteLine("Error reading file {0}", e);
			}
			return games;
		}

	}

}

