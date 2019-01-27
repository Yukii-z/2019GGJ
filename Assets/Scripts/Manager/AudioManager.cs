using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public GameObject audioManaObj;
    void Awake()
    {
        audioManaObj = GameObject.Find("AudioManager");
    }

    public void PlaySound(AudioClip audioClip, bool loop=false, GameObject objMakeSound = null)
    {
        if (objMakeSound == null) {
            objMakeSound = audioManaObj;
        }
        
        //set new game object
        GameObject newAudio = new GameObject("newAudio");
        newAudio.transform.parent = objMakeSound.transform;
        //play audio
        newAudio.AddComponent<AudioSource>();
        AudioSource audioSource = newAudio.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.Play();
        //distroy audio object
        StartCoroutine(waitAndDestroyAudio(audioClip.length, newAudio));
    }

    IEnumerator waitAndDestroyAudio(float waitTime, GameObject newAudio)
    {
        yield return new WaitForSeconds(waitTime * 2.0f);
        Destroy(newAudio);
    }
    
    
}
