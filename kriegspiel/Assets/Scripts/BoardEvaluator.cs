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

    // Return the locations of opposing pieces that can reach the target space
    public static List<BoardPosition> GetAttackingLocations(Piece[,] board, Team attackingTeam, BoardPosition targetLoc)
    {
        List<BoardPosition> attackingFromLocations = new List<BoardPosition>();
        // Iterate over all opposing pieces to see if any of them can reach the king
        for (int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardManager.CHESSBOARD_SIZE; j++)
            {
                if (null != board[i, j] && board[i, j].GetTeam() == attackingTeam)
                {
                    List<BoardPosition> attackedSpaces = board[i, j].GetReachableMoveSpaces(board);
                    if (attackedSpaces.Contains(targetLoc))
                    {
                        attackingFromLocations.Add(new BoardPosition(i, j));
                    }
                }
            }
        }

        return attackingFromLocations;
    }

    // Return the locations of opposing pieces that can reach Team's king
    public static List<BoardPosition> GetCheckingLocations(Piece[,] board, Team team)
    {
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

        return GetAttackingLocations(board, Piece.GetOtherTeam(team), kingLocation);
    }

    public static bool IsInCheck(Piece[,] board, Team team)
    {
        return BoardEvaluator.GetCheckingLocations(board, team).Count > 0;
    }
}
