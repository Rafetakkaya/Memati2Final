using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int HP = 100;
    bool isDead;
   
    public void TakeDamage(int damageAmount)
    {
        // Düşmanın canını güncelle
        HP -= damageAmount;
        Debug.Log(HP);

        // Düşman canı 0 veya daha küçükse
        if (HP <= 0)
        {
            // Eğer daha önce ölmediyse
            print("player dead");
            SceneManager.LoadScene("LastScreen");

        }
        else
        {
            // Düşman canı 0'dan büyükse sadece hasar animasyonunu oynat
            print("player hit");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
           TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
        }
    }

}
