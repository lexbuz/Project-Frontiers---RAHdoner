using System.Collections;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip[] monsterSounds;
    [SerializeField] GameObject gameObject;
    private AudioClip isPlaying;
    private float waitTime;

    public void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            PlayRandomSound();
        }
    }
    IEnumerator PlayRandomSound()
    {
        isPlaying = monsterSounds[Random.Range(0,monsterSounds.Length)];
        yield return new WaitForSecondsRealtime(waitTime);
    }
}
