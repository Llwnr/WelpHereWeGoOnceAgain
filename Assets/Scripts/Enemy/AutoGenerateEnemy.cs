using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AutoGenerateEnemy : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    [SerializeField]private float radius, generationTimer, randomTime;
    private float timerCount;

    private void Start() {
        ResetTimer();
    }

    void ResetTimer(){
        randomTime = Random.Range(-randomTime, randomTime);
        timerCount = generationTimer+randomTime;
    }

    private void Update() {
        timerCount -= Time.deltaTime;
        if(timerCount <= 0){
            ResetTimer();
            Vector2 generatedPos = GenerateRandomPosAtEdgeOfCircle();
            Instantiate(enemy, generatedPos, Quaternion.identity);
        }
    }

    Vector2 GenerateRandomPosAtEdgeOfCircle(){
        Ray2D ray = new Ray2D(transform.position, Random.onUnitSphere);
        return ray.GetPoint(radius);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
