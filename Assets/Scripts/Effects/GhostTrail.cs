using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour, IOnDash
{
    bool activateTrail = false;
    [SerializeField]public float distThreshold, fadeDuration;
    private float timer;
    [SerializeField]private GameObject trailMaterial;

    private Vector2 startingDist, currDist;

    private void Start() {
        startingDist = transform.position;
        GetComponent<DashManager>().AddDashListener(this);
    }

    private void Update() {
        if(!activateTrail) return;

        currDist = transform.position;
        //Check if player has traveled certain distance. If yes then create the trail at the threshold
        while(Vector2.Distance(currDist, startingDist) >= distThreshold){
            //To set starting dist to start of new threshold
            Vector2 dir = (currDist - startingDist).normalized;
            startingDist += dir*distThreshold;
            CreateTrail(startingDist);
        }
    }

    //Creates one instance of a trail
    void CreateTrail(Vector2 position){
        GameObject newTrail = Instantiate(trailMaterial, position, Quaternion.identity);
        LeanTween.alpha(newTrail, 0f, fadeDuration);
    }

    public void OnDashStart()
    {
        activateTrail = true;
        startingDist = transform.position;
        CreateTrail(transform.position);
    }

    public void OnDashEnd()
    {
        activateTrail = false;
        CreateTrail(transform.position);
    }
}
