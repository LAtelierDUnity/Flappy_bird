using UnityEngine;

public class FlyManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;


    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTouch()
    {
        if (!gameManager.firstTouch)
        {
            gameManager.firstTouch = true;
            gameManager.AllActivate();
        }

        rb.linearVelocity = Vector2.up * _velocity;
    }


    private void FixedUpdate()
    {
        if (gameManager.firstTouch)
        {
            transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * _rotationSpeed);

        }
    }
}
