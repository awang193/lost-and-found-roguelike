using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private bool m_IsHydroflask;
    #endregion

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (m_IsHydroflask)
            {
                pc.pub_FoundHydroflask = true;
                pc.UpdateDamage(1.1f);
                Destroy(gameObject);
            }
        }
    }
    #endregion
}
