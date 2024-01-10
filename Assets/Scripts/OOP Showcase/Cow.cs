using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    // ENCAPSULATION
    private float speed = .5f;
    private float bound = 35;
    private float jumpforce = 1000f;
    // ABSTRACTION
    public override void Move()
    {
        if (transform.position.x < bound)
        {
            // transform.Translate(Vector3.right * speed * Time.deltaTime);
            animalRb.velocity = new Vector3(speed, animalRb.velocity.y, animalRb.velocity.z);
        }
        else 
        {
            animalRb.velocity = new Vector3(0, animalRb.velocity.y, animalRb.velocity.z);
        }
    }

    public override void MakeSound()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Mooooo...");
        }
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animalRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    public override string GetName()
    {
        return "Cow";
    }
}
