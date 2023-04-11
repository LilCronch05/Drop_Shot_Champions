using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int m_Score1, m_Score2;
    [SerializeField]
    private TextMeshProUGUI m_ScoreText1, m_ScoreText2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
        
        m_Score1 = 0;
        m_Score2 = 0;

        m_ScoreText1.text = m_Score1.ToString();
        m_ScoreText2.text = m_Score2.ToString();
    }
}
