using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCountSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI CountDisplayText;
    
    public void SetPlayerCount(int count)
    {
        PlayerPrefs.SetInt("PlayerCount", count);
        CountDisplayText.text = "Current Mode: " + count + "P";
    }
}
