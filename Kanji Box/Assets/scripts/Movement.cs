using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player; 
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       player = transform.parent.gameObject;
       pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey ("w")) {
            Debug.Log("moved");
             pos.y = player.transform.position.y + player.GetComponent<Collider>().bounds.size.y;
         }
         if (Input.GetKey ("s")) {
             //pos.y -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             //pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             //pos.x -= speed * Time.deltaTime;
         }
    }
    //after checking it is aa viable move makes move.
    void makemove()
    {
        player.transform.position = transform.position;
    }
}
