using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDashReload : MonoBehaviour
{
    [SerializeField]private DashManager dashData;
    private Image img;

    private void Start() {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = dashData.GetReloadPercentage();
    }
}
