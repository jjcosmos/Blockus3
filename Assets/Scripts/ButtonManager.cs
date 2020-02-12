using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform settingsWindow;
    private AudioSource audioSource;
    private AudioClip clip;

    private bool showingSettings;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load("Sfx/Click_sound") as AudioClip;
        settingsWindow.gameObject.SetActive(false);
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

    public void ShowSettings()
    {
        audioSource.PlayOneShot(clip);
        if (showingSettings)
        {
            settingsWindow.gameObject.SetActive(false);
        }
        else
        {
            settingsWindow.gameObject.SetActive(true);
        }
        showingSettings = !showingSettings;
    }
}
