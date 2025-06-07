using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private Enemy mainScript;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float combatVelocity;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDamage;
    [SerializeField] private float detectionRadius;
    [SerializeField] private Animator anim;

    private bool isAttacking = false;

    private void Awake()
    {
        mainScript.Combat = this;
    }
    private void OnEnable()
    {
        agent.speed = combatVelocity;
        agent.stoppingDistance = attackDistance;
    }
    void Update()
    {
        if (mainScript.Target != null && mainScript.Target.gameObject.activeSelf)
        {
            float distanceToTarget = Vector3.Distance(transform.position, mainScript.Target.position);

            // Verificar si el objetivo está dentro del rango de detección
            if (distanceToTarget <= detectionRadius)
            {
                // Perseguir al objetivo
                AimObjetive();
                agent.SetDestination(mainScript.Target.position);

                // Verificar si está dentro de la distancia para atacar
                if (!agent.pathPending && agent.remainingDistance <= attackDistance)
                {
                    if (!isAttacking)
                    {
                        anim.SetBool("isAttacking", true);
                        isAttacking = true;
                    }
                }
                else if (isAttacking)
                {
                    anim.SetBool("isAttacking", false);
                    isAttacking = false;
                }
            }
            else
            {
                // El objetivo está fuera del rango de detección, volver a patrullar
                ExitCombat();
            }
        }
        else
        {
            // El objetivo es nulo o inválido, volver a patrullar
            ExitCombat();
        }
    }

    private void AimObjetive()
    {
        Vector3 targetDirection = (mainScript.Target.position - transform.position).normalized;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = targetRotation;
    }
    private void ExitCombat()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
        mainScript.Target = null; // El objetivo deja de ser válido
        mainScript.ActivePatroll();
    }
    #region Eventos Animacion
    private void StartAttack()
    {
        if (mainScript.Target != null)
        {
            Debug.Log("Ataca");
        }
    }
    private void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
        Debug.Log("Para de atacar");
    }
    #endregion
}
