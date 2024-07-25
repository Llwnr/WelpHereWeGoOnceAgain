using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayWin : MonoBehaviour
{
    [SerializeField]private GameObject winImg;
    [SerializeField]private AutoGenerateEnemy generateEnemy;
    [SerializeField]private GameObject bossPrefab;
    [SerializeField]private ParticleSystem winParticle;
    private GameObject boss;

    [Header("Boss Summon Time")]
    [SerializeField]private float maxMin, maxSec;

    private bool bossCreated = false;
    private bool gameWon = false;
    // Update is called once per frame
    void Update()
    {
        if(gameWon) return;
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
            winParticle.Play();
            StartCoroutine(YouWon());
            gameWon = true;
        }
    }

    IEnumerator YouWon(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
