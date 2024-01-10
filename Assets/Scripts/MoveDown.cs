using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 500.0f;
    private float xDestroy = 30f;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > xDestroy)
        {
            Destroy(gameObject);
        }
    }
}
