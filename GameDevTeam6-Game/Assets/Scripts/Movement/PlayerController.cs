﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float moveSpeed = 10f;

    //Reference Variables
    private Rigidbody2D playerRB;

    private void Awake() {
        FindPlayerRB();
    }

    private void FindPlayerRB() {
        playerRB = GetComponent<Rigidbody2D>();
        if (!playerRB) {
            Debug.LogError("No Rigidbody2D Component Found on Player!");
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove() {
        var deltaX = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        var deltaY = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        Vector2 newVelocity = new Vector2(deltaX, deltaY);
        newVelocity.Normalize();
        playerRB.velocity = newVelocity * moveSpeed;
    }
}
