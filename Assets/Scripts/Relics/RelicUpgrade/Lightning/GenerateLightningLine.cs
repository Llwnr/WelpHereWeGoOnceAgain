using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GenerateLightningLine : MonoBehaviour
{
    private Vector2 currPos;
    private Vector2 finalPos;

    public void SetTargetPos(Vector2 finalPos){
        currPos = transform.position;
        this.finalPos = finalPos;
        LookToTarget();
        ManageLightningLength();
        RandomizeLightningAnim();
    }

    void LookToTarget(){
        Vector2 dir = (finalPos - currPos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //Since we're working with 3d plane, rotate x axis instead
        angle *= -1;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y , transform.eulerAngles.z);
    }

    //Arrange the length of lightning to fit exactly from player to target
    void ManageLightningLength(){
        //Set lightning pivot to middle of player and target
        transform.position = ((Vector2)transform.position + finalPos)*0.5f;

        //Find required distance of lightning
        float dist = Vector2.Distance(currPos, finalPos);
        Mesh planeMesh = GetComponent<MeshFilter>().mesh;
        float planeLength = planeMesh.bounds.size.x;//The original size of lightning
        //To set to required length
        float divisor = planeLength / dist;
        transform.localScale = new Vector3(transform.localScale.x/divisor, transform.localScale.y, transform.localScale.z);
    }

    //Generate different wavelength/frequency of lightning
    void RandomizeLightningAnim(){
        GetComponent<MeshRenderer>().material.SetFloat(Shader.PropertyToID("_RandomizedLightning"), Random.Range(0f,1f));
    }
}
