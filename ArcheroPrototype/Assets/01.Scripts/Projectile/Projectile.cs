using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 600f;
    [SerializeField] private float damage = 1f;

    private Rigidbody rb = null;
    private WeaponAbilityManager weaponAbility = null;


    private float timer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        weaponAbility = GetComponent<WeaponAbilityManager>();
    }
    private void Start()
    {
        rb.AddForce(transform.forward * speed);
        timer = 0f;
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
        timer = 0f;

        Debug.Log("½ÃÀÛ");
    }

    private void Update()
    {
        if(gameObject.activeSelf)
            timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            this.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().hp -= damage;

            if(weaponAbility.abilityList.Count > 0)
            {
                weaponAbility.ApplyAbility(other.GetComponent<Enemy>());
            }

            this.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
        }
    }
}
