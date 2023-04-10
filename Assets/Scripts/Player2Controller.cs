using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Model;
    [SerializeField]
    public float m_MoveSpeed, m_TurnSpeed, m_HorizontalInput, m_VerticalInput, m_HorizontalAimInput, m_VerticalAimInput;

    //Animations
    public Animator m_Anim;

    CourtManager m_CourtManager;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }

        m_Model = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        m_MoveSpeed = 5;

        // //Move the player in the direction they are facing
        Vector3 moveDirection = new Vector3(Gamepad.all[0].leftStick.ReadValue().x, 0, Gamepad.all[0].leftStick.ReadValue().y);
        moveDirection.Normalize();

        transform.Translate(moveDirection * m_MoveSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            //Rotate the player to face the direction they are moving
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_TurnSpeed * Time.deltaTime);
        }

        if (Gamepad.all[0].rightTrigger.isPressed)
        {
            m_MoveSpeed = 0;
        }

        //ANIMATIONS
        if (Gamepad.all[0].leftStick.ReadValue().x != 0 || Gamepad.all[0].leftStick.ReadValue().y != 0)
        {
            m_Anim.SetBool("IsMoving", true);
        }
        else
        {
            m_Anim.SetBool("IsMoving", false);
        }

        if (Gamepad.all[0].leftStick.ReadValue().x == 0 || Gamepad.all[0].leftStick.ReadValue().y == 0)
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

        if (Gamepad.all[0].rightStick.ReadValue().y == 0)
        {
            if (Gamepad.all[0].leftStick.right.isPressed && Gamepad.all[0].rightTrigger.isPressed)
            {
                m_Anim.SetBool("IsDivingRight", true);
            }
            else if (Gamepad.all[0].leftStick.left.isPressed && Gamepad.all[0].rightTrigger.wasPressedThisFrame)
            {
                m_Anim.SetBool("IsDivingLeft", true);
            }
            else
            {
                m_Anim.SetBool("IsDivingRight", false);
                m_Anim.SetBool("IsDivingLeft", false);
            }
        }

        if (Gamepad.all[0].rightStick.up.isPressed)
        {
            if (Gamepad.all[0].leftStick.right.isPressed && Gamepad.all[0].rightTrigger.isPressed)
            {
                m_Anim.SetBool("IsBumpingRight", true);
            }
            else if (Gamepad.all[0].leftStick.left.isPressed && Gamepad.all[0].rightTrigger.wasPressedThisFrame)
            {
                m_Anim.SetBool("IsBumpingLeft", true);
            }
            else
            {
                m_Anim.SetBool("IsBumpingRight", false);
                m_Anim.SetBool("IsBumpingLeft", false);
            }
        }

        if (Gamepad.all[0].rightStick.down.isPressed)
        {
            if (Gamepad.all[0].leftStick.right.isPressed && Gamepad.all[0].rightTrigger.isPressed)
            {
                m_Anim.SetBool("IsJumpingRight", true);
            }
            else if (Gamepad.all[0].leftStick.left.isPressed && Gamepad.all[0].rightTrigger.wasPressedThisFrame)
            {
                m_Anim.SetBool("IsJumpingLeft", true);
            }
            else
            {
                m_Anim.SetBool("IsJumpingRight", false);
                m_Anim.SetBool("IsJumpingLeft", false);
            }
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
