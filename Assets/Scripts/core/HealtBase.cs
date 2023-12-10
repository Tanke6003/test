using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float maxHealt = 100;
    [SerializeField] protected float currentHealt = 100;

    public float Healt { get; protected set; }
    void Start()
    {
        Healt = currentHealt;
    }

    public void TakeDamage(float damage)
    {
        if(damage <= 0)
            return;
        if(Healt > 0){
            Healt -= damage;
            UpdateLifeValue(Healt, maxHealt);
            if(Healt <= 0){
                UpdateLifeValue(Healt, maxHealt);
                Die();
            }
            
        }
        
    }
    protected virtual void UpdateLifeValue(float healt, float maxHealt)
    {
        
    }
    protected virtual void Die()
    {
        
    }
}
