using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_MoveSpeed = 10.0f;
    public float m_TurnSpeed = 25.0f;
    public float m_HorizontalInput;
    public float m_ForwardInput;

    //Animations
    public Animator m_Anim;
    private bool m_IsMoving;
    private bool m_IsStill;
    private bool m_IsTurning;


    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //This is where we get player input
        m_HorizontalInput = Input.GetAxis("Horizontal");
        m_ForwardInput = Input.GetAxis("Vertical");

        //We'll move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * m_MoveSpeed * m_ForwardInput);
        //We'll turn the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * m_TurnSpeed * m_HorizontalInput);

        //Animations
        m_IsMoving = m_ForwardInput != 0;
        m_IsStill = m_ForwardInput == 0;
        m_IsTurning = m_HorizontalInput != 0;

        m_Anim.SetBool("IsMoving", m_IsMoving);
        m_Anim.SetBool("IsStill", m_IsStill);
        m_Anim.SetBool("IsTurning", m_IsTurning);
    }
}
