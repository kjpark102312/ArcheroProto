using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;
    
    private Rigidbody rb = null;

    public Ability[] abilities;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        abilities = GetComponents<Ability>();
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("ÇÇ°Ý!!");
            this.gameObject.SetActive(false);
        }
    }
}
