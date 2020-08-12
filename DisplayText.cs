using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public GameObject ansText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.getDisplayAns())
        {
            ansText.gameObject.SetActive(true);
        }
        else
        {
            ansText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
