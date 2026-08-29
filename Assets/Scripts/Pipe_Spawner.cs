using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    private float timer = 0f;

    public float heightOffset = 2.5f;   // amplitude de position verticale du centre
    public float minGap = 2.5f;         // écart minimum jouable
    public float maxGap = 4f;           // écart maximum

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float centerY = Random.Range(lowestPoint, highestPoint);

        GameObject newPipe = Instantiate(
            pipePrefab,
            new Vector3(transform.position.x, centerY, 0),
            transform.rotation
        );

        float randomGap = Random.Range(minGap, maxGap);
        PipePairSetup setup = newPipe.GetComponent<PipePairSetup>();
        if (setup != null)
        {
            setup.SetGap(randomGap);
        }
    }
}