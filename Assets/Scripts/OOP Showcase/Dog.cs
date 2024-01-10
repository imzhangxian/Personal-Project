using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    private float speed = 20f;
    private float bound = 30f;
    private float jumpforce = 200f;
    // Start is called before the first frame update
    public override void Move()
    {
        if (transform.position.z > - bound)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public override void MakeSound()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Woof Woof");
        }
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            animalRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    public override string GetName()
    {
        return "Dog";
    }
}
