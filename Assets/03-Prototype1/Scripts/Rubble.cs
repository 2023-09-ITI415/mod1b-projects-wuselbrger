using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rubble : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Ground")
            Destroy(gameObject, 0.1f);
    }
}
