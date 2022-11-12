using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float boostMultiplier= 1.5f;
    [SerializeField] float normalMultiplier = 1f;
    [SerializeField] float bumpMultiplier = 0.5f;
    [SerializeField] float moveSpeedMultiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * moveSpeedMultiplier * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * moveSpeedMultiplier * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (moveSpeedMultiplier > normalMultiplier)
        {
            moveSpeedMultiplier = normalMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeedMultiplier = boostMultiplier;
        } 

        if (other.tag == "Bump")
        {
            moveSpeedMultiplier = bumpMultiplier;
        }
    }
}
