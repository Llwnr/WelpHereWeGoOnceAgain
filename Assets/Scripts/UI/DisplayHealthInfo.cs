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
    [SerializeField]private int currHp, maxHp, recentHp;
    [SerializeField]private float lerpDuration;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        playerHealthManager.GetHpData(out currHp, out recentHp);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthManager.GetHpData(out currHp, out maxHp);
        //Slowly reduce the hp bar graphically only when current hp changes
        if(currHp != recentHp) {
            LeanTween.cancel(gameObject);
            LeanTween.value(gameObject, SetHpBarSmoothly, recentHp, currHp, lerpDuration).setEaseOutExpo();
            recentHp = currHp;
        }
    }

    void SetHpBarSmoothly(float amt){
        hpBar.fillAmount = amt/maxHp;
        textbox.text = amt.ToString("F0") + " | " + maxHp.ToString();
    }
}
