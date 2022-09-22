using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayLZ : MonoBehaviour
{
    #region Loading Zone Methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float rand = Random.value;
            if (rand < 0.667)
            {
                SceneManager.LoadScene("Hallway");
            }
            else
            {
                SceneManager.LoadScene("Classroom");
            }
        }
    }
    #endregion
}
