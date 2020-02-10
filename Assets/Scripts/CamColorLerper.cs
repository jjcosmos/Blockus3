using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColorLerper : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    [SerializeField] Gradient g;
    [SerializeField] float speed;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //cam.backgroundColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.deltaTime, 1));
        //Debug.Log(Mathf.PingPong(Time.time * speed, 1));
        cam.backgroundColor = g.Evaluate(Mathf.PingPong(Time.time * speed, 1));
    }
}
