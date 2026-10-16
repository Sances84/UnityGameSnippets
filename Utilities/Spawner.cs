/*
 * AI disclosure:
 * for improving clones GameObject list from List<GameObject> to GameObject[]
 * to fix bug, that makes inspector had variables disappear anything at all.
 * LLM used: GPT-6 Luna from https://duck.ai/chat webpage
*/
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 offset;
    public GameObject fab;
    public GameObject[] clones = new GameObject[0];
    public float radius = 1.0f;
    public float spawnSig = 2.0f;
    public float spawnProg = 0.0f;
    public int spawnTotal = 0;
    public int limit = 10;
    public bool randomSpawn = false;
    public bool randomRot = false;

    void Update()
    {
        // Remove destroyed clones and compact the array.
        int count = 0;
        for (int i = 0; i < clones.Length; i++)
        {
            if (clones[i] != null)
                clones[count++] = clones[i];
        }

        if (count != clones.Length)
            System.Array.Resize(ref clones, count);

        spawnTotal = clones.Length;
        if (spawnTotal < limit + 1)
        {
            spawnProg += Time.deltaTime;
            if (spawnProg >= spawnSig)
            {
                spawnProg = 0f;
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        if (fab == null) return;

        Vector3 randomOffset = randomSpawn
            ? Random.insideUnitSphere * radius
            : Vector3.zero;

        Quaternion randomRotOffset = randomRot ? new Quaternion(RandRot(), RandRot(), RandRot(), RandRot()) : Quaternion.identity;

        Vector3 spawnPosition = transform.position + offset + randomOffset;
        GameObject obj = Instantiate(fab, spawnPosition, randomRotOffset);

        System.Array.Resize(ref clones, clones.Length + 1);
        clones[clones.Length - 1] = obj;
        spawnTotal = clones.Length;
    }

    public static float RandRot()
    {
        return Random.value * 360;
    }

// Debug stripping for optimising the final game build from debug using #if UNITY_EDITOR
#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        Color oldColor = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
        Gizmos.color = oldColor;
    }
#endif
}
