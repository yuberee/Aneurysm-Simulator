
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

public partial class AneurysmSimulator : Sandbox.Game
{

	public AneurysmSimulator()
	{

		if ( IsClient )
		{

			Fart.LoadSound();
			Fart.LoadImages();

			new FartUI();

		}

	}

	public override void ClientJoined( Client client )
	{

		base.ClientJoined( client );

	}

	[Event.Tick.Client]
	public void OnTick()
	{

		Fart.Backwards = Input.Down( InputButton.Attack1 );

	}

}
