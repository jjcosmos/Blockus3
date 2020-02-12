using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider s;
    private TMPro.TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = $"Time per turn: {s.value} seconds";
    }
}
