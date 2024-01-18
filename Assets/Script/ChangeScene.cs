using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadTargetScene()
    {
        // SceneManager'ın LoadScene metoduyla hedef sahneye geçiş yap
        SceneManager.LoadScene("SampleScene");
    }
}
