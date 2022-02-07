using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Collections.Generic;

public partial class FartUI : Sandbox.HudEntity<RootPanel>
{

	public FartUI()
	{

		RootPanel.Style.BackgroundSizeX = Length.Percent( 100 );
		RootPanel.Style.BackgroundSizeY = Length.Percent( 100 );

	}

	[Event.Frame]
	public void Update()
	{

		RootPanel.Style.SetBackgroundImage( Fart.Frame );


	}

}

public static partial class Fart
{
	private static Texture[] imageData = new Texture[ Frames ];
	public static Texture Frame { get { return imageData[ (int)( Progress * ( Frames - 1 ) ) ]; } }

	public static void LoadImages()
	{

		for ( int i = 0; i < Frames; i++ )
		{

			Span<byte> loadedData = FileSystem.Mounted.ReadAllBytes( $"ui/fart{ i }.png" );
			MemoryStream frameStream = new MemoryStream( loadedData.ToArray() );
			imageData[i] = Sandbox.TextureLoader.Image.Load( frameStream );

		}

	}

}

