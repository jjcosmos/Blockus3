using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControlsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    Slider s;
    void Start()
    {
        s = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("Max Time"))
        {
            s.value = PlayerPrefs.GetFloat("Max Time");
        }

        PlayerPrefs.SetFloat("Max Time", s.value);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePrefs()
    {
        PlayerPrefs.SetFloat("Max Time", s.value);
    } 
}
