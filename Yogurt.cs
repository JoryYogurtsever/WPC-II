using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yogurt : MonoBehaviour
{
    public bool isYogurting;
    private Animator myAnim;
    public PlayerController thePlayerBody;
//     public Vector3 playerVelocity;
    public float yogurtingDelay;
    
    // Start is called before the first frame update
    void Start()
    {
            thePlayerBody = FindObjectOfType<PlayerController>();
            myAnim = GetComponent<Animator>();
//             gameObject.SetActive(false);
//             playerVelocity = new Vector3 (0f, 0f, 0f);
            isYogurting = false;
    }

    // Update is called once per frame
    void Update()
    {
//         playerVelocity = new Vector3
//         Debug.Log(thePlayerBody.playerVelocity); 
//         if(!isYogurting)
//         {
//             gameObject.SetActive(false);
//         }
//         {
//             transform.localScale = new Vector3(-0.59983f, 0.59983f, 0.59983f);
//         }
//         if(Input.GetAxisRaw ("Horizontal") < 0f)
//         {
//             transform.localScale = new Vector3(0.59983f, 0.59983f, 0.59983f);
//         }
        if(Input.GetButtonDown ("Jump")) //will use this control for attacking
        { 
//             gameObject.SetActive(true);
            isYogurting = true;
            StartCoroutine("YogurtingCo");
        }
        myAnim.SetFloat("Horizontal Speed", thePlayerBody.playerHorizontalVelocity);
        myAnim.SetFloat("Vertical Speed", thePlayerBody.playerVerticalVelocity);
        myAnim.SetBool("attacking", isYogurting);
    }
    public IEnumerator YogurtingCo()
    {
        yield return new WaitForSeconds(yogurtingDelay);
        isYogurting = false;
//         gameObject.SetActive(false);
    }
    
//     public void FindVelocity(float newPlayerX, float newPlayerY, float newPlayerZ)
//     {
//         playerVelocity = new Vector3(newPlayerX, newPlayerY, newPlayerZ);
//     }

}
