using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Transform trans;
    public Animator anim;
    private Vector3 inputVec;
    public float speed = 8f;
    float rotationSpeed = 20f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        transform.position += moveDir * speed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            anim.SetBool("isRun", true);
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    public void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
