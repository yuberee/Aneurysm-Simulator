
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

public static partial class Fart
{

	public const float Duration = 1.717f; // Not sure how to dynamically get the length of a sound from its file so I do it manually for now
	public const int Frames = 46;
	public const float FrameRate = 29; // Should be 29.97, but I removed 3 black images beacause they were annoying so I do 29 so it syncs with the audio
	public const int SampleRate = 44100; // I know that it's supposed to be Frame Rate for sound as well, but I already have Frame Rate for the images
	private static float progress = 0f;
	public static float Progress { get { return progress; } }
	private static float speed = 1f;
	private static bool backwards = false;
	public static bool Backwards
	{

		get { return backwards; }
		set
		{

			if ( backwards != value )
			{

				backwards = value;
				Switch();

			}

		}

	}

	private static void Switch()
	{

		speed = Rand.Float( 0.3f ) + 0.9f + Time.Now / 50f; // TODO: Change depending on your rank
		PlaySound();

	}

	[Event.Frame]
	private static void UpdateProgress()
	{

		progress = Math.Clamp( progress + (Time.Delta / Duration) * (backwards ? 1 : -1) * speed, 0, 1 );

		fartSound.SetVolume( Math.Min( progress * 2, 1 ) ); // This is so you don't hear that annoying *click* at the beginning of the sound, I don't know how to remove it otherwise, it persists even when exporting with no metadata.

		if ( progress == 1 )
		{

			CloseGame();

		}

	}

	[ServerCmd]
	public static void CloseGame()
	{

		Log.Error( "😱 YOU BUSTED 💀" );
		ConsoleSystem.Caller.Kick();

	}

}

