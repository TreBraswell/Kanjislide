using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {

    public int blocksPerLine = 4;
    public GameObject blank;
    void Start()
    {
        CreatePuzzle();
    }

    void CreatePuzzle()
    {
        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = Instantiate(blank);
                //change sprite
                blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(x*(blockObject.GetComponent<SpriteRenderer>().bounds.size.x), y*(blockObject.GetComponent<SpriteRenderer>().bounds.size.y));
                blockObject.transform.parent = transform;
            }
        }
    Camera.main.transform.position = new Vector3((blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.x/2)+1,(blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.y/2)+1,Camera.main.transform.position.z);
    Camera.main.orthographicSize =( (blocksPerLine* .55f )*blank.GetComponent<SpriteRenderer>().bounds.size.y);
    }
}