using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 5.0f;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    // TODO: Add gravity, verticle solutions to levels would be fun
    void move(float i, float j)
    {
        bool isRunning = i != 0 || j != 0;
        playerAnimator.SetTrigger("Walk");

        moveDirection.Set(i, 0.0f, j);

        moveDirection = moveDirection.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(moveDirection + transform.position);

        if (i != 0 || j != 0)
        {
            transform.forward = Vector3.Normalize(moveDirection);
        }
    }
}
