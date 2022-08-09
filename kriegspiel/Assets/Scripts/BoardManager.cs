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

    private List<GameObject> playerPieces_ = new List<GameObject>();
    private Piece[,] masterBoard_ = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
    private Piece selectedPiece_ = null;

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
        for(int i = 0; i < 8; i += 7)
        {
            for(int j = 0; j < 8; j += 7)
            {
                GameObject newRook = new GameObject();
                newRook.AddComponent<Rook>();
                newRook.GetComponent<Rook>().SetSprite(j == 0 ? whiteRookSprite : blackRookSprite);
                newRook.GetComponent<Rook>().SetTeam(j == 0 ? Team.Player : Team.Computer);
                newRook.GetComponent<Rook>().SetBoardPosition(i, j);
                masterBoard_[i, j] = newRook.GetComponent<Rook>();
                if(j == 0)
                {
                    playerPieces_.Add(newRook);
                }
            }
        }
        

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
        return masterBoard_[bp.i_, bp.j_] != null && masterBoard_[bp.i_, bp.j_].GetTeam() == Team.Player;
    }
    public bool IsComputerPieceThere(BoardPosition bp)
    {
        return masterBoard_[bp.i_, bp.j_] != null && masterBoard_[bp.i_, bp.j_].GetTeam() == Team.Computer;
    }

    // ===========================================
    //         Piece Moving Logic
    // ===========================================
    public void TryMove(BoardPosition selectedSpace)
    {
        if(null == selectedPiece_)
        {
            Debug.LogError("Can't try to move when no piece is selected.");
        }
        List<BoardPosition> reachableMoveSpaces = selectedPiece_.GetReachableMoveSpaces(masterBoard_);
        if(reachableMoveSpaces.Contains(selectedSpace))
        {
            BoardPosition previousLocation = selectedPiece_.GetBoardPosition();
            masterBoard_[previousLocation.i_, previousLocation.j_] = null;
            selectedPiece_.MoveToSpace(selectedSpace);
            masterBoard_[selectedSpace.i_, selectedSpace.j_] = selectedPiece_;            
        }
        else
        {
            Debug.Log("That is not a legal move.");
        }
        selectedPiece_ = null;
    }
    public void SetSelectedPiece(BoardPosition selectedSpace)
    {
        Piece p = masterBoard_[selectedSpace.i_, selectedSpace.j_];
        if(null == p)
        {
            Debug.LogError("A null piece was selected at " + selectedSpace.i_ + ", " + selectedSpace.j_);
        }
        if(null != selectedPiece_)
        {
            Debug.LogError("Trying to set selected piece when there already is a selected piece.");
        }
        selectedPiece_ = p;
    }
}
