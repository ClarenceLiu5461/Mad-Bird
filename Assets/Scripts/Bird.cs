using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 startPostion;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        startPostion = rigidbody2D.position;
        rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPostion = rigidbody2D.position;
        Vector2 direction = startPostion - currentPostion;
        direction.Normalize();
        rigidbody2D.isKinematic = false;
        rigidbody2D.AddForce(direction * 500);
        spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x,mousePosition.y,transform.position.z);
    }

    void Update()
    {
        
    }
}
