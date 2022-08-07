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
    }
    public void SetBoardPosition(int i, int j)
    {
        boardPosition = new BoardPosition(i, j);
        transform.position = new Vector2(i, j);
    }
    public void SetTeam(Team newTeam)
    {
        team = newTeam;
    }

    public Team GetTeam()
    {
        return team;
    }
    public bool IsTeammate(Piece p)
    {
        return team == p.GetTeam();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract List<BoardPosition> GetReachableMoveSpaces(Piece[,] currentBoard);
}
