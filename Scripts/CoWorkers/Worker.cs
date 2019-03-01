using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public float turnSpeed;

    [Range(0,1)]
    public float animSpeed = 1;



    public float timeBtwActions;

    Vector3 velocity = Vector3.zero;

    Animator anim;
    Rigidbody rb;
    public Action action;

    private void Start()
    {
        Initialization();
        rb.isKinematic = true;
        
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

    void PerformAction()
    {
        Invoke("Perform", timeBtwActions);
    }

    void Perform()
    {
        switch (action)
        {
            case Action.LOOK_BACK_POSITIVE:
                anim.Play("180P");
                break;
            case Action.LOOK_BACK_NEGATIVE:
                anim.Play("180N");
                break;
            case Action.LOOK_LEFT:
                anim.Play("90N");
                break;
            case Action.LOOK_RIGHT:
                anim.Play("90P");
                break;
        }
    }

    void Return()
    {
        switch (action)
        {
            case Action.LOOK_BACK_POSITIVE:
                anim.Play("R180P");
                break;
            case Action.LOOK_BACK_NEGATIVE:
                anim.Play("R180N");
                break;
            case Action.LOOK_LEFT:
                anim.Play("R90N");
                break;
            case Action.LOOK_RIGHT:
                anim.Play("R90P");
                break;
        }
    }

    public void ReturnToPosition()
    {
        Invoke("Return", timeBtwActions);
    }

    void Initialization()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        anim.speed = animSpeed;

        if (action != Action.IDLE)
        {
            turnSpeed = 0;
            Invoke("PerformAction", timeBtwActions);
        } else
            anim.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.instance.Death();
        }
    }
}

public enum Action
{
    IDLE,
    LOOK_BACK_POSITIVE,
    LOOK_BACK_NEGATIVE,
    LOOK_RIGHT,
    LOOK_LEFT
}
