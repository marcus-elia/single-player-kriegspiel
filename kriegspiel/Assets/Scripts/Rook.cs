using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        // Up
        int i = this.boardPosition.i_;
        int j = this.boardPosition.j_ + 1;
        while(j < BoardManager.CHESSBOARD_SIZE)
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

        return spaces;
    }
 }
