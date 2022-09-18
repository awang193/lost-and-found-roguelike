using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Cached References
    private Transform p_PlayerTransform;
    #endregion

    #region Initialization
    private void Start()
    {
        p_PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    #endregion

    #region Updates
    private void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.x = p_PlayerTransform.position.x;
        cameraPos.y = p_PlayerTransform.position.y;

        transform.position = cameraPos;
    }
    #endregion
}
