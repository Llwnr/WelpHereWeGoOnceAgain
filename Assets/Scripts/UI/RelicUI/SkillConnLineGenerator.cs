using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConnLineGenerator : MonoBehaviour
{
    private List<Transform> connections = new List<Transform>();
    [SerializeField]private GameObject linePrefab;

    private void Start() {
        RelicSkillManager relicSkillManager = GetComponent<RelicSkillManager>();
        foreach(Transform myTransform in relicSkillManager.GetRequiredNodesTransform()){
            connections.Add(myTransform);
        }

        foreach(Transform target in connections){
            GameObject newLine = Instantiate(linePrefab, Vector2.zero, Quaternion.identity);
            newLine.transform.SetParent(transform.parent, false);
            newLine.GetComponent<SkillConnectionLine>().SetConnection(target, transform);
            newLine.transform.SetAsFirstSibling();
        }
    }
}
