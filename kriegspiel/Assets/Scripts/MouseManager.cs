using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private BoardPosition highlightedSpace_;
    private bool spaceIsHighlighted = false;
    private BoardManager boardManager_;

    public GameObject spaceHighlighterPrefab;
    private GameObject spaceHighlighter;

    // Start is called before the first frame update
    void Start()
    {
        spaceHighlighter = Instantiate(spaceHighlighterPrefab);
        spaceHighlighter.SetActive(false);
    }

    public void SetBoardManager(BoardManager bm)
    {
        boardManager_ = bm;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoardPosition clickedSpace = new BoardPosition(Mathf.FloorToInt(clickLocation.x), Mathf.FloorToInt(clickLocation.y));
            bool clickIsOnBoard = (clickedSpace.i_ >= 0 && clickedSpace.i_ < BoardManager.CHESSBOARD_SIZE &&
                                   clickedSpace.j_ >= 0 && clickedSpace.j_ < BoardManager.CHESSBOARD_SIZE);

            if (spaceIsHighlighted || !clickIsOnBoard)
            {
                // Can the piece move there?
                spaceIsHighlighted = false;
                spaceHighlighter.SetActive(false);
            }
            else
            {
                // Is a player piece there?
                if(this.boardManager_.IsPlayerPieceThere(clickedSpace))
                {
                    highlightedSpace_ = clickedSpace;
                    spaceIsHighlighted = true;
                    spaceHighlighter.SetActive(true);
                    spaceHighlighter.transform.position = new Vector3(highlightedSpace_.i_ + 0.5f, highlightedSpace_.j_ + 0.5f, -1f);
                }
            }
        }
    }
}
