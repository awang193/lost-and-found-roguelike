using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private HUDManager m_HUDManager;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private GameObject m_PelletPrefab;

    [SerializeField]
    private int m_MaxHealth;
    #endregion

    #region Private Variables
    private Animator p_PlayerAnimator;
    private Rigidbody2D p_RigidBody;

    // Health-related fields
    private float p_CurrDamage;
    private float p_CurrHealth;
    #endregion

    #region Public Variables
    public bool pub_FoundHydroflask;
    #endregion

    #region Initialization
    private void Start()
    {
        p_PlayerAnimator = GetComponent<Animator>();
        p_RigidBody = GetComponent<Rigidbody2D>();
        p_CurrDamage = DataManager.st.pub_Damage;
        p_CurrHealth = DataManager.st.pub_Health;
    }
    #endregion

    #region Updates
    private void Update()
    {
        m_HUDManager.UpdateHealth(p_CurrHealth / m_MaxHealth);

        // Movement and animation
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        p_PlayerAnimator.SetBool("Walking", xAxis != 0 || yAxis != 0);
        p_PlayerAnimator.SetFloat("dirX", xAxis);
        p_PlayerAnimator.SetFloat("dirY", yAxis);

        Vector2 moveDirection = new Vector2(xAxis, yAxis);
        p_RigidBody.velocity = moveDirection * m_Speed;

        // Shooting pellets
        if (pub_FoundHydroflask && Input.GetMouseButtonDown(0))
        {   
            Instantiate(m_PelletPrefab, transform.position, Quaternion.identity);
        }
    }
    #endregion

    #region Health Methods
    public void TakeDamage(float amount)
    {
        p_CurrHealth = Mathf.Max(Mathf.Min(p_CurrHealth - amount, m_MaxHealth), 0);
        DataManager.st.pub_Health = p_CurrHealth;

        if (p_CurrHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.LogWarning("Game Over!");
        }
    }
    #endregion

    #region Damage Methods
    public void UpdateDamage(float multiplier)
    {
        p_CurrDamage *= multiplier;
        DataManager.st.pub_Damage = p_CurrDamage;
    }
    #endregion

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered trigger!");
    }
    #endregion
}
