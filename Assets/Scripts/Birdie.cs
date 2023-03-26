using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdie : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Model;
    [SerializeField]
    private float m_MoveSpeed;
    
    private bool m_CanHit;
    private CourtManager m_CourtZone;
    private PlayerController m_PlayerHit;
    private Vector3 m_HitDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_HitDirection = new Vector3(m_PlayerHit.m_HorizontalAimInput, 0, 1);
        
        if (m_CourtZone != null)
        {
            // if (m_CourtZone.m_HomeZones[0].GetComponent<Zone>().m_IsActive)
            // {
            //     m_HitDirection = m_PlayerHit.transform.position - transform.position;
            //     transform.Translate(m_HitDirection * m_MoveSpeed * Time.deltaTime, Space.World);
            // }
        }

        if (m_CanHit)
        {
            if (m_PlayerHit != null)
            {
                m_HitDirection = m_PlayerHit.transform.position - transform.position;
                transform.Translate(m_HitDirection * m_MoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_CanHit = true;
            m_PlayerHit = other.gameObject.GetComponent<PlayerController>();
        }
    }
}
