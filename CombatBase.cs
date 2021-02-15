using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatBase : MonoBehaviour
{
    public float health = 100f;
    public float damage = 50f;
    List<CombatBase> enemiesInRadius;
    
    void Start()
    {
        enemiesInRadius = new List<CombatBase>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!CompareTag(collision.gameObject.tag))
        {
            CombatBase enemy = collision.gameObject.GetComponent<CombatBase>();
            if (enemy && !enemiesInRadius.Contains(enemy))
            {
                enemiesInRadius.Add(enemy);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!CompareTag(collision.gameObject.tag))
        {
            CombatBase enemy = collision.gameObject.GetComponent<CombatBase>();
            if (enemy && enemiesInRadius.Contains(enemy))
            {
                enemiesInRadius.Remove(enemy);
            }
        }
    }
    public void TryAttack()
    {
        enemiesInRadius.RemoveAll(item => item == null);

        if (enemiesInRadius.Count() == 0)
        {
            return;
        }

        enemiesInRadius = enemiesInRadius.OrderBy((x) => Vector3.Distance(enemiesInRadius[0].transform.position, this.transform.position)).ToList();
        enemiesInRadius[0].TakeDamage(damage);
    }
    void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Someone has died");
        }
    }
}
