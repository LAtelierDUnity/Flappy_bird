using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField]
    private float _floatAmplitude = 0.5f;
    [SerializeField]
    private float _frequency = 1f;

    private Vector2 _statpostion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statpostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float amplitude = Mathf.Sin(Time.time * _frequency) * _floatAmplitude;

        transform.position = new Vector2(_statpostion.x, _statpostion.y + amplitude);
    }
}
