using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    int currentXOffset;
    public int xSpacing = 6;
    public float blockOffset = 1f;
    public GameObject blockMesh;
    public List<Transform> newOrderedPieces;

    public static GameManager _instance;
    public bool initialized;

    private void Awake()
    {
        _instance = this;
        
    }

    void Start()
    {
        SpawnPieces();
    }

    private void SpawnPieces()
    {
        newOrderedPieces = new List<Transform>();
        foreach (Piece item in Pieces._instance.piecesRemaining)
        {
            newOrderedPieces.Add(FabricatePiece(item).transform);
            currentXOffset++;
        }
    }

    private GameObject FabricatePiece(Piece p)
    {
        List<Transform> validBlocks = new List<Transform>();
        GameObject o = new GameObject();
        o.transform.position = new Vector3(xSpacing * currentXOffset, 0, 0);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (p.data[i, j] == 1) {
                    GameObject block = Instantiate(blockMesh, o.transform);
                    block.transform.localPosition = new Vector3(i * blockOffset, j * blockOffset, 0);
                    o.name = p.pieceID.ToString() + "Gen";
                    validBlocks.Add(block.transform);
                }
            }
        }



        //add animator
        Animator anim =  o.AddComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Animation/Capsule") as RuntimeAnimatorController;



        if(validBlocks == null)
        {
            initialized = true;
            return o;
        }

        //find the center
        Vector3 sum = validBlocks[0].localPosition;
        Vector3 center;

        for (int i = 1; i < validBlocks.Count; i++)
        {
            sum += validBlocks[i].localPosition;
        }

        center = sum / (validBlocks.Count);

        //find the offset from the center and offset that from local 0,0
        foreach (Transform b in validBlocks)
        {
            Vector3 offsetFromCenter = b.localPosition - center;
            b.localPosition = offsetFromCenter;
        }
        initialized = true;
        return o;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
