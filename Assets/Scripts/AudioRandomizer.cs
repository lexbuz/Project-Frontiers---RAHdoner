using System.Collections;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip[] monsterSounds;
    private AudioClip activeClip;
    private float waitTime = 0;
    private bool isPlaying = false;

    public void Update()
    {
        if(isPlaying == false)
        {
            PlayRandomSound();
        }
    }
    IEnumerator PlayRandomSound()
    {
        isPlaying = true;
        activeClip = monsterSounds[Random.Range(0,monsterSounds.Length)];
        audioSource.PlayOneShot(activeClip);
        yield return new WaitForSecondsRealtime(waitTime);
    }
}
