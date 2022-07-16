using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IKillable
{
    DamageableComponent damageableComponent;

    // Start is called before the first frame update
    void Start()
    {
        damageableComponent = this.gameObject.AddComponent<DamageableComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die() { Destroy(this.gameObject);  }
    public void NotifyDamage() { }
}
