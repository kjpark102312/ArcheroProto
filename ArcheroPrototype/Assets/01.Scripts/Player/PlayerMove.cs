using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb = null;

    public Vector3 MoveDir { get { return moveDir; } set { moveDir = value; } }
    private Vector3 moveDir = Vector3.zero;

    public bool IsMove{  get { return isMove; } set { isMove = value; } }
    private bool isMove = false;

    private Vector2 rotationDir = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isMove)
        {
            Move();

            rotationDir = new Vector2(moveDir.x, moveDir.z);
            transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(rotationDir.x, rotationDir.y) * Mathf.Rad2Deg, 0f);
        }
    }

    public void Move()
    {
        rb.velocity = speed * moveDir;
    }
}
