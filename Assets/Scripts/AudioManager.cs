using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;



    [Header("Sounds")]

    public AudioClip[] sounds;

    public string[] soundNames;



    [Header("Music")]

    public AudioClip[] musicTracks;

    public string[] musicNames;



    private AudioSource soundSource;

    private AudioSource musicSource;



    private void Awake()

    {

        if (instance == null)

        {

            instance = this;

            DontDestroyOnLoad(gameObject);

        }

        else if (instance != this)

        {

            Destroy(gameObject);

            return;

        }



        soundSource = gameObject.AddComponent<AudioSource>();

        musicSource = gameObject.AddComponent<AudioSource>();



        musicSource.loop = true; // niin että musiikki looppaisi automaattisesti

    }



    public void PlaySound(string soundName)

    {

        for (int i = 0; i < soundNames.Length; i++)

        {

            if (soundNames[i] == soundName)

            {

                soundSource.PlayOneShot(sounds[i]);

                return;

            }

        }

        Debug.LogWarning("Sound named " + soundName + " not found!");

    }



    public void PlayMusic(string musicName)

    {

        for (int i = 0; i < musicNames.Length; i++)

        {

            if (musicNames[i] == musicName)

            {

                if(musicSource.isPlaying)

                    musicSource.Stop();

                musicSource.clip = musicTracks[i];

                musicSource.Play();

                return;

            }

        }

        Debug.LogWarning("Music track named " + musicName + " not found!");

    }
    public void PauseMusic()

    {

        if (musicSource.isPlaying)

        {

            musicSource.Pause();

        }

    }



    public void ResumeMusic()

    {

        if (!musicSource.isPlaying)

        {

            musicSource.UnPause();

        }

    }



    public void SetSoundVolume(float volume)

    {

        volume = Mathf.Clamp01(volume);  

        soundSource.volume = volume;

    }



    public void SetMusicVolume(float volume)

    {

        volume = Mathf.Clamp01(volume);

        musicSource.volume = volume;

    }
}