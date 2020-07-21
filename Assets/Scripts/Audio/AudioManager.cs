﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Back, 
            Resources.Load<AudioClip>("Back"));
        audioClips.Add(AudioClipName.Bonus,
            Resources.Load<AudioClip>("Bonus"));
        audioClips.Add(AudioClipName.Click,
            Resources.Load<AudioClip>("Click"));
        audioClips.Add(AudioClipName.Freezer,
             Resources.Load<AudioClip>("Freezer"));
        audioClips.Add(AudioClipName.Pause,
             Resources.Load<AudioClip>("Pause"));
        audioClips.Add(AudioClipName.Speedup,
              Resources.Load<AudioClip>("Speedup"));
        audioClips.Add(AudioClipName.Standar,
            Resources.Load<AudioClip>("Standar"));
        audioClips.Add(AudioClipName.TryAgain,
            Resources.Load<AudioClip>("TryAgain"));
        audioClips.Add(AudioClipName.YouWin,
            Resources.Load<AudioClip>("YouWin"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
