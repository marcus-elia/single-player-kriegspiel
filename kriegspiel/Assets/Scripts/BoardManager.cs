using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public const int CHESSBOARD_SIZE = 8;

    public MouseManager mouseManager;

    // This array only stores the spaces for drawing the board itself. Doesn't store game data.
    private GameObject[,] spaces = new GameObject[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
    public Texture2D blackSquareTex;
    public Texture2D whiteSquareTex;

    public Sprite whiteRookSprite;
    public Sprite blackRookSprite;
    public Sprite whiteKingSprite;
    public Sprite blackKingSprite;
    public Sprite whiteQueenSprite;
    public Sprite blackQueenSprite;
    public Sprite whiteKnightSprite;
    public Sprite blackKnightSprite;
    public Sprite whiteBishopSprite;
    public Sprite blackBishopSprite;
    public Sprite whitePawnSprite;
    public Sprite blackPawnSprite;

    private List<GameObject> playerPieces = new List<GameObject>();
    private Piece[,] masterBoard = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];

    // Start is called before the first frame update
    void Start()
    {
        // Put the black and white spaces on the board
        for(int i = 0; i < CHESSBOARD_SIZE; i++)
        {
            for(int j = 0; j < CHESSBOARD_SIZE; j++)
            {
                spaces[i, j] = new GameObject();
                spaces[i, j].AddComponent<BoardSpace>();
                spaces[i, j].transform.position = new Vector2(i + 0.5f, j + 0.5f);
                spaces[i, j].GetComponent<BoardSpace>().SetTexture((i + j) % 2 == 0 ? blackSquareTex : whiteSquareTex);
            }
        }

        // Set up the pieces
        GameObject whiteRook1 = new GameObject();
        whiteRook1.AddComponent<Rook>();
        whiteRook1.GetComponent<Rook>().SetSprite(whiteRookSprite);
        whiteRook1.GetComponent<Rook>().SetBoardPosition(0, 0);
        masterBoard[0, 0] = whiteRook1.GetComponent<Rook>();
        playerPieces.Add(whiteRook1);

        // Initialize other components
        mouseManager.SetBoardManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // =============================================
    //               Get Board Info
    // =============================================
    public bool IsPlayerPieceThere(BoardPosition bp)
    {
        return masterBoard[bp.i_, bp.j_] != null && masterBoard[bp.i_, bp.j_].GetTeam() == Team.Player;
    }
    public bool IsComputerPieceThere(BoardPosition bp)
    {
        return masterBoard[bp.i_, bp.j_] != null && masterBoard[bp.i_, bp.j_].GetTeam() == Team.Computer;
    }
}
