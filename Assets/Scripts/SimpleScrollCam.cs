using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScrollCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform currentPiece;
    public int focusIndex;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            focusIndex++;
            if (focusIndex < GameManager._instance.newOrderedPieces.Count)
            {
                currentPiece = GameManager._instance.newOrderedPieces[focusIndex];
                transform.position = new Vector3(GameManager._instance.xSpacing * focusIndex, transform.position.y, transform.position.z);
            }
            else
            {
                focusIndex--;
            }
        }
    }
}
