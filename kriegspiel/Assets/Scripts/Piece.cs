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

public class Piece : MonoBehaviour
{
    private BoardPosition boardPosition;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    // Update is called once per frame
    void Update()
    {

    }
}
