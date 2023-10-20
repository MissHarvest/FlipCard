using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
