using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScrollCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 previousPosition;
    public Transform currentPiece;
    public int focusIndex;
    public float duration;

    private bool selfInitialized;

    float startTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selfInitialized && GameManager._instance.initialized)
        {
            currentPiece = GameManager._instance.newOrderedPieces[0];
            selfInitialized = true;
        }



        if (selfInitialized && Input.GetButtonDown("Fire1"))
        {
            focusIndex++;
            if (focusIndex < GameManager._instance.newOrderedPieces.Count)
            {
                startTime = Time.time;
                previousPosition = transform.position;
                currentPiece = GameManager._instance.newOrderedPieces[focusIndex];
                Debug.Log("Move next");
                
            }
            else
            {
                focusIndex--;
            }
        }
        if (previousPosition != null)
        {
            float t = (Time.time - startTime) / duration;
            //Debug.Log(t);
            transform.position = new Vector3(Mathf.SmoothStep(previousPosition.x, currentPiece.position.x, t), transform.position.y, transform.position.z);
            //transform.position = new Vector3(GameManager._instance.xSpacing * focusIndex, transform.position.y, transform.position.z);
            //Debug.Log(Mathf.SmoothStep(previousPiece.position.x, previousPiece.position.x, t));
        }
    }
}
