using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 Direction { get; set; } = Vector2.right;
    [SerializeField] 
    private float velocity = 2f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(Direction.x, Direction.y, 0) * velocity * Time.deltaTime;
    }
}
