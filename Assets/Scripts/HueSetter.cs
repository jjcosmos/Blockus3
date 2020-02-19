using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        List<Color> colors = new List<Color>{ Color.red, Color.blue, Color.green, Color.yellow };
        Color c = colors[1];
        if (GameManager.isSymmetric)
        {
            c = colors[Random.Range(0, 4)];
        }
        else
        {
            switch (transform.parent.parent.name)
            {
                case "p1":
                    c = colors[0];
                    break;
                case "p2":
                    c = colors[1];
                    break;
                case "p3":
                    c = colors[2];
                    break;
                case "p4":
                    c = colors[3];
                    break;
                default:
                    break;
            }
        }
        Debug.Log(transform.parent.parent.name);

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
