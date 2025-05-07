using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BaskballLifeTime : MonoBehaviour
{
    private bool hasHitBasket = false;
    private float lifetime = 5f;

    public void SetLifetime(float time)
    {
        lifetime = time;
        Invoke(nameof(CheckAndDestroy), lifetime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("basket"))
        {
            Destroy(other.gameObject);// Destroy the basket
            Destroy(gameObject); // Destroy the projectile
        }
    }

    private void CheckAndDestroy()
    {
        if (!hasHitBasket)
        {
            Destroy(gameObject);
        }
    }
}