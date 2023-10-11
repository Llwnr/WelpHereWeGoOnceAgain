using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphManager : MonoBehaviour
{
    //The object that will allow user to know where boss is going to hit
    //Boss attack anticipation basically
    [SerializeField]private List<GameObject> telegraphAnims = new List<GameObject>();

    private void Start() {
        StopTelegraph();
    }

    public void CreateTelegraphs(int numOfTelegraphs, GameObject telegraphAnim, Vector3 scale){
        //Create telegraphs based on the angles that enemy will throw
        if(telegraphAnims.Count>0){
            StartTelegraph();
            return;
        }

        for(int i=0; i<numOfTelegraphs; i++){
            GameObject newTelegraph = Instantiate(telegraphAnim, transform.position, Quaternion.identity);
            newTelegraph.transform.SetParent(transform, false);
            newTelegraph.transform.localPosition = Vector2.zero;
            newTelegraph.transform.localScale = scale;
            newTelegraph.transform.localEulerAngles = new Vector3(0,0, i*360f/numOfTelegraphs);
            telegraphAnims.Add(newTelegraph);
        }

        StartTelegraph();
    }
    
    public void StartTelegraph(){
        foreach(GameObject telegraph in telegraphAnims){
            telegraph.SetActive(true);
        }
    }

    public void StopTelegraph(){
        foreach(GameObject telegraph in telegraphAnims){
            Destroy(telegraph);
        }
        telegraphAnims.Clear();
    }
}
