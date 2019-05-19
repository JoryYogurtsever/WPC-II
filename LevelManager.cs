using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayerBody;
    public PlayerHeadController thePlayerHead;
    public Yogurt theYogurt;
    
    public GameObject deathSplosion;
    public int coinCount;
    public int yogurtCount;
    public int livesCount;
    
    private bool respawning;
    
    public Text coinText;
    public Text yogurtText;
    public Text livesText;
    public AudioSource coinSound;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    
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
    
    public ResetOnRespawn[] objectsToReset;
    public bool invincible;
    public int currentLives;
    public int startingLives;
    
    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayerBody = FindObjectOfType<PlayerController>();
        thePlayerHead = FindObjectOfType<PlayerHeadController>();
        theYogurt = FindObjectOfType<Yogurt>();
        
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        else
        {
            coinCount = 0;
        }
        if (PlayerPrefs.HasKey("YogurtCount"))
        {
            yogurtCount = PlayerPrefs.GetInt("YogurtCount");
        }
        else
        {
            yogurtCount = 0;
        }
        if (PlayerPrefs.HasKey("InfinityCount"))
        {
            infinityCount = PlayerPrefs.GetInt("InfinityCount");
        }
        else
        {
            infinityCount = -1;
        }
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            currentLives = startingLives;
        }
        coinText.text = coinCount.ToString();
        yogurtText.text = yogurtCount.ToString();
        livesText.text = livesCount.ToString();
        
        healthCount = maxHealth;
//         infinityCount = -1;
        
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
//         currentLives = startingLives;
        livesText.text = currentLives.ToString();
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
        thePlayerBody.knockbackCounter = 0f;
        currentLives -= 1;
        livesText.text = currentLives.ToString();
        
        if(currentLives > 0f)
        {
            StartCoroutine("RespawnCo");
        } else {
        thePlayerBody.gameObject.SetActive(false);
        thePlayerHead.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        levelMusic.Stop();
        gameOverMusic.Play();
        Instantiate(deathSplosion, thePlayerBody.transform.position, new Quaternion(90f, 0f, 0f, 90f));
        }
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
        theYogurt.transform.position = theYogurt.yogurtRespawnPosition;
        theYogurt.isYogurting = false;
        thePlayerBody.gameObject.SetActive(true);
        thePlayerHead.gameObject.SetActive(true);
        
        for(int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }
    
    public void AddCoins(int coinsToAdd, int yogurtToAdd)
    {
        coinCount += coinsToAdd;
        yogurtCount += yogurtToAdd;
        coinText.text = coinCount.ToString();
        yogurtText.text = yogurtCount.ToString();
        coinSound.Play();
//         livesText.text = livesCount.ToString();
    }
    
    public void HurtPlayer (int damageToTake)
    {
        if(!invincible)
        {
            thePlayerBody.hurtSound.Play();
            healthCount -= damageToTake; 
            UpdateHeartMeter();
            
            thePlayerBody.Knockback();
        }
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
