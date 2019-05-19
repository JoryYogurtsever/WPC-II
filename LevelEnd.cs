using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;
    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;
    public float waitToMove;
    public float waitToLoad;
    private bool movePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        movePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(movePlayer)
        {
            thePlayer.myRigidbody.velocity = new Vector3(0f, thePlayer.moveSpeed, 0f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("LevelEndCo");
        }
    }
    
    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;
        theCamera.followTarget = false;
        theLevelManager.invincible = true;
        
        theLevelManager.levelMusic.Stop();
        
        thePlayer.myRigidbody.velocity = Vector3.zero;
        
        PlayerPrefs.SetInt("CoinCount", theLevelManager.coinCount);
        PlayerPrefs.SetInt("YogurtCount", theLevelManager.yogurtCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("InfinityCount", theLevelManager.infinityCount);
        
        yield return new WaitForSeconds(waitToMove);
        
        movePlayer = true;
        
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
