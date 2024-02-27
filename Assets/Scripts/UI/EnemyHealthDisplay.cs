using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    [SerializeField]private Image hpBar;
    [SerializeField]private Transform boss;
    [SerializeField]private float lerpDuration;
    private EnemyHpManager healthManager;
    private int currHp, maxHp, recentHp;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = boss.GetComponent<EnemyHpManager>();
        healthManager.GetHpData(out currHp, out recentHp);
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.GetHpData(out currHp, out maxHp);
        if(recentHp != currHp){
            LeanTween.cancel(gameObject);
            LeanTween.value(gameObject, SetHpBarSmoothly, recentHp, currHp, lerpDuration).setEaseOutQuad();
            recentHp = currHp;
        }
    }

    void SetHpBarSmoothly(float amt){
        hpBar.fillAmount = amt/maxHp;
    }
}
