using UnityEngine;

public class SkyRun : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
 
    public float resetPositionX = 20f; //  X position before reset
    public float startPositionX = -20f;  // Where to place it when resetting

    void Update()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        if (transform.position.x > resetPositionX)
        {
            Vector3 newPos = transform.position;
            newPos.x = startPositionX;
            transform.position = newPos;
        }
    }
}
