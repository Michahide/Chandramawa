using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D charRigidBody;
    private void Update() {
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * 5f * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Jump()
    {
        charRigidBody.AddForce(600f * Vector3.up);
    }
}
