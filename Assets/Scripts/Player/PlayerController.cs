using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_Damage;
    public float Damage
    {
        get
        {
            return m_Damage;
        }
    }

    [SerializeField]
    private GameObject m_PelletPrefab;

    [SerializeField]
    private int m_MaxHealth;

    [SerializeField]
    private RectTransform m_HealthBarTransform;
    #endregion

    #region Private Variables
    private Animator p_PlayerAnimator;
    private Rigidbody2D p_RigidBody;

    // Health-related fields
    private float p_CurrHealth;
    private float p_MaxHealthBarWidth;

    // Item-related fields
    private bool p_FoundHydroflask;
    private bool p_FoundSlingshot;
    #endregion

    #region Initialization
    private void Start()
    {
        p_PlayerAnimator = GetComponent<Animator>();
        p_RigidBody = GetComponent<Rigidbody2D>();

        p_CurrHealth = m_MaxHealth;
        p_MaxHealthBarWidth = m_HealthBarTransform.sizeDelta.x;
    }
    #endregion

    #region Updates
    private void Update()
    {
        // Movement and animation
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        p_PlayerAnimator.SetBool("Walking", xAxis != 0 || yAxis != 0);
        p_PlayerAnimator.SetFloat("dirX", xAxis);
        p_PlayerAnimator.SetFloat("dirY", yAxis);

        Vector2 moveDirection = new Vector2(xAxis, yAxis);
        p_RigidBody.velocity = moveDirection * m_Speed;

        // Shooting pellets
        if (Input.GetMouseButtonDown(0))
        {   
            Instantiate(m_PelletPrefab, transform.position, Quaternion.identity);
        }

    }
    #endregion

    #region Health Methods
    public void UpdateHealth(float amount)
    {
        p_CurrHealth = Mathf.Max(Mathf.Min(p_CurrHealth + amount, m_MaxHealth), 0);
        m_HealthBarTransform.sizeDelta = new Vector2(p_CurrHealth / m_MaxHealth * p_MaxHealthBarWidth, m_HealthBarTransform.sizeDelta.y);

        if (p_CurrHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.LogWarning("Game Over!");
        }
    }
    #endregion

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered trigger!");
    }
    #endregion
}
