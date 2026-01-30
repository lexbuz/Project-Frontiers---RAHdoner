using System.Collections;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip[] monsterSounds;
    private AudioClip activeClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayRandomSound();
        }
    }
    public void PlayRandomSound()
    {
        activeClip = monsterSounds[Random.Range(0,monsterSounds.Length)];
        audioSource.PlayOneShot(activeClip);
        Debug.Log("sound played");
    }
}
