using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("on the trigger");
        if(transform.childCount <= 0)
        {
            Debug.Log("move cleared");
            other.transform.parent.transform.position = transform.position;
            other.transform.position = new Vector3(1000,100,0);
        }
    }
}
