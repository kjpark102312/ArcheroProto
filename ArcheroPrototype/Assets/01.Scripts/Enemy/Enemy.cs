using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [Header("디버프 관련")]

    public float damage = 0f;
    public float tick = 0f;
    public float duration = 0f;

    public bool isDebuffing = false;

    [Header("몬스터 스텟")]

    public float hp = 10f;
    public float speed = 5f;

    [SerializeField] private SkinnedMeshRenderer mat;

    private IEnumerator debuffCo;

    public float timer = 0f;

    private Animator anim;

    public bool isDead = false;

    private SelectUI selectUI;

    private void Start()
    {
        debuffCo = DebuffCo();
        mat = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        selectUI = FindObjectOfType<SelectUI>();
    }

    private void Update()
    {
        if(isDebuffing)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                timer = 0f;
                isDebuffing = false;
                StopCoroutine(debuffCo);
            }
        }

        if(hp <=0)
        {
            StopAllCoroutines();
            Dead();

        }

    }

    private IEnumerator DebuffCo()
    {
        timer = 0f;
        isDebuffing = true;
        while (true)
        {
            hp -= damage;
            if (hp <= 0f)
            {
                StopAllCoroutines();
                Dead();
            }

            yield return new WaitForSeconds(tick);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            HitEffect();
            if (other.GetComponent<WeaponAbilityManager>().abilityList.Count > 0)
            {
                if (!isDebuffing)
                    StartCoroutine(debuffCo);
            }
        }   
    }

    private void HitEffect()
    {
        mat.material.DOColor(Color.red, 0.1f).OnComplete(() =>
        {
            mat.material.DOColor(Color.white, 0.1f);
        });

    }

    private void Dead()
    {
        anim.SetTrigger("Die");
        Debug.Log("asd");
        GetComponent<BoxCollider>().enabled = false;
        isDead = true;
        selectUI.ShowPanel();
    }
}
