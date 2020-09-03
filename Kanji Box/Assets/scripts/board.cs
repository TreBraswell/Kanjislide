using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class board : MonoBehaviour {

    public int blocksPerLine = 4;
    public GameObject blank;
    public GameObject player;
    public GameObject block;
    private Object[] sprites;
    public int spriteindex = 0; 
    void Start()
    {
        //load all the sprites dynamically based on the scene name
        sprites = Resources.LoadAll(SceneManager.GetActiveScene().name, typeof(Sprite));
        Debug.Log("these are sprites "+ sprites.Length);
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
                if(spriteindex ==0)
                {
                    GameObject playercopy = Instantiate(player);
                    playercopy.transform.position=  blockObject.transform.position;
                    
                }
            }
        }
    Camera.main.transform.position = new Vector3((blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.x/2)+1,(blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.y/2)+1,Camera.main.transform.position.z);
    Camera.main.orthographicSize =( (blocksPerLine* .55f )*blank.GetComponent<SpriteRenderer>().bounds.size.y);
    }
}