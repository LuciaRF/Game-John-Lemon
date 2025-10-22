using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    
    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;
    Vector3 movement; //save movement direction
    float horizontal, vertical;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        InputPlayer();
        Animatig();
        AudioSteps();
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    private void OnAnimatorMove()
    {
        rb.MovePosition(transform.position + (movement * anim.deltaPosition.magnitude));
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();
    }

    void Animatig()
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void Rotation() /*This is golden. So it is very important. REMEMBER IT!*/
    {
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement,turnSpeed * Time.deltaTime, 0.0f);
        
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        
        rb.MoveRotation(rotation);
        
    }

    void AudioSteps()
    {
        if (horizontal != 0 || vertical != 0)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
