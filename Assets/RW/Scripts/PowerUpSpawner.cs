using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public List<GameObject> powerUps = new List<GameObject>();

    [SerializeField]
    private GameObject powerUpObj;


    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);

        SpawnPowerUp();

        StartCoroutine("Spawn");
    }

    public GameObject SpawnPowerUp()
    {
        GameObject powerUp;

        powerUp = Instantiate(powerUpObj);

        powerUp.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        powerUp.transform.position = new Vector3(xPos, 7.35f, 0);

        powerUps.Add(powerUp);

        return powerUp;
    }



    public void ClearPowerUp()
    {
        foreach (GameObject powerUp in powerUps)
        {
            Destroy(powerUp);
        }

        powerUps.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
