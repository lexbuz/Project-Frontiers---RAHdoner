using System.Collections;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip[] monsterSounds;
    [SerializeField] GameObject gameObject;
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
        yield return new WaitForSecondsRealtime(waitTime);
    }
}
