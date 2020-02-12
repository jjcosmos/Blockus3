using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        List<Color> colors = new List<Color>{ Color.red, Color.yellow, Color.green, Color.blue };
        Color c = colors[Random.Range(0,4)];

        var block = new MaterialPropertyBlock();
        block.SetColor("_albedo", c);
        block.SetColor("_glow", c);

        GetComponent<Renderer>().SetPropertyBlock(block);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
