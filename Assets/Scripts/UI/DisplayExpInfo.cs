using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayExpInfo : MonoBehaviour
{
    [SerializeField]private Image expBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expBar.fillAmount = PlayerLevelManager.expAmt/PlayerLevelManager.expForNextLevel;
    }
}
