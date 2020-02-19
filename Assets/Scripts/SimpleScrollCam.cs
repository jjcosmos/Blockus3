using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class SimpleScrollCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 previousPosition;
    public Transform currentPiece;
    public int focusIndex;
    public int playerIndex;
    
    public float duration;

    private AudioSource source;
    private AudioClip clip;
    private bool selfInitialized;
    [SerializeField] TextMeshProUGUI player1button;
    [SerializeField] TextMeshProUGUI player2button;

    float startTime;
    public UnityEvent OnCameraMove;
    public UnityEvent OnBegin;

    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem particles;
    private bool started;
    bool ending;
    

    void Start()
    {
        playerIndex = 1;
        OnBegin = new UnityEvent();
        OnCameraMove = new UnityEvent();
        source = GetComponent<AudioSource>();
        clip = Resources.Load("Sfx/pop") as AudioClip;

        if (GameObject.FindObjectOfType<Timer>())
        {
            OnCameraMove.AddListener(GameObject.FindObjectOfType<Timer>().ResetTimer);
            OnBegin.AddListener(GameObject.FindObjectOfType<Timer>().BeginCountdown);
        }
        Debug.Log(GameManager._instance.playerParents.Count);
        GameManager._instance.ToggleVisible(GameManager._instance.playerParents[playerIndex-1]);

    }

    public void GoNext()
    {
        

        if(selfInitialized && !started && SceneManager.GetActiveScene().buildIndex == 2 && focusIndex < GameManager._instance.newOrderedPieces.Count)
        {
            OnBegin.Invoke();
            started = true;
            
        }
        

        else if (selfInitialized && !ending )
        {
            if (IncrementPlayerIndex()) { //checks if looping back to player 1
                focusIndex++;
            }

            if (!GameManager.isSymmetric)
            {
                GameManager._instance.ToggleVisible(GameManager._instance.playerParents[playerIndex - 1]);
            }
            
            source.PlayOneShot(clip);
            
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
                else
                    OnCameraMove.Invoke();
            }
            else
            {
                focusIndex--;
                anim.Play("UI SlideIn");
                particles.Play();
                //delay
                StartCoroutine(LoadDelay());
                ending = true;
            }
            //
        }
    }

    private bool IncrementPlayerIndex()
    {
        if(playerIndex < GameManager.playerCount && !GameManager.isSymmetric)
        {
            playerIndex++;
            return false;
        }
        else
        {
            playerIndex = 1;
            return true;
        }
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
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
