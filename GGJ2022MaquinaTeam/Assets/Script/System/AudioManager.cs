using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    private void Start()
    {
        PlaySound("Theme");
        PlaySound("DarkTheme");
        ChangeWorld(true, false);
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pithc;
            sound.source.loop = sound.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            sound.source.Play();
        }
    }

    private void ManageVolumen(string name, bool mute)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (mute)
        {
            sound.source.volume = 0;
        } else
        {
            sound.source.volume = sound.volume;
        }
    }

    public void ChangeWorld(bool isNormal, bool isBossBattle)
    {
        if (!isBossBattle)
        {
            if (isNormal)
            {
                ManageVolumen("Theme", false);
                ManageVolumen("DarkTheme", true);
            } else
            {
                ManageVolumen("Theme", true);
                ManageVolumen("DarkTheme", false);
            }
        }
    }
}
