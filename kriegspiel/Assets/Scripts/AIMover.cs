using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveInfo
{
    public BoardPosition moveFromLocation;
    public BoardPosition moveToLocation;
    public Piece movingPiece;
    public Piece capturedPiece;

    public MoveInfo(BoardPosition fromLoc, BoardPosition toLoc, Piece p)
    {
        moveFromLocation = fromLoc;
        moveToLocation = toLoc;
        movingPiece = p;
        capturedPiece = null;
    }
    public MoveInfo(BoardPosition fromLoc, BoardPosition toLoc, Piece p, Piece c)
    {
        moveFromLocation = fromLoc;
        moveToLocation = toLoc;
        movingPiece = p;
        capturedPiece = c;
    }
}
public class AIMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static MoveInfo ChooseComputerMove(Piece[,] board)
    {
        List<Piece> movablePieces = BoardEvaluator.GetMovablePieces(board, Team.Computer);

        // Choose random piece that can move, and a random space for that piece
        int randomPieceIndex = Random.Range(0, movablePieces.Count);
        Piece p = movablePieces[randomPieceIndex];
        int randomSpaceIndex = Random.Range(0, p.GetLegalMoveSpaces().Count);
        BoardPosition moveTo = p.GetLegalMoveSpaces()[randomSpaceIndex];

        // Is is a capture?
        Piece captured = board[moveTo.i_, moveTo.j_];

        return new MoveInfo(p.GetBoardPosition(), moveTo, p, captured);
    }
}
