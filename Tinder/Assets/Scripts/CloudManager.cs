using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public Object[] _clouds;
    public float minX, maxX, minZ, maxZ;
    public float spawnTimeRate;

    [Range(0f, 10f)]
    public float windForce = 1f;

    private Transform spawnerTransform;
    private List<GameObject> cloudInstances = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        spawnerTransform = GetComponent<Transform>();
        StartCoroutine(SpawnClouds());

    }

    // Update is called once per frame
    void Update()
    {
        TranslateUP();
    }

    IEnumerator SpawnClouds()
    {
        while(true)
        {
            GameObject instance;
            int cloudIndex = Random.Range(0, _clouds.Length);
            float offsetX = Random.Range(minX, maxX);
            float offsetZ = Random.Range(minZ, maxZ);
            Vector3 offset = new Vector3(offsetX, 0, offsetZ);
            Vector3 spawnPosition = spawnerTransform.position + offset;
            instance = Instantiate(_clouds[cloudIndex], spawnPosition, Quaternion.identity, spawnerTransform) as GameObject;
            cloudInstances.Add(instance);
            yield return new WaitForSeconds(spawnTimeRate);
            print("test temps");
        }
    }

    void TranslateUP()
    {
        foreach(GameObject cloud in cloudInstances)
        {
            if (cloud != null)
            {
                cloud.transform.Translate(Vector3.up * windForce * Time.deltaTime);
                if (cloud.transform.position.y > 100)
                {
                    Destroy(cloud);
                }
            }

        }
    }
}
