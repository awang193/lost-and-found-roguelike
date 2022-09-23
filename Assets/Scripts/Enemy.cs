using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int m_MaxHealth;

    [SerializeField]
    private float m_Damage;
    #endregion

    #region Private Variables
    private float p_CurrHealth;
    #endregion

    #region Initialization
    private void Start()
    {
        p_CurrHealth = m_MaxHealth;
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_CurrHealth = Mathf.Max(p_CurrHealth - amount, 0);
        
        if (p_CurrHealth <= 0)
        {
            Debug.Log("Monster destroyed!");
            Destroy(gameObject);
        }
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().UpdateHealth(-1 * m_Damage);
        }
    }
    #endregion
}
