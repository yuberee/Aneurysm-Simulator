
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

public struct Rank
{

	public string Name { get; }
	public int RequiredPoints { get; }
	public float SpeedMultiplier { get; }
	
	public Rank( string name = "null", int requiredPoints = 0, float speedMultiplier = 1f )
	{

		Name = name;
		RequiredPoints = requiredPoints;
		SpeedMultiplier = speedMultiplier;

	}

}

public static class Ranking
{

	public static List<Rank> Data { get; } = new List<Rank>(){
		new Rank( "🦽 Impaired 🦽", 0, 1f ),
		new Rank( "🤓 Mingebag 🤓", 100, 1.2f ),
		new Rank( "🐱 Flopper 🐱", 300, 1.5f ),
		new Rank( "🧱 Bricka 🧱", 1000, 2f ),
		new Rank( "🕴 Mojangster 🕴", 3000, 3f ),
		new Rank( "🏀 Baller 🏀", 10000, 5f ),
		new Rank( "👑 King 👑", 30000, 8f ),
		new Rank( "🧠 Prodigy 🧠", 100000, 15f ),
		new Rank( "💰 Gangster 💰", 300000, 40f ),
		new Rank( "😼 Mark 😼", 1000000, 100f )
	};
	public static int Current = 0;

	static Ranking()
	{


	}

}

