using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoGenerateEnemy : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemies;
    [SerializeField]private List<GameObject> rarerEnemies;
    [SerializeField]private float rareEnemyProc, radius, generationTimer;
    private float extraRareProcChance = 0;//To increase the chance of generating rare enemies if no rare enemy is generated
    [SerializeField]private float rareChanceInc;
    [SerializeField]private float randomTime;
    [SerializeField]private Transform enemyHolder;

    public float maxGameTime;

    //For generating enemies inside the given boundary
    [SerializeField]private Tilemap boundary;
    private float xLeft, xRight, yLeft, yRight;

    private float realTimeCount = 0;//Take note of time passed since game started
    private float timerCount;

    private void Start() {
        ResetTimer();

        GetBoundaryPoints();
    }

    void GetBoundaryPoints(){
        float xSize = boundary.size.x;
        float ySize = boundary.size.y;
        xLeft = boundary.transform.position.x - xSize/2;
        xRight = boundary.transform.position.x + xSize/2;
        yLeft = boundary.transform.position.y - ySize/2;
        yRight = boundary.transform.position.y + ySize/2;
    }

    void ResetTimer(){
        randomTime = Random.Range(-randomTime, randomTime);
        timerCount = generationTimer+randomTime;
    }

    private void Update() {
        realTimeCount += Time.deltaTime;
        timerCount -= Time.deltaTime;
        if(timerCount <= 0){
            ResetTimer();
            GenerateEnemy();
        }
    }

    void GenerateEnemy(){
        float maxTime = maxGameTime/enemies.Count;
        float rareMaxTime = maxGameTime/rarerEnemies.Count;
        float time = Time.timeSinceLevelLoad;
        Vector2 generatedPos = GenerateRandomPosAtEdgeOfCircle();
        //Higher chance to pick next array enemy as time goes on
        int enemyIndex = Mathf.Min(enemies.Count-1, Mathf.FloorToInt(Random.Range(0.5f, 1f) * time/maxTime));
        int rareEnemyIndex = Mathf.Min(rarerEnemies.Count-1, Mathf.FloorToInt(Random.Range(0.5f, 1f) * time/rareMaxTime));

        GameObject newEnemy = Instantiate(enemies[enemyIndex], generatedPos, Quaternion.identity);
        newEnemy.transform.SetParent(enemyHolder, false);
        //Generate a rare monster at the given chance proc
        if(Random.Range(0f,1) < (rareEnemyProc+extraRareProcChance)){
            newEnemy = Instantiate(rarerEnemies[rareEnemyIndex], GenerateRandomPosAtEdgeOfCircle(), Quaternion.identity);
            newEnemy.transform.SetParent(enemyHolder, false);
            extraRareProcChance = 0;
        }else{
            //If no rare enemy generated, increase the chance by 1%
            extraRareProcChance += rareChanceInc;
        }
    }

    Vector2 GenerateRandomPosAtEdgeOfCircle(){
        //Make sure the point is within boundary
        Vector2 finalPoint;
        do{
            Ray2D ray = new Ray2D(transform.position, Random.onUnitSphere);
            finalPoint = ray.GetPoint(radius)*Random.Range(0.6f,1f);
        }while(finalPoint.x < xLeft || finalPoint.x > xRight || finalPoint.y < yLeft || finalPoint.y > yRight);
        return finalPoint;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
