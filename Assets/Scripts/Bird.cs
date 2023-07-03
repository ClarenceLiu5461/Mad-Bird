using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float launchForce;
    [SerializeField] float maxDragDistance;
    Vector2 startPostion;
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        startPostion = GetComponent<Rigidbody2D>().position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPostion = rigid2D.position;
        Vector2 direction = startPostion - currentPostion;
        direction.Normalize();
        rigid2D.isKinematic = false;
        rigid2D.AddForce(direction * launchForce);
        spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        float distance = Vector2.Distance(desiredPosition, startPostion);
        if (distance > maxDragDistance)
        {
            Vector2 direction = desiredPosition - startPostion;
            direction.Normalize();
            desiredPosition = startPostion + (direction * maxDragDistance);
        }
        if (desiredPosition.x > startPostion.x)
        {
            desiredPosition.x = startPostion.x;
        }
        rigid2D.position = desiredPosition;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        rigid2D.position = startPostion;
        rigid2D.isKinematic = true;
        rigid2D.velocity = Vector2.zero;
    }
}
