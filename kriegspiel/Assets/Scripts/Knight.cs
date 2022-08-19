using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
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
        pieceType = PieceType.Knight;
    }

    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        int i = boardPosition.i_;
        int j = boardPosition.j_;
        if(i > 1)
        {
            if(j > 0)
            {
                spaces.Add(new BoardPosition(i - 2, j - 1));
            }
            if(j < BoardManager.CHESSBOARD_SIZE - 1)
            {
                spaces.Add(new BoardPosition(i - 2, j + 1));
            }
        }
        if(i > 0)
        {
            if(j > 1)
            {
                spaces.Add(new BoardPosition(i - 1, j - 2));
            }
            if(j < BoardManager.CHESSBOARD_SIZE - 2)
            {
                spaces.Add(new BoardPosition(i - 1, j + 2));
            }
        }
        if (i < BoardManager.CHESSBOARD_SIZE - 2)
        {
            if (j > 0)
            {
                spaces.Add(new BoardPosition(i + 2, j - 1));
            }
            if (j < BoardManager.CHESSBOARD_SIZE - 1)
            {
                spaces.Add(new BoardPosition(i + 2, j + 1));
            }
        }
        if (i < BoardManager.CHESSBOARD_SIZE - 1)
        {
            if (j > 1)
            {
                spaces.Add(new BoardPosition(i + 1, j - 2));
            }
            if (j < BoardManager.CHESSBOARD_SIZE - 2)
            {
                spaces.Add(new BoardPosition(i + 1, j + 2));
            }
        }

        return spaces;
    }
}
