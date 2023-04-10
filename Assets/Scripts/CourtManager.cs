using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player1;
    [SerializeField]
    public GameObject[] m_HomeZones;
    [SerializeField]
    public GameObject[] m_AwayZones;
    [SerializeField]
    public GameObject[] m_OutZones;

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "Birdie")
        {
            m_Player1 = other.gameObject;
        }
    }
}
