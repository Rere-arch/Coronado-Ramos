using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f;

    void OnCollisionEnter(Collision collision)
    {
        // Hahanapin ang bago nating DummyHealth script sa tinamaan
        DummyHealth target = collision.gameObject.GetComponent<DummyHealth>();
        
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        // Masisira ang bala pagkatapos tumama
        Destroy(gameObject); 
    }
}