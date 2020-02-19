using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerCount;
    int currentXOffset;
    public int xSpacing = 6;
    public float blockOffset = 1f;
    public GameObject blockMesh;
    public List<Transform> newOrderedPieces;
    public List<Transform> newOrderedPieces2;
    public List<Transform> newOrderedPieces3;
    public List<Transform> newOrderedPieces4;
   

    public static GameManager _instance;
    public bool initialized;
    public static bool isSymmetric;


    [HideInInspector] public GameObject p1PieceParent;
    [HideInInspector] public GameObject p2PieceParent;
    [HideInInspector] public GameObject p3PieceParent;
    [HideInInspector] public GameObject p4PieceParent;

    public List<GameObject> playerParents;

    private void Awake()
    {
        isSymmetric = Convert.ToBoolean(PlayerPrefs.GetInt("isSymmetric"));
        _instance = this;

        newOrderedPieces = new List<Transform>();
        newOrderedPieces2 = new List<Transform>();
        newOrderedPieces3 = new List<Transform>();
        newOrderedPieces4 = new List<Transform>();


        p1PieceParent = new GameObject();
        p2PieceParent = new GameObject();
        p3PieceParent = new GameObject();
        p4PieceParent = new GameObject();

        p1PieceParent.name = "p1";
        p2PieceParent.name = "p2";
        p3PieceParent.name = "p3";
        p4PieceParent.name = "p4";

        playerParents.Add(p1PieceParent);
        playerParents.Add(p2PieceParent);
        playerParents.Add(p3PieceParent);
        playerParents.Add(p4PieceParent);

        Debug.Log(playerParents.Count + "fUC K");
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerCount"))
        {
            playerCount = PlayerPrefs.GetInt("PlayerCount");
            //Debug.Log("Setting");
        }
        else
        {
            playerCount = 2;
            //Debug.Log("Setting");
            PlayerPrefs.SetInt("PlayerCount", 2);
        }


        

        SpawnPieces();
    }

    private void SpawnPieces()
    {

        
        

        if (isSymmetric)
        {

            foreach (Piece item in Pieces._instance.piecesRemaining)
            {
                newOrderedPieces.Add(FabricatePiece(item, p1PieceParent.transform,0).transform);
                currentXOffset++;
            }
        }

        else if (playerCount == 2)
        {
            foreach (Piece item in Pieces._instance.piecesRemaining)
            {
                newOrderedPieces.Add(FabricatePiece(item, p1PieceParent.transform,1).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p2Pieces = Pieces.GetRandomizedList();

            Debug.Log(p2Pieces);

            foreach (Piece item in p2Pieces)
            {
                newOrderedPieces2.Add(FabricatePiece(item, p2PieceParent.transform,2).transform);
                currentXOffset++;
            }

        }
        else if (playerCount == 3)
        {
            foreach (Piece item in Pieces._instance.piecesRemaining)
            {
                newOrderedPieces.Add(FabricatePiece(item, p1PieceParent.transform,1).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p2Pieces = Pieces.GetRandomizedList();
            foreach (Piece item in p2Pieces)
            {
                newOrderedPieces2.Add(FabricatePiece(item, p2PieceParent.transform,2).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p3Pieces = Pieces.GetRandomizedList();
            foreach (Piece item in p3Pieces)
            {
                newOrderedPieces3.Add(FabricatePiece(item, p3PieceParent.transform,3).transform);
                currentXOffset++;
            }
        }
        else if (playerCount == 4)
        {
            foreach (Piece item in Pieces._instance.piecesRemaining)
            {
                newOrderedPieces.Add(FabricatePiece(item, p1PieceParent.transform,1).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p2Pieces = Pieces.GetRandomizedList();
            foreach (Piece item in p2Pieces)
            {
                newOrderedPieces2.Add(FabricatePiece(item, p2PieceParent.transform,2).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p3Pieces = Pieces.GetRandomizedList();
            foreach (Piece item in p3Pieces)
            {
                newOrderedPieces3.Add(FabricatePiece(item, p3PieceParent.transform,3).transform);
                currentXOffset++;
            }

            currentXOffset = 0;
            List<Piece> p4Pieces = Pieces.GetRandomizedList();
            foreach (Piece item in p4Pieces)
            {
                newOrderedPieces4.Add(FabricatePiece(item, p4PieceParent.transform,4).transform);
                currentXOffset++;
            }
        }
        

    }


    public void ToggleVisible(GameObject visible)
    {
        p1PieceParent.SetActive(false);
        p2PieceParent.SetActive(false);
        p3PieceParent.SetActive(false);
        p4PieceParent.SetActive(false);

        visible.SetActive(true);
    }

    private GameObject FabricatePiece(Piece p, Transform parent, int player)
    {
        List<Transform> validBlocks = new List<Transform>();
        GameObject o = new GameObject();
        o.transform.position = new Vector3(xSpacing * currentXOffset, 0, 0);
        o.transform.parent = parent;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (p.data[i, j] == 1) {
                    GameObject block = Instantiate(blockMesh, o.transform);
                    block.transform.localPosition = new Vector3(i * blockOffset, j * blockOffset, 0);
                    o.name = p.pieceID.ToString() + "Gen";
                    validBlocks.Add(block.transform);


                    List<Color> colors = new List<Color> { Color.red, Color.yellow, Color.green, Color.blue };
                    Color c;

                    

                    //p.gameObject.AddComponent<Renderer>();
                    //p.gameObject.GetComponent<Renderer>().SetPropertyBlock(pblock);
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
