using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Birdie : MonoBehaviour
{
    Vector3 m_StartPos;
    GameManager m_GameManager;
    [SerializeField] private GameObject m_Indicator;

    private void Start()
    {
        m_Indicator = GameObject.Find("Indicator");
        m_GameManager = GetComponent<GameManager>();
        m_StartPos = transform.position;
    }

    private void Update()
    {
        //make the indicator follow the birdie without moving up or down
        m_Indicator.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("OutOfBounds"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = m_StartPos;
        }

        if (collision.transform.CompareTag("Zone B"))
        {
            // Increase player 1 score
            //m_GameManager.m_Score1++;
        }

        if (collision.transform.CompareTag("Zone A"))
        {
            // Increase player 2 score
            //m_GameManager.m_Score2++;
        }
    }
}
