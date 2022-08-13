using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        pieceType = PieceType.King;
    }

    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        int i = boardPosition.i_;
        int j = boardPosition.j_;
        // Check left, down left, and up left
        if (i > 0)
        {
            spaces.Add(new BoardPosition(i - 1, j));
            if (j > 0)
            {
                spaces.Add(new BoardPosition(i - 1, j - 1));
            }
            if (j < BoardManager.CHESSBOARD_SIZE - 1)
            {
                spaces.Add(new BoardPosition(i - 1, j + 1));
            }
        }
        // Check right, down right, and up right
        if (i < BoardManager.CHESSBOARD_SIZE - 1)
        {
            spaces.Add(new BoardPosition(i + 1, j));
            if (j > 0)
            {
                spaces.Add(new BoardPosition(i + 1, j - 1));
            }
            if (j < BoardManager.CHESSBOARD_SIZE - 1)
            {
                spaces.Add(new BoardPosition(i + 1, j + 1));
            }
        }
        // Down
        if (j > 0)
        {
            spaces.Add(new BoardPosition(i, j - 1));
        }
        // Up
        if (j < BoardManager.CHESSBOARD_SIZE - 1)
        {
            spaces.Add(new BoardPosition(i, j + 1));
        }

        return spaces;
    }
}
