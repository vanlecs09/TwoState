using UnityEngine;

public interface IObjectPoolService
{
    GameObject Spawn(GameObject prefab);

    bool Despawned(GameObject obj);
    void Prespawn(GameObject prefab, int numToSpawn);
    void ShutDown();
}