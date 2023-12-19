using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        audioManager.PlaySFX(audioManager.boss_attack);
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        FindObjectOfType<PlayerStats>().TakeDamage(attackDamage);
        //Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        //if (colInfo != null)
        //{
        //}
    }

    public void EnragedAttack()
    {
        audioManager.PlaySFX(audioManager.boss_attack);
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        FindObjectOfType<PlayerStats>().TakeDamage(enragedAttackDamage);

        //Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        //if (colInfo != null)
        //{
        //    colInfo.GetComponent<PlayerStats>().TakeDamage(enragedAttackDamage);
        //}
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
