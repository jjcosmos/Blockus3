using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCountSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI CountDisplayText;
    private void Start()
    {
        PlayerPrefs.SetInt("PlayerCount", 2);
        int count = PlayerPrefs.GetInt("PlayerCount");
        CountDisplayText.text = "Current Mode: " + count + "P";
    }

    public void SetPlayerCount(int count)
    {
        PlayerPrefs.SetInt("PlayerCount", count);
        CountDisplayText.text = "Current Mode: " + count + "P";
    }
}
