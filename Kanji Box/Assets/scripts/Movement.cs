using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public GameObject player; 
    private Vector3 pos;
    public GameObject blank;
    private Object[] sprites;
    //private Object[] sprites;
    // Start is called before the first frame update
    void Start()
    {
       player = transform.parent.gameObject;
       pos = player.transform.position;
       sprites = Resources.LoadAll(SceneManager.GetActiveScene().name, typeof(Sprite));
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey ("w")) {
            Vector3 ppos = player.transform.position;
            ppos.y = player.transform.position.y + player.GetComponent<SpriteRenderer>().bounds.size.y;
            transform.position = ppos;
         }
         if (Input.GetKey ("s")) {
             //pos.y -= speed * Time.deltaTime;
            Vector3 ppos = player.transform.position;
            ppos.y = player.transform.position.y - player.GetComponent<SpriteRenderer>().bounds.size.y;
            transform.position = ppos;
         }
         if (Input.GetKey ("d")) {
             //pos.x += speed * Time.deltaTime;
            Vector3 ppos = player.transform.position;
            ppos.x = player.transform.position.x + player.GetComponent<SpriteRenderer>().bounds.size.x;
            transform.position = ppos;
         }
         if (Input.GetKey ("a")) {
             //pos.x -= speed * Time.deltaTime;
            Vector3 ppos = player.transform.position;
            ppos.x = player.transform.position.x - player.GetComponent<SpriteRenderer>().bounds.size.x;
            transform.position = ppos;
         }
    }
    //after checking it is aa viable move makes move.
    void makemove()
    {
        player.transform.position = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        string col = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        string play = transform.parent.GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log(play + "  " + col);
        int c = System.Convert.ToInt32(col.Substring(col.Length-1));
        int p = System.Convert.ToInt32(play.Substring(play.Length-1));
        if(p+1==c)
        {
            Vector3 copyofcol =  collision.gameObject.transform.position;
            //set up the correct value
            transform.parent.GetComponent<SpriteRenderer>().sprite = (Sprite)(sprites[c]);
            
            var bounds = transform.parent.GetComponent<SpriteRenderer>().bounds;
            var factor = blank.GetComponent<SpriteRenderer>().bounds.size.y / bounds.size.y;
            Destroy(collision.gameObject);
            transform.parent.transform.localScale =new Vector3(factor, factor, factor);    

            transform.parent.transform.position = copyofcol;
            //transform.position = copyofcol;
            Debug.Log("correct collision");
        } 
    }
}
