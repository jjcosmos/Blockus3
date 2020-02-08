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
    void Start()
    {
        SpawnPieces();
    }

    private void SpawnPieces()
    {
        foreach (Piece item in Pieces._instance.usablePieces)
        {
            FabricatePiece(item);
            currentXOffset++;
        }
    }

    private void FabricatePiece(Piece p)
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

        if(validBlocks == null)
        {
            return;
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

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
