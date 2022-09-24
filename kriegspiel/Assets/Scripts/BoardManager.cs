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
    private List<GameObject> computerPieces_ = new List<GameObject>();
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
        // Rooks
        for(int i = 0; i < 8; i += 7)
        {
            for (int j = 0; j < 8; j += 7)
            {
                GameObject newRook = new GameObject();
                newRook.AddComponent<Rook>();
                newRook.GetComponent<Rook>().SetSprite(j == 0 ? whiteRookSprite : blackRookSprite);
                newRook.GetComponent<Rook>().SetTeam(j == 0 ? Team.Player : Team.Computer);
                newRook.GetComponent<Rook>().SetBoardPosition(i, j);
                newRook.GetComponent<Rook>().Initialize();
                masterBoard_[i, j] = newRook.GetComponent<Rook>();
                if (j == 0)
                {
                    playerPieces_.Add(newRook);
                }
                else
                {
                    computerPieces_.Add(newRook);
                }
            }
        }
        // Bishops
        for (int i = 2; i < 6; i += 3)
        {
            for (int j = 0; j < 8; j += 7)
            {
                GameObject newBishop = new GameObject();
                newBishop.AddComponent<Bishop>();
                newBishop.GetComponent<Bishop>().SetSprite(j == 0 ? whiteBishopSprite : blackBishopSprite);
                newBishop.GetComponent<Bishop>().SetTeam(j == 0 ? Team.Player : Team.Computer);
                newBishop.GetComponent<Bishop>().SetBoardPosition(i, j);
                newBishop.GetComponent<Bishop>().Initialize();
                masterBoard_[i, j] = newBishop.GetComponent<Bishop>();
                if (j == 0)
                {
                    playerPieces_.Add(newBishop);
                }
                else
                {
                    computerPieces_.Add(newBishop);
                }
            }
        }
        // Kings
        for (int j = 0; j < 8; j += 7)
        {
            GameObject newKing = new GameObject();
            newKing.AddComponent<King>();
            newKing.GetComponent<King>().SetSprite(j == 0 ? whiteKingSprite : blackKingSprite);
            newKing.GetComponent<King>().SetTeam(j == 0 ? Team.Player : Team.Computer);
            newKing.GetComponent<King>().SetBoardPosition(4, j);
            newKing.GetComponent<King>().Initialize();
            masterBoard_[4, j] = newKing.GetComponent<King>();
            if (j == 0)
            {
                playerPieces_.Add(newKing);
            }
            else
            {
                computerPieces_.Add(newKing);
            }
        }
        // Queens
        for (int j = 0; j < 8; j += 7)
        {
            GameObject newQueen = new GameObject();
            newQueen.AddComponent<Queen>();
            newQueen.GetComponent<Queen>().SetSprite(j == 0 ? whiteQueenSprite : blackQueenSprite);
            newQueen.GetComponent<Queen>().SetTeam(j == 0 ? Team.Player : Team.Computer);
            newQueen.GetComponent<Queen>().SetBoardPosition(3, j);
            newQueen.GetComponent<Queen>().Initialize();
            masterBoard_[3, j] = newQueen.GetComponent<Queen>();
            if (j == 0)
            {
                playerPieces_.Add(newQueen);
            }
            else
            {
                computerPieces_.Add(newQueen);
            }
        }
        // Knights
        for (int i = 1; i < 7; i += 5)
        {
            for (int j = 0; j < 8; j += 7)
            {
                GameObject newKnight = new GameObject();
                newKnight.AddComponent<Knight>();
                newKnight.GetComponent<Knight>().SetSprite(j == 0 ? whiteKnightSprite : blackKnightSprite);
                newKnight.GetComponent<Knight>().SetTeam(j == 0 ? Team.Player : Team.Computer);
                newKnight.GetComponent<Knight>().SetBoardPosition(i, j);
                newKnight.GetComponent<Knight>().Initialize();
                masterBoard_[i, j] = newKnight.GetComponent<Knight>();
                if (j == 0)
                {
                    playerPieces_.Add(newKnight);
                }
                else
                {
                    computerPieces_.Add(newKnight);
                }
            }
        }
        // Pawns
        for (int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for (int j = 1; j < 7; j += 5)
            {
                GameObject newPawn = new GameObject();
                newPawn.AddComponent<Pawn>();
                newPawn.GetComponent<Pawn>().SetSprite(j == 1 ? whitePawnSprite : blackPawnSprite);
                newPawn.GetComponent<Pawn>().SetTeam(j == 1 ? Team.Player : Team.Computer);
                newPawn.GetComponent<Pawn>().SetBoardPosition(i, j);
                newPawn.GetComponent<Pawn>().Initialize();
                masterBoard_[i, j] = newPawn.GetComponent<Pawn>();
                if (j == 1)
                {
                    playerPieces_.Add(newPawn);
                }
                else
                {
                    computerPieces_.Add(newPawn);
                }
            }
        }

        // Initialize other components
        mouseManager.SetBoardManager(this);

        // Have all pieces calculate legal moves to start
        this.ResetLegalMoveSpaces();
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
        List<BoardPosition> legalMoveSpaces = selectedPiece_.GetLegalMoveSpaces();
        // Check if the piece can move there normally
        if(legalMoveSpaces.Contains(selectedSpace))
        {
            if (null != masterBoard_[selectedSpace.i_, selectedSpace.j_])
            {
                if(masterBoard_[selectedSpace.i_, selectedSpace.j_].GetTeam() == selectedPiece_.GetTeam())
                {
                    Debug.LogError("Trying to capture a teammate. Big problem.");
                }
                masterBoard_[selectedSpace.i_, selectedSpace.j_].gameObject.SetActive(false);
                Debug.Log("player just captured a piece");
            }
            BoardPosition previousLocation = selectedPiece_.GetBoardPosition();
            masterBoard_[previousLocation.i_, previousLocation.j_] = null;
            selectedPiece_.MoveToSpace(selectedSpace, true);
            masterBoard_[selectedSpace.i_, selectedSpace.j_] = selectedPiece_;
            this.ResetLegalMoveSpaces();

            // Now have the computer move
            this.PerformComputerMove();
            Debug.Log("computer moved");
        }
        // Then check if it's castling
        else if(PieceType.King == selectedPiece_.GetPieceType() && !selectedPiece_.GetHasMoved())
        {
            // Kingside
            if(6 == selectedSpace.i_ && 0 == selectedSpace.j_)
            {
                bool clearPath = (masterBoard_[5, 0] == null && masterBoard_[6, 0] == null);
                bool rookPresent = (masterBoard_[7, 0] != null && !masterBoard_[7, 0].GetHasMoved());
                bool notInCheck = !BoardEvaluator.IsInCheck(masterBoard_, Team.Player);
                bool notThroughCheck = BoardEvaluator.GetAttackingLocations(masterBoard_, Team.Computer, new BoardPosition(5, 0)).Count == 0 &&
                                       BoardEvaluator.GetAttackingLocations(masterBoard_, Team.Computer, new BoardPosition(6, 0)).Count == 0;
                
                // Do the kingside castling
                if (clearPath && rookPresent && notInCheck && notThroughCheck)
                {
                    // Move the king
                    masterBoard_[6, 0] = masterBoard_[4, 0];
                    masterBoard_[6, 0].MoveToSpace(new BoardPosition(6, 0), true);
                    // Move the rook
                    masterBoard_[5, 0] = masterBoard_[7, 0];
                    masterBoard_[5, 0].MoveToSpace(new BoardPosition(5, 0), true);
                    // Clear both spaces
                    masterBoard_[4, 0] = null;
                    masterBoard_[7, 0] = null;
                    this.ResetLegalMoveSpaces();

                    // Now have the computer move
                    this.PerformComputerMove();
                    Debug.Log("computer moved");
                }
            }
            // Queenside
            if (2 == selectedSpace.i_ && 0 == selectedSpace.j_)
            {
                bool clearPath = (masterBoard_[3, 0] == null && masterBoard_[2, 0] == null);
                bool rookPresent = (masterBoard_[0, 0] != null && !masterBoard_[0, 0].GetHasMoved());
                bool notInCheck = !BoardEvaluator.IsInCheck(masterBoard_, Team.Player);
                bool notThroughCheck = BoardEvaluator.GetAttackingLocations(masterBoard_, Team.Computer, new BoardPosition(3, 0)).Count == 0 &&
                                       BoardEvaluator.GetAttackingLocations(masterBoard_, Team.Computer, new BoardPosition(2, 0)).Count == 0;
                // Do the queenside castling
                if (clearPath && rookPresent && notInCheck && notThroughCheck)
                {
                    // Move the king
                    masterBoard_[2, 0] = masterBoard_[4, 0];
                    masterBoard_[2, 0].MoveToSpace(new BoardPosition(2, 0), true);
                    // Move the rook
                    masterBoard_[3, 0] = masterBoard_[0, 0];
                    masterBoard_[3, 0].MoveToSpace(new BoardPosition(3, 0), true);
                    // Clear both spaces
                    masterBoard_[4, 0] = null;
                    masterBoard_[0, 0] = null;
                    this.ResetLegalMoveSpaces();

                    // Now have the computer move
                    this.PerformComputerMove();
                    Debug.Log("computer moved");
                }
            }
        }
        else
        {
            Debug.Log("That is not a legal move.");
        }
        selectedPiece_ = null;
    }

    public void PerformComputerMove()
    {
        MoveInfo move = AIMover.ChooseComputerMove(masterBoard_);
        Piece p = move.movingPiece;
        if (null != move.capturedPiece)
        {
            move.capturedPiece.gameObject.SetActive(false);
        }
        masterBoard_[move.moveToLocation.i_, move.moveToLocation.j_] = p;
        masterBoard_[move.moveFromLocation.i_, move.moveFromLocation.j_] = null;
        p.MoveToSpace(move.moveToLocation, true);
        this.ResetLegalMoveSpaces();
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

    // Iterate over all pieces and updates where they can and can't move
    public void ResetLegalMoveSpaces()
    {
        for (int i = 0; i < BoardManager.CHESSBOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardManager.CHESSBOARD_SIZE; j++)
            {
                if (null == masterBoard_[i, j])
                {
                    continue;
                }
                Piece currentPiece = masterBoard_[i, j];
                // Check all of the spaces the piece can physically get to
                List<BoardPosition> reachableMoveSpaces = currentPiece.GetReachableMoveSpaces(masterBoard_);
                List<BoardPosition> legalMoveSpaces = new List<BoardPosition>();
                foreach (BoardPosition bp in reachableMoveSpaces)
                {
                    // Temporarily move the piece there
                    Piece capturedPiece = masterBoard_[bp.i_, bp.j_];
                    BoardPosition previousLocation = currentPiece.GetBoardPosition();
                    masterBoard_[previousLocation.i_, previousLocation.j_] = null;
                    currentPiece.MoveToSpace(bp);
                    masterBoard_[bp.i_, bp.j_] = currentPiece;

                    // Does it put its own team in check?
                    if (!BoardEvaluator.IsInCheck(masterBoard_, currentPiece.GetTeam()))
                    {
                        legalMoveSpaces.Add(bp);
                    }

                    // Put the piece back
                    masterBoard_[previousLocation.i_, previousLocation.j_] = currentPiece;
                    currentPiece.MoveToSpace(previousLocation);
                    masterBoard_[bp.i_, bp.j_] = capturedPiece;
                }

                currentPiece.SetLegalMoveSpaces(legalMoveSpaces);
            }
        }
    }
}
