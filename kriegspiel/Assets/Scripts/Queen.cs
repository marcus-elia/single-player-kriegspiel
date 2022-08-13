using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
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
        pieceType = PieceType.Queen;
    }

    // I pasted from both Rook and Bishop here. Would be nice to avoid this duplicated code.
    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        // Up
        int i = this.boardPosition.i_;
        int j = this.boardPosition.j_ + 1;
        while (j < BoardManager.CHESSBOARD_SIZE)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            j++;
        }
        // Down
        i = this.boardPosition.i_;
        j = this.boardPosition.j_ - 1;
        while (j >= 0)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            j--;
        }
        // Left
        i = this.boardPosition.i_ + 1;
        j = this.boardPosition.j_;
        while (i < BoardManager.CHESSBOARD_SIZE)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i++;
        }
        // Right
        i = this.boardPosition.i_ - 1;
        j = this.boardPosition.j_;
        while (i >= 0)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i--;
        }
        // Up right
        i = this.boardPosition.i_ + 1;
        j = this.boardPosition.j_ + 1;
        while (i < BoardManager.CHESSBOARD_SIZE && j < BoardManager.CHESSBOARD_SIZE)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i++;
            j++;
        }
        // Down right
        i = this.boardPosition.i_ + 1;
        j = this.boardPosition.j_ - 1;
        while (i < BoardManager.CHESSBOARD_SIZE && j >= 0)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i++;
            j--;
        }
        // Down left
        i = this.boardPosition.i_ - 1;
        j = this.boardPosition.j_ - 1;
        while (i >= 0 && j >= 0)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i--;
            j--;
        }
        // Up left
        i = this.boardPosition.i_ - 1;
        j = this.boardPosition.j_ + 1;
        while (i >= 0 && j < BoardManager.CHESSBOARD_SIZE)
        {
            spaces.Add(new BoardPosition(i, j));
            if (null != currentBoard[i, j])
            {
                break;
            }
            i--;
            j++;
        }

        return spaces;
    }
}
