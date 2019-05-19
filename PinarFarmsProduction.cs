using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinarFarmsProduction : MonoBehaviour
{
    private LevelManager theLevelManager;
    public GameObject yogurt1;
    public GameObject yogurt2;
    public GameObject yogurt3;
    public GameObject yogurt4;
    public GameObject yogurt5;
    public GameObject yogurt6;
    public GameObject yogurt7;
    public GameObject yogurt8;
    public GameObject yogurt9;
    public GameObject yogurt10;
    public GameObject yogurt11;
    public GameObject yogurt12;
    public GameObject yogurt13;
    public GameObject yogurt14;
    public GameObject yogurt15;
    public GameObject yogurt16;
    public GameObject yogurt17;
    public GameObject yogurt18;


    
    public GameObject[] yogurtsToRespawn;
    
    public float pinarYogurtDelay;

    // Start is called before the first frame update
    void Start()
    {
        yogurtsToRespawn = new GameObject[18];
        yogurtsToRespawn[0] = yogurt1;
        yogurtsToRespawn[1] = yogurt2;
        yogurtsToRespawn[2] = yogurt3;
        yogurtsToRespawn[3] = yogurt4;
        yogurtsToRespawn[4] = yogurt5;
        yogurtsToRespawn[5] = yogurt6;
        yogurtsToRespawn[6] = yogurt7;
        yogurtsToRespawn[7] = yogurt8;
        yogurtsToRespawn[8] = yogurt9;
        yogurtsToRespawn[9] = yogurt10;
        yogurtsToRespawn[10] = yogurt11;
        yogurtsToRespawn[11] = yogurt12;
        yogurtsToRespawn[12] = yogurt13;
        yogurtsToRespawn[13] = yogurt14;
        yogurtsToRespawn[14] = yogurt15;
        yogurtsToRespawn[15] = yogurt16;
        yogurtsToRespawn[16] = yogurt17;
        yogurtsToRespawn[17] = yogurt18;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < yogurtsToRespawn.Length; i++)
        {
            if(yogurtsToRespawn[i].gameObject.activeSelf == false)
            {
                StartCoroutine("PinarYogurtCo", yogurtsToRespawn[i]);
            }
        }
    }
    public IEnumerator PinarYogurtCo(GameObject speskyYogurt)
    {
        yield return new WaitForSeconds(pinarYogurtDelay);
        speskyYogurt.gameObject.SetActive(true);
    }
}
