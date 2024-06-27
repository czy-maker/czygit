using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 m_Movement;
    float horizontal;
    float vertical;

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    public float turnSpeed = 20.0f;

   
    Quaternion m_Rotation = Quaternion.identity;

    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {

        m_Movement.Set(horizontal, 0.0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontal = !Mathf.Approximately(horizontal, 0.0f);
        bool hasVertical = !Mathf.Approximately(vertical, 0.0f);
        bool IsWalking = hasHorizontal || hasVertical;
        m_Animator.SetBool("IsWalking", IsWalking);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        if (IsWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
            else{
                m_AudioSource.Stop();
            }
        }
    }
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
