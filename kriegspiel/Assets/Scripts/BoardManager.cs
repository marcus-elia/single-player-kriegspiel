using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public const int CHESSBOARD_SIZE = 8;
    private GameObject[,] spaces = new GameObject[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
    public Texture2D blackSquareTex;
    public Texture2D whiteSquareTex;
    //public Texture2D whiteRookTex;
    public Sprite whiteRookSprite;

    private List<GameObject> pieces;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < CHESSBOARD_SIZE; i++)
        {
            for(int j = 0; j < CHESSBOARD_SIZE; j++)
            {
                spaces[i, j] = new GameObject();
                spaces[i, j].AddComponent<BoardSpace>();
                spaces[i, j].transform.position = new Vector2(i, j);
                spaces[i, j].GetComponent<BoardSpace>().SetTexture((i + j) % 2 == 0 ? blackSquareTex : whiteSquareTex);
            }
        }

        GameObject testRook = new GameObject();
        testRook.AddComponent<Piece>();
        testRook.GetComponent<Piece>().SetSprite(whiteRookSprite);
        testRook.GetComponent<Piece>().SetBoardPosition(0, 0);
        pieces.Add(testRook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
