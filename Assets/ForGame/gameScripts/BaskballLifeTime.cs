using UnityEngine;

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
           
            GameManager.Instance.AddScore(1); 
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("basketG"))
        {
            GameManager.Instance.AddScore(5); 
            Destroy(other.gameObject);
            Destroy(gameObject);
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
