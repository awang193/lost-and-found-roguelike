using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    private Animator m_Animator;
    #endregion

    #region Private Variables
    private Rigidbody2D p_RigidBody;

    private const float p_Speed = 10;
    #endregion

    #region Initialization
    private void Start()
    {
        m_Animator = GetComponent<Animator>();

        p_RigidBody = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Updates
    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        m_Animator.SetBool("Walking", xAxis != 0 || yAxis != 0);
        m_Animator.SetFloat("dirX", xAxis);
        m_Animator.SetFloat("dirY", yAxis);

        if (yAxis > 0)
        {
            m_Animator.SetFloat("movingN", 1);
        }
        else if (yAxis < 0)
        {
            m_Animator.SetFloat("movingN", -1);
        }
        else
        {
            m_Animator.SetFloat("movingN", 0);
        }

        if (xAxis > 0)
        {
            m_Animator.SetFloat("movingE", 1);
        }
        else if (xAxis < 0)
        {
            m_Animator.SetFloat("movingE", -1);
        }

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
