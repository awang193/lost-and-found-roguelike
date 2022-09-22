using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDropInfo
{
    #region Editor Variables

    [SerializeField]
    private GameObject m_ItemPrefab;
    public GameObject ItemPrefab
    {
        get
        {
            return m_ItemPrefab;
        }
    }

    [SerializeField]
    private string m_Name;
    public string Name
    {
        get
        {
            return m_Name;
        }
    }

    [SerializeField]
    private float m_DropRate;
    public float DropRate
    {
        get
        {
            return m_DropRate;
        }
    }
    #endregion
}
