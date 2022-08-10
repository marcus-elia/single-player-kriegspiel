using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BoardPosition
{
    public int i_, j_;

    public BoardPosition(int i, int j)
    {
        i_ = i;
        j_ = j;
    }

    public bool Equals(BoardPosition other)
    {
        return i_ == other.i_ && j_ == other.j_;
    }
}

public enum Team { Player, Computer };

public abstract class Piece : MonoBehaviour
{
    protected BoardPosition boardPosition;
    private SpriteRenderer spriteRenderer;
    protected Team team;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // =======================================
    //        Initialize Variables
    // =======================================
    public void SetSprite(Sprite inputSprite)
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = inputSprite;
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void SetBoardPosition(int i, int j)
    {
        boardPosition = new BoardPosition(i, j);
        transform.position = new Vector2(i + 0.5f, j + 0.5f);
    }
    public void SetTeam(Team newTeam)
    {
        team = newTeam;
    }

    // =========================================
    //        Basic Getters and Stuff
    // =========================================
    public Team GetTeam()
    {
        return team;
    }
    public BoardPosition GetBoardPosition()
    {
        return boardPosition;
    }
    public bool IsTeammate(Piece p)
    {
        return team == p.GetTeam();
    }

    public void MoveToSpace(BoardPosition newPosition)
    {
        this.SetBoardPosition(newPosition.i_, newPosition.j_);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // The set of spaces the Piece could move to or is protecting (including spaces with teammates)
    public abstract List<BoardPosition> GetSightSpaces(Piece[,] currentBoard);
    // The set of spaces the Piece could actually move to
    public List<BoardPosition> GetReachableMoveSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> sightSpaces = this.GetSightSpaces(currentBoard);
        List<BoardPosition> reachableSpaces = new List<BoardPosition>();
        foreach (BoardPosition bp in sightSpaces)
        {
            if (null == currentBoard[bp.i_, bp.j_] || !this.IsTeammate(currentBoard[bp.i_, bp.j_]))
            {
                reachableSpaces.Add(bp);
            }
        }

        return reachableSpaces;
    }

    // Only the spaces the Piece can legally move to.
    public List<BoardPosition> GetLegalMoveSpaces(Piece[,] currentBoard)
    {
        List<BoardPosition> reachableSpaces = this.GetReachableMoveSpaces(currentBoard);
        List<BoardPosition> legalSpaces = new List<BoardPosition>();
        foreach (BoardPosition bp in reachableSpaces)
        {
            if (true)
            {
                legalSpaces.Add(bp);
            }
        }

        return legalSpaces;
    }
}
