﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private LevelManager theLevelManager;
    public int coinValue;
    public int yogurtValue;
    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddCoins(coinValue, yogurtValue);
            gameObject.SetActive(false);        }
    }
}
