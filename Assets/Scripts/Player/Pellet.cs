using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private PlayerController m_Player;

    [SerializeField]
    private float m_PelletSpeed;

    [SerializeField]
    private float m_MaxLifespan;
    #endregion

    #region Private Variables
    private float p_Age;
    #endregion

    #region Initialization
    private void Start()
    {
        p_Age = 0;

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * m_PelletSpeed;
        
        Vector3 reverse = -1 * direction;
        float rotation = Mathf.Atan2(reverse.y, reverse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }
    #endregion

    #region Updates
    private void Update()
    {
        p_Age += Time.deltaTime;
        if (p_Age > m_MaxLifespan)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Collision Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().DecreaseHealth(m_Player.Damage);
            Destroy(gameObject);
        }
    }
    #endregion
}
