using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip clip;
    bool isSymmetric;
    void Start()
    {
        PlayerPrefs.SetInt("isSymmetric", 0);
    }

    public void ToggleSymmetric()
    {
        source.PlayOneShot(clip);
        isSymmetric = !isSymmetric;
        int testInt = isSymmetric ? 1 : 0;
        PlayerPrefs.SetInt("isSymmetric",testInt);
    }
}
