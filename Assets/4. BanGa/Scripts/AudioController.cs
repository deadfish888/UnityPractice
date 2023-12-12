namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class AudioController : Singleton<AudioController>
    {
        [Header("Main Settings:")]
        [Range(0f, 1f)]
        public float musicVolume;
        [Range(0f, 1f)]
        public float sfxVolume;

        public AudioSource musicAus;
        public AudioSource sfxAus;

        [Header("Game Sounds And Musics:")]
        public AudioClip shooting;
        public AudioClip win;
        public AudioClip lose;
        public AudioClip[] bgmusics;

        public override void Awake()
        {
            MakeSingleton(false);
        }

        public override void Start()
        {
            PlayMusic(bgmusics);
        }

        public void PlaySound(AudioClip sound, AudioSource aus = null)
        {
            if (!aus)
            {
                aus = sfxAus;
            }

            if (aus)
            {
                aus.PlayOneShot(sound, sfxVolume);
            }
        }

        public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
        {
            if (!aus)
            {
                aus = sfxAus;
            }

            if (aus)
            {
                int randomIdx = Random.Range(0, sounds.Length);
                if (sounds[randomIdx] != null)
                {
                    aus.PlayOneShot(sounds[randomIdx], sfxVolume);
                }
            }
        }

        public void PlayMusic(AudioClip music, bool loop = true)
        {
            if (musicAus)
            {
                musicAus.clip = music;
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }

        public void PlayMusic(AudioClip[] musics, bool loop = true)
        {
            if (musicAus)
            {
                int ranIdx = Random.Range(0, musics.Length);
                if (musics[ranIdx] != null)
                {
                    musicAus.clip = musics[ranIdx];
                    musicAus.loop = loop;
                    musicAus.volume = musicVolume;
                    musicAus.Play();
                }

            }
        }
    }
}