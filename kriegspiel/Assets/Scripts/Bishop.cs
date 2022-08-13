using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
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
        pieceType = PieceType.Bishop;
    }

    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        // Up right
        int i = this.boardPosition.i_ + 1;
        int j = this.boardPosition.j_ + 1;
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
