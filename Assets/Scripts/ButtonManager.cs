using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private AudioClip clip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load("Sfx/Click_sound") as AudioClip;
    }


    public void LoadAScene(int scene)
    {
        StartCoroutine(DelayedLoad(scene));
        audioSource.PlayOneShot(clip);
        
    }

    private IEnumerator DelayedLoad(int scene)
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(scene);
    }
}
