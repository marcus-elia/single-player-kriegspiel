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
        List<Piece> movablePieces = new List<Piece>();
        for (int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardManager.CHESSBOARD_SIZE; j++)
            {
                if (null != board[i, j] && board[i, j].GetTeam() == Team.Computer)
                {
                    if (board[i, j].GetLegalMoveSpaces().Count > 0)
                    {
                        movablePieces.Add(board[i, j]);
                    }
                }
            }
        }

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
