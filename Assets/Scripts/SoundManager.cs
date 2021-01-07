using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, coin;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        coin = Resources.Load<AudioClip>("coin");
        audioSource = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip) {
            case "jump":
                audioSource.PlayOneShot(jump, 0.6f);
                break;
            case "coin":
                audioSource.PlayOneShot(coin, 0.1f);
                break;
        }
    }
}
