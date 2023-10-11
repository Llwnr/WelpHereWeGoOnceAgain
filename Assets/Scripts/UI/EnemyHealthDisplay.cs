using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    [SerializeField]private Image hpBar;
    [SerializeField]private Transform boss;
    private EnemyHpManager healthManager;
    private int currHp, maxHp;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = boss.GetComponent<EnemyHpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.GetHpData(out currHp, out maxHp);
        hpBar.fillAmount = (float)currHp/(float)maxHp;
    }
}
