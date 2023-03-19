using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Model;
    [SerializeField]
    private float m_MoveSpeed, m_TurnSpeed, m_HorizontalInput, m_VerticalInput, m_HorizontalAimInput, m_VerticalAimInput;

    //Animations
    public Animator m_Anim;

    CourtManager m_CourtManager;

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
        m_HorizontalAimInput = Input.GetAxis("HorizontalAim");
        m_VerticalAimInput = Input.GetAxis("VerticalAim");

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
            m_Anim.SetBool("IsMoving", true);
        }
        else
        {
            m_Anim.SetBool("IsMoving", false);
        }

        if (m_VerticalInput == 0 || m_HorizontalInput == 0)
        {

            m_Anim.SetBool("IsStill", true);
        }

        if (transform.rotation.y == 180 && m_HorizontalInput == 1)
        {
            m_Anim.SetBool("IsSwappingDirection", true);
        }
        else if (transform.rotation.y == 0 && m_HorizontalInput == -1)
        {
            m_Anim.SetBool("IsSwappingDirection", true);
        }

        if (m_VerticalAimInput == 0)
        {
            if (m_HorizontalInput > 0 && Input.GetButtonDown("Fire1"))
            {
                m_Anim.SetBool("IsDivingRight", true);
            }
            else if (m_HorizontalInput < 0 && Input.GetButtonDown("Fire1"))
            {
                m_Anim.SetBool("IsDivingLeft", true);
            }
            else
            {
                m_Anim.SetBool("IsDivingRight", false);
                m_Anim.SetBool("IsDivingLeft", false);
            }
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
