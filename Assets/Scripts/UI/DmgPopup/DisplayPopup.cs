using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPopup : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private DmgPopup dmgPopup;
    private Transform popupContainer, player;

    private void Start() {
        GetComponent<EnemyHpManager>().AddOnDamageListener(this);
        popupContainer = GameObject.FindWithTag("PopupContainer").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    //Create damage popup
    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        //Make the popup
        DmgPopup newDmgPopup = Instantiate(dmgPopup, transform.position, Quaternion.identity);
        newDmgPopup.SetDmgAmt(dmgAmt);
        //Make popup slide slightly near player
        newDmgPopup.SetSlideDir(player.position-transform.position);
        //Set its position to popupContainer in canvas
        newDmgPopup.transform.SetParent(popupContainer, false);
    }
}
