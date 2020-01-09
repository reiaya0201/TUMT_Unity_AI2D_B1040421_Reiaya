using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "藍人")
        {
            collision.gameObject.GetComponent<BlueMan>().Damage(damage);
        }
    }
}
