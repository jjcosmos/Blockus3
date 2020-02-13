using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject infoObject;
    bool showingInfo;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    public void ToggleInfo()
    {
        source.PlayOneShot(clip);
        if (showingInfo)
        {
            infoObject.SetActive(false);
        }
        else
        {
            infoObject.SetActive(true);
        }
        showingInfo = !showingInfo;
    }
}
