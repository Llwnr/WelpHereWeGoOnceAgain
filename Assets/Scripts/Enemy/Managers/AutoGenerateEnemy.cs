using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AutoGenerateEnemy : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemies;
    [SerializeField]private List<GameObject> rarerEnemies;
    [SerializeField]private float radius, generationTimer, randomTime;

    //For generating enemies inside the given boundary
    [SerializeField]private SpriteRenderer boundary;
    private float xLeft, xRight, yLeft, yRight;

    private int resetCount = 0;//To take note of how many times enemy is generated
    private float realTimeCount = 0;//Take note of time passed since game started
    private float timerCount;

    private void Start() {
        ResetTimer();

        GetBoundaryPoints();
    }

    void GetBoundaryPoints(){
        float xSize = boundary.sprite.bounds.size.x;
        float ySize = boundary.sprite.bounds.size.y;
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
            resetCount++;
            ResetTimer();
            Vector2 generatedPos = GenerateRandomPosAtEdgeOfCircle();
            //Instantiate(enemies[(int)realTimeCount/20], generatedPos, Quaternion.identity);
            Instantiate(enemies[0], generatedPos, Quaternion.identity);
            //Every 5th normal generation generate a rare monster
            if(resetCount % 7 == 0){
                Instantiate(rarerEnemies[0], GenerateRandomPosAtEdgeOfCircle(), Quaternion.identity);
            }
            
        }
    }

    Vector2 GenerateRandomPosAtEdgeOfCircle(){
        //Make sure the point is within boundary
        Vector2 finalPoint;
        do{
            Ray2D ray = new Ray2D(transform.position, Random.onUnitSphere);
            finalPoint = ray.GetPoint(radius)*Random.Range(0.75f,1.5f);
        }while(finalPoint.x < xLeft || finalPoint.x > xRight || finalPoint.y < yLeft || finalPoint.y > yRight);
        return finalPoint;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
