using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects.Runner {
    public class Interactions : MonoBehaviour
    {
        public GameObject ObstaclePrefab;
        public GameObject CoinPrefab;

        public void SpawnObstacles(GameObject tile)
        {
            if (ObstaclePrefab != null)
            {
                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    // Set Y position to 0f
                    Vector3 obstaclePosition = new Vector3(Random.Range(-4.5f, 4.5f), 0f, Random.Range(5f, 15f));

                    GameObject obstacle = Instantiate(ObstaclePrefab, tile.transform.position , Quaternion.identity, tile.transform);

                    // Modify the position of the instantiated obstacle directly
                    obstacle.transform.localPosition += obstaclePosition;
                }
            }
            else
            {
                Debug.LogWarning("Obstacle Prefab is not assigned!");
            }
        }


        public void SpawnCoins(GameObject tile)
        {
            if (CoinPrefab != null)
            {
                for (int i = 0; i < Random.Range(1, 3); i++)
                {
                    // Set Y position to 0f
                    Vector3 coinPosition = new Vector3(Random.Range(-4.5f, 4.5f), 0.7f, Random.Range(5f, 15f));

                    GameObject coin = Instantiate(CoinPrefab, tile.transform.position, Quaternion.identity, tile.transform);

                    // Modify the position of the instantiated obstacle directly
                    coin.transform.localPosition += coinPosition;

                    coin.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
            }
            
            else
            {
                Debug.LogWarning("Coin Prefab is not assigned!");
            }
        }

    }

}


