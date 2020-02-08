using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public List<Piece> usablePieces;

    private void Start()
    {
        //1x1
        Piece p0 = new Piece(0, new int[5, 5]{ 
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //2x1
        Piece p1 = new Piece(1, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 3 elbow
        Piece p2 = new Piece(2, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //3x1
        Piece p3 = new Piece(3, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //2x2
        Piece p4 = new Piece(4, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 4 t-joint
        Piece p5 = new Piece(5, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //4x1
        Piece p6 = new Piece(6, new int[5, 5]{
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol4 elbow
        Piece p7 = new Piece(7, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol4 z
        Piece p8 = new Piece(8, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol5 elbow asym
        Piece p9 = new Piece(9, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 0 }
        });

        //vol5 t joint
        Piece p10 = new Piece(10, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol5 elbow joint
        Piece p11 = new Piece(11, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 1 },
            { 0, 0, 0, 0, 0 }
        });

        //vol5 z joint asym
        Piece p12 = new Piece(12, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 1 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol5 s joint (2 turns instead of z's 1)
        Piece p13 = new Piece(13, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //5x1
        Piece p14 = new Piece(14, new int[5, 5]{
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        });

        //vol 5 "b"
        Piece p15 = new Piece(15, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 5 "w"
        Piece p16 = new Piece(16, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 5 "c"
        Piece p17 = new Piece(17, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 5 "tree"
        Piece p18 = new Piece(18, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 5 "plus"
        Piece p19 = new Piece(19, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        });

        //vol 5 "r"
        Piece p20 = new Piece(20, new int[5, 5]{
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        });

        usablePieces.Add(p0);
        usablePieces.Add(p1);
        usablePieces.Add(p2);
        usablePieces.Add(p3);
        usablePieces.Add(p4);
        usablePieces.Add(p5);
        usablePieces.Add(p6);
        usablePieces.Add(p7);
        usablePieces.Add(p8);
        usablePieces.Add(p9);
        usablePieces.Add(p10);
        usablePieces.Add(p11);
        usablePieces.Add(p12);
        usablePieces.Add(p13);
        usablePieces.Add(p14);
        usablePieces.Add(p15);
        usablePieces.Add(p16);
        usablePieces.Add(p17);
        usablePieces.Add(p18);
        usablePieces.Add(p19);
        usablePieces.Add(p20);

    }


}
