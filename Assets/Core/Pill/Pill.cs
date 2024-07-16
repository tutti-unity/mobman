using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private AudioClip pickupSound;

    private const int SCORE = 100;
    
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (pickupLayerMask.Contains(collidingObject.gameObject.layer))
        {
            OnPickup();
            GameState.Instance.AddScore(SCORE);
        }
    }

    private void OnPickup()
    {
        AudioManager.Instance.PlayAudio(pickupSound);
        Destroy(gameObject);
    }
}
