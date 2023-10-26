using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  

public class PlayerController : MonoBehaviour
{
    public GameObject deathText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float spd = 7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathText.SetActive(false);
    }
    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement*spd);
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Rubble"){
            this.gameObject.SetActive(false);
            deathText.SetActive(true);
        }
    }
}
