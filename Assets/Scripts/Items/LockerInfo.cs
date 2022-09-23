using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LockerInfo : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private ItemDropInfo[] m_ItemDropInfos;
    #endregion

    #region Private Variables
    private BoxCollider2D p_InteractionTrigger;

    private bool p_Opened;
    #endregion

    #region Initialization
    private void Start()
    {
        p_InteractionTrigger = GetComponent<BoxCollider2D>();
        p_Opened = false;
    }
    #endregion

    #region Interaction Methods
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && !p_Opened)
        {
            p_Opened = true;

            float rand = Random.value;
            foreach (ItemDropInfo itemDropInfo in m_ItemDropInfos)
            {
                if (rand < itemDropInfo.DropRate)
                {
                    Debug.Log("Locker dropped " + itemDropInfo.Name);

                    Vector3 spawnPos = transform.position;
                    spawnPos.y -= 2.5f;

                    Instantiate(itemDropInfo.ItemPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
    #endregion
}
