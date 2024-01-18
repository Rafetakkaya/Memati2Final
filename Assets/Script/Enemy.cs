using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    private NavMeshAgent navAgent;
    bool isDead;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }
    public void TakeDamage(int damageAmount)
    {
        // Düşmanın canını güncelle
        HP -= damageAmount;
        Debug.Log(HP);

        // Düşman canı 0 veya daha küçükse
        if (HP <= 0)
        {
            // Eğer daha önce ölmediyse
            if (HP <= 0)
            {
                isDead = true; // Düşmanın öldüğünü işaretle

                int randomValue = Random.Range(0, 2);
                if (randomValue == 0)
                {
                    Debug.Log("Birinci"+randomValue);
                    animator.SetTrigger("DIE1");
                    Destroy(gameObject, 5);
                }
                else
                {
                    Debug.Log("ikiinci" + randomValue);
                    animator.SetTrigger("DIE1");
                    Destroy(gameObject, 5);
                }
            }
        }
        else
        {
            // Düşman canı 0'dan büyükse sadece hasar animasyonunu oynat
            animator.SetTrigger("DAMAGE");
        }
    }

    private void Update() {
        if(navAgent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isPatrolling", true);

        }
        else
        {
            animator.SetBool("isPatrolling", false);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,  2.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 18f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 21f);


    }
}
