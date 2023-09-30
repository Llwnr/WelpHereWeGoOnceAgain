using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLevelinfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textBox;

    // Update is called once per frame
    void Update()
    {
        textBox.text = PlayerLevelManager.level.ToString();
    }
}
