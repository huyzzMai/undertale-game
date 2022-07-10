using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployDots : MonoBehaviour
{
    public GameObject dotPrefabX;
    public GameObject dotPrefabY;
    public GameObject dotPrefabNX;
    public GameObject dotPrefabNY;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(dotWave());
    }

    private void spawnEnemy()
    {
        GameObject dotY = Instantiate(dotPrefabY) as GameObject;
        dotY.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
        GameObject dotNY = Instantiate(dotPrefabNY) as GameObject;
        dotNY.transform.position = new Vector2(-screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));

        GameObject dotX = Instantiate(dotPrefabX) as GameObject;
        dotX.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
        GameObject dotNX = Instantiate(dotPrefabNX) as GameObject;
        dotNX.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y);
    }

    // Update is called once per frame
    IEnumerator dotWave()
    {
        while (true)
        {
            respawnTime = Random.Range(0.2f, 1);
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
