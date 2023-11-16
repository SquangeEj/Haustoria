using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SoundFXManager : MonoBehaviour
{
    public static SCR_SoundFXManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip[] audioClip, AudioSource audioSource)
    {
        //assign a random index
        int rand = Random.Range(0, audioClip.Length);

        audioSource.clip = audioClip[rand];
        audioSource.Play();
    }

    public void PlayRandomFootstep(AudioClip[] audioClips, AudioSource audioSource)
    {
        int rand = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[rand];
        audioSource.volume = Random.Range(0.6f, 1);
        //audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }

    public void PlayFootstepSequence(AudioClip[] audioClips, AudioSource audioSource)
    {
        StartCoroutine(PlayFootstepSequenceCoroutine(audioClips, audioSource));
    }

    IEnumerator PlayFootstepSequenceCoroutine(AudioClip[] audioClips, AudioSource audioSource)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play();

            // Wait for the current footstep sound to finish playing
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
}
