using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    private Rigidbody2D p_RigidBody;

    private const float p_Speed = 10.0f;

    private float p_MaxHealth = 5f;
    private float p_CurrHealth;
    private Slider p_HealthBar;
    #endregion

    #region Initialization

    private void Start()
    {
        p_RigidBody = GetComponent<Rigidbody2D>();
        p_CurrHealth = p_MaxHealth;
        p_HealthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
        p_HealthBar.maxValue = p_MaxHealth;
        p_HealthBar.value = p_CurrHealth;
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

    public void UpdateHealth(float val)
    {
        p_CurrHealth = Mathf.Min(Mathf.Max(0f, p_CurrHealth + val), p_MaxHealth);
        p_HealthBar.value = p_CurrHealth;
        // Floating point comparisons are always suspect.
        if (p_CurrHealth == 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
