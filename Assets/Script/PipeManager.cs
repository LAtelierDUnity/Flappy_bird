using System.Collections;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    private float _timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isDead)
        {
            if (_timer > _maxTime)
            {
                SpawnPipe();
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }

    }


    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        PipeMove pipeMove = pipe.GetComponent<PipeMove>();

        GameManager.instance.AddPipe(pipeMove);

        StartCoroutine(DestroyObject(pipe, 10));
    }

    private IEnumerator DestroyObject(GameObject pipe, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!GameManager.instance.isDead)
        {
            Destroy(pipe);
        }
    }
}
