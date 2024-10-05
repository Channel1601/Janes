using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip musicClip1; 

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayMusic1()
    {
        if (audioSource.clip != musicClip1)
        {
            audioSource.clip = musicClip1;
            audioSource.Play();
        }
    }

}
