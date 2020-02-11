using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SimpleScrollCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 previousPosition;
    public Transform currentPiece;
    public int focusIndex;
    public float duration;

    private bool selfInitialized;
    [SerializeField] TextMeshProUGUI player1button;
    [SerializeField] TextMeshProUGUI player2button;

    float startTime;
    void Start()
    {
        
    }

    public void GoNext()
    {
        if (selfInitialized)
        {
            focusIndex++;
            if (focusIndex < GameManager._instance.newOrderedPieces.Count)
            {
                startTime = Time.time;
                previousPosition = transform.position;
                currentPiece = GameManager._instance.newOrderedPieces[focusIndex];
                Debug.Log("Move next");

                if(focusIndex == GameManager._instance.newOrderedPieces.Count - 1)
                {
                    player1button.text = "Finish";
                    player2button.text = "Finish";
                }

            }
            else
            {
                focusIndex--;
                SceneManager.LoadScene(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!selfInitialized && GameManager._instance.initialized)
        {
            currentPiece = GameManager._instance.newOrderedPieces[0];
            selfInitialized = true;
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
