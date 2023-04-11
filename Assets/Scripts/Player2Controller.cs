using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private GameObject m_Model;
    [SerializeField] private Transform m_Birdie;
    [SerializeField] private float m_HitSpeed = 3f, m_HitForce = 10f, m_HitHeight;
    [SerializeField]
    public float m_MoveSpeed, m_TurnSpeed, m_HorizontalInput, m_VerticalInput, m_HorizontalAimInput, m_VerticalAimInput;
    [SerializeField] private bool m_Hitting, m_CanHit;
    //Animations
    public Animator m_Anim;

    CourtManager m_CourtManager;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            //Gamepad 2 will control player 2
            if (Gamepad.all[i] != Gamepad.all[1])
            {
                m_Model = GameObject.Find("Player2");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        m_MoveSpeed = 5;

        // //Move the player in the direction they are facing
        Vector3 moveDirection = new Vector3(-Gamepad.all[1].leftStick.ReadValue().x, 0, -Gamepad.all[1].leftStick.ReadValue().y);
        moveDirection.Normalize();

        transform.Translate(moveDirection * m_MoveSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            //Rotate the player to face the direction they are moving
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_TurnSpeed * Time.deltaTime);
        }

        if (m_CanHit)
        {
            if (Gamepad.all[1].rightTrigger.isPressed)
            {
                m_Hitting = true;
            }
            else if (Gamepad.all[1].rightTrigger.isPressed == false)
            {
                m_Hitting = false;
            }

            if (m_Hitting)
            {
                Vector3 m_HitDirection = m_Birdie.position - transform.position;
                m_Birdie.Translate(new Vector3(Gamepad.all[1].rightStick.ReadValue().x, 0, 0) * m_HitSpeed * Time.deltaTime, Space.World);
                m_Birdie.GetComponent<Rigidbody>().velocity = m_HitDirection.normalized * m_HitForce + new Vector3(0, m_HitHeight, 0);

            }

            if ((Gamepad.all[1].rightStick.ReadValue().x != 0 || Gamepad.all[1].rightStick.ReadValue().y != 0) && !m_Hitting)
            {
                m_Birdie.Translate(new Vector3(Gamepad.all[1].rightStick.ReadValue().x, 0, Gamepad.all[1].rightStick.ReadValue().y) * m_HitSpeed * Time.deltaTime, Space.World);
            }
        }

        


        //ANIMATIONS
        if (Gamepad.all[1].leftStick.ReadValue().x != 0 || Gamepad.all[1].leftStick.ReadValue().y != 0)
        {
            m_Anim.SetBool("IsMoving", true);
        }
        else
        {
            m_Anim.SetBool("IsMoving", false);
        }

        if (Gamepad.all[1].leftStick.ReadValue().x == 0 || Gamepad.all[1].leftStick.ReadValue().y == 0)
        {

            m_Anim.SetBool("IsStill", true);
        }

        // if (transform.rotation.y == 180 && m_HorizontalInput == 1)
        // {
        //     m_Anim.SetBool("IsSwappingDirection", true);
        // }
        // else if (transform.rotation.y == 0 && m_HorizontalInput == -1)
        // {
        //     m_Anim.SetBool("IsSwappingDirection", true);
        // }

        if (Gamepad.all[1].rightStick.ReadValue().y == 0)
        {
            m_HitForce = 10;
            m_HitHeight = 9;

            // if (m_Model.transform.position.x > 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsDivingRight", true);
            // }
            // else if (m_Model.transform.position.x < 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsDivingLeft", true);
            // }
            // else
            // {
            //     m_Anim.SetBool("IsDivingRight", false);
            //     m_Anim.SetBool("IsDivingLeft", false);
            // }
        }

        if (Gamepad.all[1].rightStick.down.isPressed)
        {
            m_HitForce = 7;
            m_HitHeight = 9;

            // if (m_Model.transform.position.x > 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsBumpingRight", true);
            // }
            // else if (m_Model.transform.position.x < 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsBumpingLeft", true);
            // }
            // else
            // {
            //     m_Anim.SetBool("IsBumpingRight", false);
            //     m_Anim.SetBool("IsBumpingLeft", false);
            // }
        }

        if (Gamepad.all[1].rightStick.up.isPressed)
        {
            m_HitForce = 13;
            m_HitHeight = 9;

            // if (m_Model.transform.position.x > 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsJumpingRight", true);
            // }
            // else if (m_Model.transform.position.x < 0 && Gamepad.all[1].rightTrigger.wasPressedThisFrame)
            // {
            //     m_Anim.SetBool("IsJumpingLeft", true);
            // }
            // else
            // {
            //     m_Anim.SetBool("IsJumpingRight", false);
            //     m_Anim.SetBool("IsJumpingLeft", false);
            // }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            m_CanHit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            m_CanHit = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
