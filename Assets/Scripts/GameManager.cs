using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int m_Score1, m_Score2;
    [SerializeField]
    private TextMeshProUGUI m_ScoreText1, m_ScoreText2;

    // Start is called before the first frame update
    void Start()
    {
        m_Score1 = 0;
        m_Score2 = 0;

        m_ScoreText1.text = m_Score1.ToString();
        m_ScoreText2.text = m_Score2.ToString();
    }
}
