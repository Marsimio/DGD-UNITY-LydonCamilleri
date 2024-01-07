using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Scripts : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private Animator animator;

    private void Start()
    {
    }


    void Update()
    {
        PlayerInput();
        Movement();
    }

    private void PlayerInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
    }

    private void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
