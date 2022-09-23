using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager st;

    #region Public Variables
    public float pub_Damage;
    public float pub_Health;
    public int pub_Score;
    #endregion

    #region Initialization
    private void Awake()
    {
        if (st != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        st = this;
    }
    #endregion

    #region Public Methods
    public void UpdateScore(int amount)
    {
        st.pub_Score += amount;
    }
    #endregion
}
