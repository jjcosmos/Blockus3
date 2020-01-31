using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Piece : MonoBehaviour
{
    public int pieceID;

    private MeshRenderer rend;   
    public void OnActivatePiece()
    {
        rend.enabled = true;
        //GetComponent<Animator>().SetBool("Active", true);
    }
}
