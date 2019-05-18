using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayerBody;
    public PlayerHeadController thePlayerHead;
    
    public GameObject deathSplosion;
    public int coinCount;
    public int yogurtCount;
    public int livesCount;
    
    private bool respawning;
    
    public Text coinText;
    public Text yogurtText;
    public Text livesText;
    
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image infinityGauntlet;
    
    public Sprite heartFull;
    public Sprite heartEmpty;
    public Sprite noig;
    public Sprite ig0;
    public Sprite ig1;
    public Sprite ig2;
    public Sprite ig3;
    public Sprite ig4;
    public Sprite ig5;
    public Sprite ig6;

    public int maxHealth;
    public int healthCount;
    public int infinityCount;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayerBody = FindObjectOfType<PlayerController>();
        thePlayerHead = FindObjectOfType<PlayerHeadController>();
        
        coinText.text = coinCount.ToString();
        yogurtText.text = yogurtCount.ToString();
        livesText.text = livesCount.ToString();
        
        healthCount = maxHealth;
        infinityCount = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
    }
    
    public void Respawn() 
    {
        StartCoroutine("RespawnCo");
    }
    
    public IEnumerator RespawnCo()
    {
        thePlayerBody.gameObject.SetActive(false);
        thePlayerHead.gameObject.SetActive(false);
        
        Instantiate(deathSplosion, thePlayerBody.transform.position, new Quaternion(90f, 0f, 0f, 90f));
            
        yield return new WaitForSeconds(waitToRespawn);
        
        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter();
        
        thePlayerBody.transform.position = thePlayerBody.bodyRespawnPosition;
        thePlayerHead.transform.position = thePlayerHead.headRespawnPosition;
        thePlayerBody.gameObject.SetActive(true);
        thePlayerHead.gameObject.SetActive(true);
    }
    
    public void AddCoins(int coinsToAdd, int yogurtToAdd)
    {
        coinCount += coinsToAdd;
        yogurtCount += yogurtToAdd;
        coinText.text = coinCount.ToString();
        yogurtText.text = yogurtCount.ToString();
//         livesText.text = livesCount.ToString();
    }
    
    public void HurtPlayer (int damageToTake)
    {
        healthCount -= damageToTake; 
        UpdateHeartMeter();
    }
    
    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 3: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            case 2: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            case 1: 
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 0: 
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }
    public void InfinityGauntletMeter()
    {
        infinityCount += 1;
        switch(infinityCount)
        {
            case 6:
                infinityGauntlet.sprite = ig6;
                return;
            case 5:
                infinityGauntlet.sprite = ig5;
                return;
            case 4:
                infinityGauntlet.sprite = ig4;
                return;
            case 3:
                infinityGauntlet.sprite = ig3;
                return;
            case 2:
                infinityGauntlet.sprite = ig2;
                return;
            case 1:
                infinityGauntlet.sprite = ig1;
                return;
            case 0:
                infinityGauntlet.sprite = ig0;
                return;
            case -1:
                infinityGauntlet.sprite = noig;
                return;
            default:
                infinityGauntlet.sprite = noig;
                return;
        }
    }
}
