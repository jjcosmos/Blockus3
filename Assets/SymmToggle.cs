using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmToggle : MonoBehaviour
{
    // Start is called before the first frame update
    bool isSymmetric;
    void Start()
    {
        PlayerPrefs.SetInt("isSymmetric", 0);
    }

    public void ToggleSymmetric()
    {
        isSymmetric = !isSymmetric;
        int testInt = isSymmetric ? 1 : 0;
        PlayerPrefs.SetInt("isSymmetric",testInt);
    }
}
