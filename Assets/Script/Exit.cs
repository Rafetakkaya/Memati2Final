using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Escape tuşuna basıldığında oyunu kapat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        // Oyunu kapat
        Application.Quit();
    }
}
