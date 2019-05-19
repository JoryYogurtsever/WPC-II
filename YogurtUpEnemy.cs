using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YogurtUpEnemy : MonoBehaviour
{
    public GameObject deathSplosion;
    public AudioSource yogurtSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            yogurtSound.Play();
            Instantiate(deathSplosion, other.transform.position, new Quaternion(90f, 0f, 0f, 90f));
            other.gameObject.SetActive(false);
        }
    }
}
