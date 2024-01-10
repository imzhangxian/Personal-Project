using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject player;
    private float speed = 10.0f;
    private float startDelay = 1.0f;
    private float shootInterval = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", startDelay, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot() 
    {
        player = GameObject.Find("Player");
        if (player) {
            Vector3 shootDirection = (player.transform.position - transform.position).normalized;
            float shootAngle = Mathf.Atan2(shootDirection.x, shootDirection.z) * Mathf.Rad2Deg; 
            // Debug.Log("Direction: " + shootDirection + ", angle: " + angle);
            Quaternion projectileRotation = Quaternion.Euler(0, shootAngle + 90, 90);
            GameObject projectile = Instantiate(bulletPrefab, transform.position, projectileRotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(shootDirection * speed, ForceMode.Impulse);

        }
    }
}
