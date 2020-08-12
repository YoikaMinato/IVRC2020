using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンをクリックするとワールドツアー画面へ戻る関数
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
