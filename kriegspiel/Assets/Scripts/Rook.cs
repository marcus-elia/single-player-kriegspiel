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
    public override List<BoardPosition> GetReachableMoveSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        // Up
        int i = this.boardPosition.i_;
        int j = this.boardPosition.j_ + 1;
        while(j < BoardManager.CHESSBOARD_SIZE)
        {
            if(currentBoard[i, j] == null)
            {
                spaces.Add(new BoardPosition(i, j));
            }
            else if(currentBoard[i, j].IsTeammate(this))
            {
                break;
            }
            else
            {
                spaces.Add(new BoardPosition(i, j));
                break;
            }
            j++;
        }
        // Down
        i = this.boardPosition.i_;
        j = this.boardPosition.j_ - 1;
        while (j >= 0)
        {
            if (currentBoard[i, j] == null)
            {
                spaces.Add(new BoardPosition(i, j));
            }
            else if (currentBoard[i, j].IsTeammate(this))
            {
                break;
            }
            else
            {
                spaces.Add(new BoardPosition(i, j));
                break;
            }
            j--;
        }
        // Left
        i = this.boardPosition.i_ + 1;
        j = this.boardPosition.j_;
        while (i < BoardManager.CHESSBOARD_SIZE)
        {
            if (currentBoard[i, j] == null)
            {
                spaces.Add(new BoardPosition(i, j));
            }
            else if (currentBoard[i, j].IsTeammate(this))
            {
                break;
            }
            else
            {
                spaces.Add(new BoardPosition(i, j));
                break;
            }
            i++;
        }
        // Right
        i = this.boardPosition.i_ - 1;
        j = this.boardPosition.j_;
        while (i >= 0)
        {
            if (currentBoard[i, j] == null)
            {
                spaces.Add(new BoardPosition(i, j));
            }
            else if (currentBoard[i, j].IsTeammate(this))
            {
                break;
            }
            else
            {
                spaces.Add(new BoardPosition(i, j));
                break;
            }
            i--;
        }

        return spaces;
    }
}
