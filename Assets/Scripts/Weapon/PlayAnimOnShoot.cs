using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnShoot : MonoBehaviour, IOnAttack
{
    private Animator animator;

    public void OnAttack()
    {
        animator.Play("Shoot");
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<WeaponManager>().AddOnAttackListener(this);
    }
}
