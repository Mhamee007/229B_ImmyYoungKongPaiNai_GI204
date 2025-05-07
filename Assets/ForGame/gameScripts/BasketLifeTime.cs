using UnityEngine;

public class BasketLifeTime : MonoBehaviour
{
   [SerializeField] float lifeTime = 0f;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
