using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects.Runner;
using UnityEngine.PlayerLoop;
using Player.Runner;

namespace Tiles.Runner
{
    public class GroundSpawner : MonoBehaviour
    {
        public GameObject GroundTile;
        int tilesToSpawn = 5;
        float tileLength;
        List<GameObject> spawnedTiles = new List<GameObject>();

        static Transform playerTransform; // Static reference to the player's transform
        float spawnZ = 0.0f;
        float tileSafeZone = 20.0f;
        float tileDestroyDelay = 3.0f;
        float destructionDistance = 10.0f; // Distance beyond which tiles are destroyed

        //private bool timerFinished = false;

        void Start()
        {
            tileLength = GroundTile.GetComponentInChildren<MeshRenderer>().bounds.size.z;
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            InitialTileCreation();            
        }

        private void InitialTileCreation()
        {
            for (int i = 0; i < tilesToSpawn; i++)
            {
                SpawnTile();
            }
        }

        void Update()
        {
            if (playerTransform != null && playerTransform.position.z - tileSafeZone > spawnZ - tilesToSpawn * tileLength)
            {
                SpawnTile();
                StartCoroutine(DestroyOldestTileWithDelay());
            }
        }

        void SpawnTile()
        {
            GameObject tile = Instantiate(GroundTile, new Vector3(0, 0, spawnZ), Quaternion.identity);
            spawnZ += tileLength;
            spawnedTiles.Add(tile);

            SpawnInteractions(tile);
        }

        private void SpawnInteractions(GameObject tile)
        {
            GetComponent<Interactions>().SpawnObstacles(tile);
            GetComponent<Interactions>().SpawnCoins(tile);
        }

        IEnumerator DestroyOldestTileWithDelay()
        {
            yield return new WaitForSeconds(tileDestroyDelay);

            if (spawnedTiles.Count > 0)
            {
                // Get the position of the oldest tile
                Vector3 oldestTilePosition = spawnedTiles[0].transform.position;

                //If script is disabled, the tiles will stop destroying
                //Script is disabled after player is dead
                if(enabled == false){
                    print("DestroyOldestTileWithDelay stopped");
                    yield break;
                }
                
                // Check if the player's position has passed a certain distance beyond the oldest tile
                if (playerTransform != null && playerTransform.position.z > oldestTilePosition.z + destructionDistance)
                {
                    // If the player has moved far enough beyond the tile, destroy it
                    Destroy(spawnedTiles[0]);
                    spawnedTiles.RemoveAt(0);
                }
                else
                {
                    Debug.Log("Player is near a tile. Tile will not be destroyed.");
                }
            }
        }

    }

}























