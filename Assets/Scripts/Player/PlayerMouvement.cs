using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float movementSpeed = 0.05f;
    private Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    bool isWalking = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = 0f;
        if(0<Input.GetAxis("Horizontal"))
        {
            horizontal = movementSpeed;
        }
        else if(0 > Input.GetAxis("Horizontal"))
        {
            horizontal = -movementSpeed;
        }
        float vertical = 0f;
        if (0<Input.GetAxis("Vertical"))
        {
            vertical = movementSpeed;
        }
        else if (0 > Input.GetAxis("Vertical"))
        {
            vertical = -movementSpeed;
        }
        float divider = 1.5f;
        if(vertical !=0f && horizontal !=0f)
        {
            vertical /= divider;
            horizontal /= divider;
        }

        m_Movement.Set(horizontal, 0f, vertical);


        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        if (isWalking)
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement);
            m_Rigidbody.MoveRotation(m_Rotation);
            Debug.Log(m_Rigidbody.velocity);
        }
    }
}
