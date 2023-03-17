using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Model;
    [SerializeField]
    private float m_MoveSpeed, m_TurnSpeed, m_HorizontalInput, m_VerticalInput;

    //Animations
    public Animator m_Anim;
    private bool m_IsMoving;
    private bool m_IsStill;
    private bool m_IsSwappingDirection;


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
        m_VerticalInput = Input.GetAxis("Vertical");

        //Move the player in the direction they are facing
        Vector3 moveDirection = new Vector3(m_HorizontalInput, 0, m_VerticalInput);
        moveDirection.Normalize();

        transform.Translate(moveDirection * m_MoveSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            //Rotate the player to face the direction they are moving
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_TurnSpeed * Time.deltaTime);
        }

        //Animations
        if (m_VerticalInput != 0 || m_HorizontalInput != 0)
        {
            m_IsMoving = true;
            m_Anim.SetBool("IsMoving", true);
        }
        else
        {
            m_IsMoving = false;
        }

        if (m_VerticalInput == 0 || m_HorizontalInput == 0)
        {
            m_IsStill = true;
        }
        else
        {
            m_IsStill = false;
        }

        if (transform.rotation.y == 180 && m_HorizontalInput == 1)
        {
            m_IsSwappingDirection = true;
        }
        else if (transform.rotation.y == 0 && m_HorizontalInput == -1)
        {
            m_IsSwappingDirection = true;
        }
        else
        {
            m_IsSwappingDirection = false;
        }
    }
}
