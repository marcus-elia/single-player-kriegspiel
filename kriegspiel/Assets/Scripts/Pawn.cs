using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
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
        pieceType = PieceType.Pawn;
    }

    public override List<BoardPosition> GetSightSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> spaces = new List<BoardPosition>();
        int i = boardPosition.i_;
        int j = boardPosition.j_;
        // Player pawns move up
        if (Team.Player == this.team)
        {
            if (j == BoardManager.CHESSBOARD_SIZE - 1)
            {
                Debug.LogError("This pawn has promoted. Why is it still here?");
            }
            if (null == currentBoard[i, j + 1])
            {
                spaces.Add(new BoardPosition(i, j + 1));
                if (j == 1 && null == currentBoard[i, j + 2])
                {
                    spaces.Add(new BoardPosition(i, j + 2));
                }
            }
            if (i > 0 && null != currentBoard[i - 1, j + 1] && !this.IsTeammate(currentBoard[i - 1, j + 1]))
            {
                spaces.Add(new BoardPosition(i - 1, j + 1));
            }
            if (i < BoardManager.CHESSBOARD_SIZE - 1 && null != currentBoard[i + 1, j + 1] && !this.IsTeammate(currentBoard[i + 1, j + 1]))
            {
                spaces.Add(new BoardPosition(i + 1, j + 1));
            }
        }
        // Computer pawns move down
        else
        {
            if (0 == j)
            {
                Debug.LogError("This pawn has promoted. Why is it still here?");
            }
            if (null == currentBoard[i, j - 1])
            {
                spaces.Add(new BoardPosition(i, j - 1));
                if (j == BoardManager.CHESSBOARD_SIZE - 2 && null == currentBoard[i, j - 2])
                {
                    spaces.Add(new BoardPosition(i, j - 2));
                }
            }
            if (i > 0 && null != currentBoard[i - 1, j - 1] && !this.IsTeammate(currentBoard[i - 1, j - 1]))
            {
                spaces.Add(new BoardPosition(i - 1, j - 1));
            }
            if (i < BoardManager.CHESSBOARD_SIZE - 1 && null != currentBoard[i + 1, j - 1] && !this.IsTeammate(currentBoard[i + 1, j - 1]))
            {
                spaces.Add(new BoardPosition(i + 1, j - 1));
            }
        }

        return spaces;
    }
}
