using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appletree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 20.0f;
    public float leftandRightEdge = 12f;
    public float chanceToChangeDirections = 0.05f;
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x < -leftandRightEdge)
            speed = Mathf.Abs(speed);
        else if(pos.x > leftandRightEdge)
            speed = -Mathf.Abs(speed);
    }

    void FixedUpdate(){
        if(Random.value < chanceToChangeDirections)
            speed *= -1;
        
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple",secondsBetweenAppleDrops);
    }
}
