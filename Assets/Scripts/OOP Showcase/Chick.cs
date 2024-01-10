using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : Animal
{
    // ENCAPSULATION
    private float speed = .8f;
    private float bound = 5f;
    private float jumpforce = 20f;
    // ABSTRACTION, POLYMOPHISM
    public override void Move()
    {
        if (transform.position.z < bound)
        {
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animalRb.velocity = new Vector3(animalRb.velocity.x, animalRb.velocity.y, speed);
        }
        else
        {
            animalRb.velocity = new Vector3(animalRb.velocity.x, animalRb.velocity.y, 0);
        }
    }

    public override void MakeSound()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Cluck Cluck");
        }
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animalRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    public override string GetName()
    {
        return "Chick";
    }

}
