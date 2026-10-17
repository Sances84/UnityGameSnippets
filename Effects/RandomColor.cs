using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomColor : MonoBehaviour
{
    public int seed = 0;
    public bool byTheSeed = true;
    public string keyword = "_Color";

    void Start()
    {
        Random.State oldState = Random.state;
        if (byTheSeed)
        {
            Random.InitState(this.seed);
        }
        Color rng = Random.ColorHSV();
        rng.a = 1.0f;
        Material mat = this.GetComponent<MeshRenderer>().material;
        mat.SetColor(this.keyword, rng);
        if (byTheSeed)
        {
            Random.state = oldState;
        }
    }
}
