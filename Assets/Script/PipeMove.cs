using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;
    void Update()
    {
        if (!GameManager.instance.isDead)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }


    private void OnDestroy()
    {
        GameManager.instance.RemovePipe(this);
    }
}
