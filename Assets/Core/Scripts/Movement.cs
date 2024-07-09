using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    public Vector2 Direction { get; set; } = Vector2.right;
    [SerializeField] 
    private float velocity = 2f;

    void FixedUpdate()
    {
        // gameObject.transform.position += new Vector3(Direction.x, Direction.y, 0) * velocity * Time.deltaTime;
        gameObject.GetComponent<Rigidbody2D>().position += new Vector2(Direction.x, Direction.y) * velocity * Time.deltaTime;
    }
}
