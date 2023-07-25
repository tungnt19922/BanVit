using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xSpeed;
    public float minYspeed;
    public float maxYspeed;

    public GameObject DeathVFX;

    Rigidbody2D m_rb;

    bool m_moveLeftOfStart;

    bool m_isDead;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandomMovingDirection();
    }

    private void Update()
    {
        m_rb.velocity = m_moveLeftOfStart ? new Vector2(-xSpeed, Random.Range(minYspeed, maxYspeed)) : new Vector2(xSpeed, Random.Range(minYspeed, maxYspeed));
        Flip();
    }

    public void RandomMovingDirection ()
    {
        m_moveLeftOfStart = transform.position.x > 0 ? true : false;
    }

    void Flip()
    {
        if (m_moveLeftOfStart)
        {
            if (transform.localScale.x < 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Die()
    {
        m_isDead = true;
        Destroy(gameObject);
        if(DeathVFX)
        {
            Instantiate(DeathVFX, transform.position, Quaternion.identity);
        }
    }
}
