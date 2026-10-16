using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomColor : MonoBehaviour
{
    public int seed = 0;
    public string keyword = "_Color";

    void Start()
    {
        UnityEngine.Random.State oldState = UnityEngine.Random.state;
        UnityEngine.Random.InitState(this.seed);
        Color rng = Random.ColorHSV();
        rng.a = 1.0f;
        Material mat = this.GetComponent<MeshRenderer>().material;
        mat.SetColor(this.keyword, rng);
        UnityEngine.Random.state = oldState;
    }
}
