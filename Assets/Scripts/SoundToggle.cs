using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    GameObject toggle;

    private bool ignoreToggle; // setting toggle value also fires up toggle event

    // Start is called before the first frame update
    void Start()
    {
        ignoreToggle = true;
        toggle = GameObject.Find("SoundToggle");
        setToggle(); 
    }

    public void ToggleSound()
    {

        if(!ignoreToggle) {
            if(PlayerPrefs.GetInt("Muted") == 0) {
                PlayerPrefs.SetInt("Muted",1);
                AudioListener.volume = 0;
            }
            else {
                PlayerPrefs.SetInt("Muted",0);
                AudioListener.volume = 1;
            }
        } 
        
    }

    public void setToggle()
    {
        
        if(PlayerPrefs.GetInt("Muted",0) == 0) {
            AudioListener.volume = 1;
            toggle.GetComponent<Toggle>().isOn = true;
        }
        else {
            AudioListener.volume = 0;
            toggle.GetComponent<Toggle>().isOn = false;
        }
        ignoreToggle = false;
    }
}
