using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private TMP_Text m_ScoreText;

    [SerializeField]
    private RectTransform m_HealthBarTransform;
    #endregion

    #region Private Variables
    private string p_DefaultScoreText;

    private float p_HealthBarWidth;
    #endregion

    #region Initialization
    private void Start()
    {
        p_DefaultScoreText = m_ScoreText.text;
        p_HealthBarWidth = m_HealthBarTransform.sizeDelta.x;
    }
    #endregion

    #region Score Updates
    private void Update()
    {
        m_ScoreText.text = p_DefaultScoreText.Replace("%s", DataManager.st.pub_Score.ToString());
    }
    #endregion

    #region Health Methods
    public void UpdateHealth(float percent)
    {
        m_HealthBarTransform.sizeDelta = new Vector2(percent * p_HealthBarWidth, m_HealthBarTransform.sizeDelta.y);
    }
    #endregion
}
