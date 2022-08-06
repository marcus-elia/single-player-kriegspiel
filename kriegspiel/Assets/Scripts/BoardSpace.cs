using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { White, Black };

public class BoardSpace : MonoBehaviour
{
    public static float SQUARE_WIDTH = 1f;
    private ColorType colorType;
    private Sprite squareSprite;
    private GameObject face;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetTexture(Texture2D tex)
    {
        face = GameObject.CreatePrimitive(PrimitiveType.Quad);
        face.GetComponent<Renderer>().material.mainTexture = tex;
        face.transform.SetParent(transform);
        face.transform.localPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
