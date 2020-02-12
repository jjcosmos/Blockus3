using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI Player1Text;
    [SerializeField] TextMeshProUGUI Player2Text;
    public static float MaxTime;
    public static float CurrentTimeLeft;
    public UnityEvent onTimeOut;
    private SimpleScrollCam cam;
    private AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip failedNoise;

    [SerializeField] TextMeshProUGUI Player1Continue;
    [SerializeField] TextMeshProUGUI Player2Continue;

    bool hasBegun;

    private void Awake()
    {
        onTimeOut = new UnityEvent();
        //clip = Resources.Load("Sfx/tick") as AudioClip;
        source = GetComponent<AudioSource>();
        Player1Continue.text = Player2Continue.text = "START";
        MaxTime = PlayerPrefs.GetFloat("Max Time");
    }

    void Start()
    {
        
        cam = Camera.main.GetComponent<SimpleScrollCam>();
        onTimeOut.AddListener(cam.GoNext);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBegun)
        {
            return;
        }

        CurrentTimeLeft -= Time.deltaTime;
        CurrentTimeLeft = Mathf.Clamp(CurrentTimeLeft, 0, Mathf.Infinity);


        if(CurrentTimeLeft%1 < .10f)
        {
            Player1Text.text = Player2Text.text = ((int)(CurrentTimeLeft)).ToString() + ":" + (int)((CurrentTimeLeft % 1) * 100) + "0";
        }
        else
            Player1Text.text = Player2Text.text = ((int)(CurrentTimeLeft)).ToString() + ":" + (int)((CurrentTimeLeft % 1) * 100);

        if(CurrentTimeLeft <= 0)
        {
            onTimeOut.Invoke();
        }
    }

    public IEnumerator PlayTickNoise()
    {
        //Debug.LogError("START");
        source.Play();
        //Debug.LogError("DONE");
        while (true)
        { 
            yield return new WaitForSeconds(1f);
            source.PlayOneShot(clip);
        }
    }


    public void BeginCountdown()
    {
        Player1Continue.text = Player2Continue.text = "NEXT";
        ResetTimer();
        hasBegun = true;
    }


    public void ResetTimer()
    {
        //source.PlayOneShot(failedNoise);
        StopAllCoroutines();
        CurrentTimeLeft = MaxTime;
        
        StartCoroutine(PlayTickNoise());
    }
}
