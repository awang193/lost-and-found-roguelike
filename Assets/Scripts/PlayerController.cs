using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    private Rigidbody2D p_RigidBody;

    private const float p_Speed = 10.0f;
    #endregion

    #region Initialization

    private void Start()
    {
        p_RigidBody = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Updates
    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(xAxis, yAxis);
        p_RigidBody.velocity = moveDirection * p_Speed;
    }
    #endregion

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered trigger!");
    }
    #endregion
}
