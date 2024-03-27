using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class KnockbackOnShoot : MonoBehaviour, IOnAttack
{
    private Rigidbody2D rb;
    [SerializeField]private float force;
    void Start() {
        WeaponManager.instance.AddOnAttackListener(this);
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnAttack()
    {
        Vector2 dir = GetAtkDirection();
        rb.AddForce(-dir*force, ForceMode2D.Impulse);
    }

    Vector2 GetAtkDirection(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos-(Vector2)transform.position;
    }
}
