﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackBtn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreditsBtn()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
