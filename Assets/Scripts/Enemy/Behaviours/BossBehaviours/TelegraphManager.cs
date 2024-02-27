using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphManager : MonoBehaviour
{
    //The object that will allow user to know where boss is going to hit
    //Boss attack anticipation basically
    [SerializeField]private List<GameObject> telegraphAnims = new List<GameObject>();
    [SerializeField]private Transform pivot;

    Vector2 scale;
    float duration;

    private void Start() {
        StopTelegraph();
    }

    public void CreateTelegraphs(int numOfTelegraphs, GameObject telegraphAnim, Vector3 scale, float duration){
        this.scale = scale;
        this.duration = duration;
        //Create telegraphs based on the angles that enemy will throw
        if(telegraphAnims.Count>0){
            StartTelegraph();
            return;
        }
        //If no telegraphs exist previously, then create new telegraphs
        for(int i=0; i<numOfTelegraphs; i++){
            GameObject newTelegraph = Instantiate(telegraphAnim, transform.position, Quaternion.identity);
            newTelegraph.transform.SetParent(pivot, false);
            newTelegraph.transform.localPosition = new Vector3(0,0);

            GrowTelegraph(newTelegraph);
            // newTelegraph.transform.localEulerAngles = new Vector3(0,0, i*360f/numOfTelegraphs);
            telegraphAnims.Add(newTelegraph);
        }
    }
    
    public void StartTelegraph(){
        foreach(GameObject telegraph in telegraphAnims){
            telegraph.SetActive(true);
            GrowTelegraph(telegraph);
        }
    }

    void GrowTelegraph(GameObject telegraph){
        telegraph.transform.localPosition = new Vector3(0,0);
        telegraph.transform.localScale = new Vector3(scale.x, 1);
        //Increase y scale as in grow the anticipation box gradually
        LeanTween.scaleY(telegraph, scale.y, duration).setEaseOutCubic();
        LeanTween.moveLocalY(telegraph, (scale.y*0.5f)-0.5f, duration).setEaseOutCubic();
    }

    public void StopTelegraph(){
        foreach(GameObject telegraph in telegraphAnims){
            telegraph.SetActive(false);
        }
    }
}
