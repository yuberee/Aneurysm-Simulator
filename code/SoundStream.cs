using Sandbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Runtime.InteropServices;

public static partial class Fart
{

	private static Sound fartSound;
	private static SoundStream fartSoundStream;
	private static short[] soundData;
	private static short[] reversedSoundData;

	public static void LoadSound()
	{

		// 1 Short = 2 Bytes
		Span<byte> byteData = FileSystem.Mounted.ReadAllBytes( "sounds/fart.wav" );
		soundData = new short[byteData.Length / 2];
		Span<short> soundDataCopy = new Span<short>( new short[soundData.Length] );

		for ( int i = 0; i < soundData.Length; i++ )
		{

			soundData[i] = (short)(byteData[i * 2 + 1] << 8); // Turn 2 Bytes into 1 Short
			soundDataCopy[i] = soundData[i];
		}

		soundDataCopy.Reverse<short>();
		reversedSoundData = soundDataCopy.ToArray(); // Reversing an array doesn't work as opposed to reversing a Span

	}

	private static void StartSound( float PlaySpeed = 1f )
	{

		fartSound.Stop();

		fartSound = Sound.FromWorld( "audiostream.default", Vector3.Zero ); // Doesn't play in 2D?
		fartSoundStream = fartSound.CreateStream( (int)( SampleRate * PlaySpeed ) );

	}

	public static void PlaySound()
	{

		StartSound( speed );

		Span<short> soundCut = new Span<short>( new short[soundData.Length] );

		if ( backwards )
		{

			var slice = soundData.AsSpan<short>().Slice( (int)(soundData.Length * progress) );
			slice.CopyTo( soundCut );

		}
		else
		{

			var slice = reversedSoundData.AsSpan<short>().Slice( (int)(reversedSoundData.Length * (1 - progress)) );
			slice.CopyTo( soundCut );

		}

		fartSoundStream.WriteData( soundCut );

	}

}

