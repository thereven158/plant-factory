using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    public GameHandler gM;
    public AudioClip audioClip;
    AudioSource audioSource;

    public float volume;
    bool entered = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (entered) gM.HealingArea();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            entered = true;
            audioSource.PlayOneShot(audioClip, volume);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            entered = false;
            audioSource.Stop();

            Debug.Log("Exit trigger");
        }
    }

}
