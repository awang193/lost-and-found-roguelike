using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private PlayerController m_Player;

    [SerializeField]
    private GameObject m_BarrierText;
    #endregion

    #region Initialization
    private void Start()
    {
        
    }
    #endregion

    #region Updates
    private void Update()
    {
        if (m_Player.pub_FoundHydroflask)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_BarrierText.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_BarrierText.SetActive(false);
        }
    }
    #endregion
}
