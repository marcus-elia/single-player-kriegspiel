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

public enum PieceType { King, Queen, Rook, Bishop, Knight, Pawn };

public abstract class Piece : MonoBehaviour
{
    protected BoardPosition boardPosition;
    protected Team team;
    protected PieceType pieceType;
    protected List<BoardPosition> legalMoveSpaces_;
    protected bool hasMoved_ = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // =======================================
    //        Initialize Variables
    // =======================================
    public void SetSprite(Sprite inputSprite)
    {
        gameObject.AddComponent<SpriteRenderer>();
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
    public PieceType GetPieceType()
    {
        return pieceType;
    }
    public bool GetHasMoved()
    {
        return hasMoved_;
    }
    public bool IsTeammate(Team t)
    {
        return team == t;
    }
    public bool IsTeammate(Piece p)
    {
        return this.IsTeammate(p.GetTeam());
    }
    public bool IsTargetKing(Team team)
    {
        return this.team == team && PieceType.King == this.pieceType;
    }

    // Move the Piece to the new position. But the move might be just testing out
    // legal locations, so specify realMove = true when it is actually a move.
    public void MoveToSpace(BoardPosition newPosition, bool realMove=false)
    {
        if(realMove)
        {
            this.hasMoved_ = true;
        }
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
    public List<BoardPosition> GetLegalMoveSpaces()
    {
        return legalMoveSpaces_;
    }
    public void SetLegalMoveSpaces(List<BoardPosition> legalMoveSpaces)
    {
        legalMoveSpaces_ = legalMoveSpaces;
    }

    public static string PieceTypeToString(PieceType pt)
    {
        switch(pt)
        {
            case PieceType.King:   return "King";
            case PieceType.Queen:  return "Queen";
            case PieceType.Rook:   return "Rook";
            case PieceType.Bishop: return "Bishop";
            case PieceType.Knight: return "Knight";
            case PieceType.Pawn:   return "Pawn";
        }
        return "Unknown";
    }

    public override string ToString()
    {
        string str = (team == Team.Player) ? "Player " : "Computer ";
        str += Piece.PieceTypeToString(pieceType) + " at ";
        str += boardPosition.i_ + ", " + boardPosition.j_;
        return str;
    }

    public static Team GetOtherTeam(Team team)
    {
        return team == Team.Player ? Team.Computer : Team.Player;
    }
}
