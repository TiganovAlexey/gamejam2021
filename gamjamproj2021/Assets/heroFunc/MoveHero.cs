using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class MoveHero : MonoBehaviour
{

    public float movementSpeed = 10;
    public float turningSpeed = 10;
    public static float horizontal, vertical;

    void Start()
    {
       
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0,0, vertical);
    }


}
