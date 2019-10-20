using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AudioManager
{
	static bool initialized = false;
	static AudioSource audioSource;
	static public Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

	public static bool Initialized
	{
		get { return initialized; }
	}

	public static void Initialize(AudioSource source){
		initialized = true;
		audioSource = source;
		audioClips.Add (AudioClipName.LoadScenePlayGame, (AudioClip)Resources.Load("audio/LoadScenePlaygame"));
		audioClips.Add (AudioClipName.DestroyBlockGameOverEvent, (AudioClip)Resources.Load ("audio/DestroyBlockGameOverEvent"));
		audioClips.Add (AudioClipName.BallsCounterGameOverEvent, (AudioClip)Resources.Load ("audio/BallsCounterGameOverEvent"));
		audioClips.Add (AudioClipName.DestroyBonusBlockEvent, (AudioClip)Resources.Load ("audio/DestroyBonusBlockEvent"));
		audioClips.Add (AudioClipName.DestroyFreezeBlockEvent, (AudioClip)Resources.Load ("audio/DestroyFreezeBlockEvent"));
		audioClips.Add (AudioClipName.DestroySpeedupBlockEvent, (AudioClip)Resources.Load ("audio/DestroySpeedupBlockEvent"));
		audioClips.Add (AudioClipName.DestroyStdBlockEvent, (AudioClip)Resources.Load ("audio/DestroyStdBlockEvent"));
		audioClips.Add (AudioClipName.RestartEvent, (AudioClip)Resources.Load ("audio/RestartEvent"));
		audioClips.Add (AudioClipName.BallCountEvent, (AudioClip)Resources.Load ("audio/CountBallEvent"));
		audioClips.Add (AudioClipName.ThemeSong, (AudioClip)Resources.Load ("audio/ThemeSong"));
		audioClips.Add (AudioClipName.paddle, (AudioClip)Resources.Load ("audio/paddle"));
		audioClips.Add (AudioClipName.zombie1, (AudioClip)Resources.Load ("audio/zombie1"));
		audioClips.Add (AudioClipName.zombie2, (AudioClip)Resources.Load ("audio/zombie2"));
		audioClips.Add (AudioClipName.zombie3, (AudioClip)Resources.Load ("audio/zombie3"));
		audioClips.Add (AudioClipName.zombie4, (AudioClip)Resources.Load ("audio/zombie4"));
		audioClips.Add (AudioClipName.zombie5, (AudioClip)Resources.Load ("audio/zombie5"));
		audioClips.Add (AudioClipName.zombie6, (AudioClip)Resources.Load ("audio/zombie6"));
	}

	public static void Play(AudioClipName name){
		audioSource.PlayOneShot (audioClips [name]);
	}

}

