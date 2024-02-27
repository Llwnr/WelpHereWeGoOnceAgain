using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWin : MonoBehaviour
{
    [SerializeField]private GameObject winImg;
    [SerializeField]private AutoGenerateEnemy generateEnemy;
    [SerializeField]private GameObject bossPrefab;
    private GameObject boss;

    [Header("Boss Summon Time")]
    [SerializeField]private float maxMin, maxSec;

    private bool bossCreated = false;
    // Update is called once per frame
    void Update()
    {
        int min, sec;
        TimeManager.GetTimeInMinutes(out min, out sec);

        if(min >= maxMin && sec >= maxSec && !bossCreated){
            //Create boss after 5 mins of gameplay
            boss = Instantiate(bossPrefab, Vector2.zero, Quaternion.identity);
            bossCreated = true;
            generateEnemy.enabled = false;
        }

        //If boss dead then show win screen
        if(bossCreated && !boss){
            winImg.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
