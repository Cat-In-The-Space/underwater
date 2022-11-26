using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBGMusicController : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] clips;
    public int nextClip = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[nextClip++];
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (nextClip >= clips.Length)
            {
                nextClip = 0;
            }
            source.clip = clips[nextClip++];
            source.Play();
        }
    }
}
