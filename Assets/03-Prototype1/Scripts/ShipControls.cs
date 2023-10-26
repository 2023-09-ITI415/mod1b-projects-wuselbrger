using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public GameObject rubblePrefab;
    public float spd = 14f;
    public float edgeCoord = 7f;
    public float flip_Chance = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RubbleDrop",3f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += spd * Time.deltaTime;
        pos.z += spd*Time.deltaTime;
        transform.position = pos;
        if(pos.x < -edgeCoord)
            spd = Mathf.Abs(spd);
        else if(pos.x > edgeCoord)
            spd = -Mathf.Abs(spd);
        
        if(pos.z < -edgeCoord)
            spd = Mathf.Abs(spd);
        else if(pos.z > edgeCoord)
            spd = -Mathf.Abs(spd);
    }

    void FixedUpdate(){
        if(Random.value < flip_Chance)
            spd *= -1;
        
    }

    void RubbleDrop(){
        GameObject rubble = Instantiate<GameObject>(rubblePrefab);
        Vector3 rubbleSpawn = transform.position;
        rubbleSpawn.y = transform.position.y - 3f;
        rubble.transform.position = rubbleSpawn;
        Invoke("RubbleDrop", 3f);
    }

}
