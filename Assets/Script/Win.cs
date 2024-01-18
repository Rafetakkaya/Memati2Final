using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void Update()
    {
        // Oyun kazanma koşulunu kontrol et
        if (AllEnemiesAreDead())
        {
            SceneManager.LoadScene("Win");


        }
    }

    bool AllEnemiesAreDead()
    {
        // "Enemy" tag'ine sahip tüm GameObject'leri bul
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Eğer hiç düşman kalmadıysa true döndür, aksi halde false
        return enemies.Length == 0;
    }
}
