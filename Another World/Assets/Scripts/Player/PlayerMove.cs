using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 6f;

    public float cameraAxisX = 0;


    [SerializeField] Animator playerAnimator;

    private Vector3 playerDirection;

    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
            if (!IsAnimation("FORWARD")) playerAnimator.SetTrigger("FORWARD");
        }

        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
            if (!IsAnimation("BACK")) playerAnimator.SetTrigger("BACK");
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
            if (!IsAnimation("LEFT")) playerAnimator.SetTrigger("LEFT");
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
            if (!IsAnimation("RIGHT")) playerAnimator.SetTrigger("RIGHT");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!IsAnimation("JUMP")) playerAnimator.SetTrigger("JUMP");
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (!IsAnimation("PUNCH")) playerAnimator.SetTrigger("PUNCH");
        }

        if (playerDirection != Vector3.zero)
        {
            MovePlayer(playerDirection);
        }
        else
        {
            if (!IsAnimation("IDLE")) playerAnimator.SetTrigger("IDLE");
        }
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0, cameraAxisX, 0);
    }
}

