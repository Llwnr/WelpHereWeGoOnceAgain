using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHealthInfo : MonoBehaviour
{
    [SerializeField]private Image hpBar;
    [SerializeField]private TextMeshProUGUI textbox;
    private HealthManager playerHealthManager;
    private int currHp, maxHp;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthManager.GetHpData(out currHp, out maxHp);
        hpBar.fillAmount = (float)currHp/(float)maxHp;
        textbox.text = currHp.ToString() + " | " + maxHp.ToString();
    }
}
