using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float lifes;

    private Animator anim;
    private PatrollSystem patroll;
    private CombatSystem combat;
    private Transform target;

    private float actualLifes;
    private bool isDeath;

    public PatrollSystem Patroll { get => patroll; set => patroll = value; }
    public CombatSystem Combat { get => combat; set => combat = value; }
    public Transform Target { get => target; set => target = value; }

    private void Awake()
    {
        lifes = actualLifes;
    }
    void Start()
    {
        patroll.enabled = true;
    }
    public void ActiveCombat(Transform target)
    {
        this.target = target;

        combat.enabled = true;
    }
    public void ActivePatroll()
    {
        combat.enabled = false;
        patroll.enabled = true;
    }
    private void Death()
    {
        Destroy(combat);
        Destroy(patroll.gameObject);
        anim.SetTrigger("Death");
    }
}
