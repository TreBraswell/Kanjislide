using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class board : MonoBehaviour {

    public int blocksPerLine = 4;
    public GameObject blank;
    public GameObject player;
    public GameObject block;
    public int[,] gameboard;
    private Object[] sprites;
    public int spriteindex = 0; 
    void Start()
    {
        //load all the sprites dynamically based on the scene name
        sprites = Resources.LoadAll(SceneManager.GetActiveScene().name, typeof(Sprite));
        Debug.Log("these are sprites "+ sprites.Length);
        gameboard = new int[blocksPerLine, blocksPerLine];
        CreatePuzzle();

        CreateBoard();
    }
    void Update(){
        if (Input.GetKeyDown ("r")) {
            ClearBoard();
            CreatePuzzle();
            CreateBoard();
        }
    }
    void ClearBoard(){
        for(int i = 0; i < transform.childCount;)
        {
            Destroy(transform.GetChild(i));
        }
        gameboard = new int[blocksPerLine, blocksPerLine];
    }
    int checkifvalid( Vector2 ori,Vector2 curr,Vector2 end)
    {
        if(curr.x== end.x && curr.y == end.y)
        {
            return 1 ;
        }
        if(curr.y>blocksPerLine||curr.y<0||curr.x<0||curr.x>blocksPerLine)
        {
            return 0;
        }
        if ( (gameboard[(int)curr.x,(int)curr.y] !=0 && ori != curr) ) 
        {
            return 0;
        }
        if (curr.x<end.x)
        {
            curr.x +=1; 
            return checkifvalid(ori,curr,end);
        }
        else if (curr.x>end.x)
        {
            curr.x -=1; 
            return checkifvalid(ori,curr,end);
        }
        else if(curr.y<end.y)
        {
            curr.y +=1; 
            return checkifvalid(ori,curr,end);
        } 
        else if(curr.y>end.y)
        {
            curr.y -=1; 
            return checkifvalid(ori,curr,end);
        }
        return 0;
    }
    void CreatePuzzle()
    {
        System.Random ran = new System.Random();
        Queue<Vector2> loc = new Queue<Vector2>();
        Vector2 temp;
        while(loc.Count !=sprites.Length/2)
        {
            Debug.Log(loc.Count);
            temp = new Vector2(ran.Next(0,blocksPerLine),ran.Next(0,blocksPerLine));
            if(loc.Contains(temp))
            {
                continue;
            }
            if( loc.Count == 0 || checkifvalid(loc.Peek(),loc.Peek() ,temp)>0)
            {
                gameboard[(int)temp.x,(int)temp.y] = (int)loc.Count+1;
                loc.Enqueue(temp);
            }
            else
            {
                temp = loc.Dequeue();
                gameboard[(int)temp.x,(int)temp.y] = 0;
            }

        }
        Debug.Log("puzzle created");
        string a ="";
        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                a = a +gameboard[x,y];
                
            }
            
            Debug.Log(a);
            a = "";
        }
    }
    void CreateBoard()
    {
        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = Instantiate(blank);
                //change sprite
                
                blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(x*(blockObject.GetComponent<SpriteRenderer>().bounds.size.x), y*(blockObject.GetComponent<SpriteRenderer>().bounds.size.y));
                blockObject.transform.parent = transform;
                
                if(gameboard[x,y] ==1)
                {
                    Debug.Log("WEEEEE DIIIIDDDD IT");
                    GameObject playercopy = Instantiate(player);
                    playercopy.transform.position=  blockObject.transform.position;
                    playercopy.GetComponent<SpriteRenderer>().sprite = (Sprite)(sprites[0]);
                    var bounds = playercopy.GetComponent<SpriteRenderer>().bounds;
                    var factor = blank.GetComponent<SpriteRenderer>().bounds.size.y / bounds.size.y;
                    playercopy.transform.localScale =new Vector3(factor, factor, factor);
                    spriteindex++;
                    
                }
                else if (gameboard[x,y]!=0)
                {
                    GameObject playercopy = Instantiate(block);
                    playercopy.transform.position=  blockObject.transform.position;
                    playercopy.GetComponent<SpriteRenderer>().sprite = (Sprite)(sprites[gameboard[x,y]]);
                    var bounds = playercopy.GetComponent<SpriteRenderer>().bounds;
                    var factor = blank.GetComponent<SpriteRenderer>().bounds.size.y / bounds.size.y;
                    playercopy.transform.localScale =new Vector3(factor, factor, factor);
                    playercopy.transform.parent = blockObject.transform;
                    spriteindex++;
                }
            }
        }
    Camera.main.transform.position = new Vector3((blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.x/2)+1,(blocksPerLine/2 *blank.GetComponent<SpriteRenderer>().bounds.size.y/2)+1,Camera.main.transform.position.z);
    Camera.main.orthographicSize =( (blocksPerLine* .55f )*blank.GetComponent<SpriteRenderer>().bounds.size.y);
    }
}