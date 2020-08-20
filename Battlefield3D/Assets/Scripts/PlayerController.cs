using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 2.0F;
    float gravity = 20F;

    public float turnSpeed;
    public Transform PosTarget;

    Animator animator;
    Vector3 direction;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        PosTarget.position = ray.GetPoint(15);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (controller.isGrounded)
        {
            PlayAnim(horizontal, vertical);

            direction = new Vector3(horizontal, 0f, vertical);

            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                direction.y = 6;
            }
        }


        direction.y -= gravity * Time.deltaTime;

        controller.Move(direction * Time.deltaTime);

        if (horizontal != 0 || vertical != 0)
        {

            Vector3 dir = PosTarget.position - transform.position;
            dir.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        }

        

    }

    public void PlayAnim(float horizontal, float vertical)
    {
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Horizontal", horizontal);
    }
}
