using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public abstract class Animal : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody animalRb;
    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        animalRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float movespeed = animalRb.velocity.magnitude;
        // Debug.Log(GetName() + " speed: " + movespeed);
        animator.SetFloat("Speed_f", movespeed);

        MakeSound();
        Jump();
    }

    // POLYMOPHISM, ABSTRACTION
    public abstract void Move();
    public abstract void MakeSound();
    public abstract void Jump();
    public abstract string GetName();
}
