﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public Animator anim;
    public GameObject Hostile;
    public Transform player;
    public bool isFlipped = false;
    public Transform EnemyAttackPoint;
    public bool isInvulnerable = false;

    public int attackDamage = 20;
    public int enragedAttackDamage = 30;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Transform attackPoint;

    public void EnemyAttack()
    {
        SoundManager.soundManager.enemyAttackSound();
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(EnemyAttackPoint.position, attackRange, attackMask);
        if (colInfo != null)
        {
            SoundManager.soundManager.playHitSound();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    public void EnragedEnemyAttack()
    {
        SoundManager.soundManager.enemyAttackSound();
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        //ShootSlashEffect.shootSlash.Shoot();

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            SoundManager.soundManager.playHitSound();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player").transform;
        gameObject.GetComponent<GhostSprites>().enabled = false;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        currentHealth -= damage;
        StartCoroutine(DamageAnimation());

        if(currentHealth <= 300)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
            //gameObject.GetComponent<GhostSprites>().enabled = true;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }


    void Die()
    {
        Debug.Log("적이 죽었습니다");

        anim.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        this.enabled = false;
        Destroy(Hostile, 5);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
