using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homer : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;

    bool dashing = false;

    public bool walking = false;

    Rigidbody rb;
    Camera cam;
    Vector3 velocity = Vector3.zero;
    Vector3 dir = Vector3.zero;
    AudioSource stepFX;
    public ParticleSystem dustFX;
    public ParticleSystem dashFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stepFX = GetComponent<AudioSource>();
        dustFX = GetComponentInChildren<ParticleSystem>();
        cam = Camera.main;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h,0,v).normalized;

        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);

        velocity = dir * moveSpeed;

        if (velocity != Vector3.zero)
        {
            if (!stepFX.isPlaying)
                stepFX.Play();

            dustFX.Play();
        }
        else
            dustFX.Stop();

        HandleDash();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }


    private void HandleDash()
    {
        
    }
}
