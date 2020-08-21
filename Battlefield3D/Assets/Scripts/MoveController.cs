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

