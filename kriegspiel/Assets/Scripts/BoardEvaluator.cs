using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEvaluator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Return the locations of opposing pieces that can reach the king
    public static List<BoardPosition> GetCheckingLocations(Piece[,] board, Team team)
    {
        List<BoardPosition> checkingLocations = new List<BoardPosition>();

        // Iterate through to find the king
        BoardPosition kingLocation = new BoardPosition(-1, -1);
        bool kingFound = false;
        for(int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for(int j = 0; j < BoardManager.CHESSBOARD_SIZE; j++)
            {
                if(null != board[i, j] && board[i, j].IsTargetKing(team))
                {
                    kingLocation = new BoardPosition(i, j);
                    kingFound = true;
                    break;
                }
            }
        }
        if (!kingFound)
        {
            Debug.LogError("There is no king.");
        }

        // Iterate over all opposing pieces to see if any of them can reach the king
        for (int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardManager.CHESSBOARD_SIZE; j++)
            {
                if (null != board[i, j] && !board[i, j].IsTeammate(team))
                {
                    List<BoardPosition> attackedSpaces = board[i, j].GetReachableMoveSpaces(board);
                    if (attackedSpaces.Contains(kingLocation))
                    {
                        checkingLocations.Add(new BoardPosition(i, j));
                    }
                }
            }
        }

        return checkingLocations;
    }
}
