using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager manager { get; private set; }

    [SerializeField] private AudioClip[] speechClips;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if (manager != null && manager != this)
        {
            Destroy(manager);
        }
        else
        {
            manager = this;
        }
    }

    public void PlayAudio(AudioClip clip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(soundObject, spawn.position, Quaternion.identity);

        audioSource.clip = clip;
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySpeechClip(Transform spawn, float volume, float pitch)
    {
        if (speechClips.Length == 0) return;
        AudioSource audioSource = Instantiate(soundObject, spawn.position, Quaternion.identity);

        audioSource.clip = speechClips[Random.Range(0, 3)];
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
