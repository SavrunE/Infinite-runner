using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = 10f;
    private Animator anim;
    private CharacterController controller;
    public float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
            if (speed < 0)
                speed = 0;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float forwardAxis = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalAxis, 0, forwardAxis);// задаем направление по оси x z
        if (direction != Vector3.zero) // если чето клацаем - стартуем
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up); //повернем перса в напаравление заданное движением x z
            //тут у нас запуск анимации(без выключения)
            anim.SetFloat("speed", Speed / 5);
            anim.SetFloat("Horizontal", horizontalAxis);
            anim.SetFloat("Vertical", forwardAxis);
        }
        direction.y -= gravity * Time.fixedDeltaTime;
        controller.Move(direction * speed * Time.fixedDeltaTime);


    }
}


public class PersController : MonoBehaviour
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

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        PosTarget.position = ray.GetPoint(15);
    }

    public void PlayAnim(float horizontal, float vertical)
    {
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Horizontal", horizontal);
    }
}


