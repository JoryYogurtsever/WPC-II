using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public GameObject newMessage;
    public float readTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            newMessage.SetActive(true);
            StartCoroutine("DisplayTextCo");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator DisplayTextCo()
    {
        yield return new WaitForSeconds(readTime);
        newMessage.SetActive(false);
    }

}
