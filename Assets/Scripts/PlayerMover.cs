using System;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.CharacterController))]
public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    public float rotateSpeed = 10f;
    public float stopDistance = 0.25f;

    public Animator animator;
    public string walkBool = "isWalking";


    UnityEngine.CharacterController cc;
    Vector3 target;
    bool moving;
    public event Action OnArriveDestination;

    void Awake()
    {
        cc = GetComponent<UnityEngine.CharacterController>();
        if (!animator) animator = GetComponent<Animator>();
        target = transform.position;
    }

    void Update()
    {
        if (!moving) return;

        Vector3 to = target - transform.position;
        to.y = 0f;

        if (to.magnitude <= stopDistance)
        {
            moving = false;
            animator?.SetBool(walkBool, false);
            OnArriveDestination?.Invoke();
            return;
        }

        Vector3 dir = to.normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);

        Vector3 move = dir * moveSpeed * Time.deltaTime;
        //move.y = -2f * Time.deltaTime;
        cc.Move(move);
    }

    public void MoveTo(Vector3 p)
    {
        target = p;
        moving = true;
        animator?.SetBool(walkBool, true);
    }
    public bool IsMoving => moving;
}
