using UnityEngine;


public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 100)] public int resulation;

    private Transform[] points;

    private void Awake()
    {
        InitGraph();
    }
    private void Update()
    {
        AnimatingGraph();
    }

    private void AnimatingGraph()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = SinFunc(position.x);
            point.localPosition = position;
        }
    }
    private void InitGraph()
    {
        points = new Transform[resulation];

        float step = 2f / resulation;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        for (int i = 0; i < points.Length; i++)
        {

            Transform point = Instantiate(pointPrefab);
            position.x = ((i + 0.5f) * step - 1f);
            // position.y = Func(position.x);
            point.position = position;
            point.localScale = scale;
            point.SetParent(this.transform, false);

            points[i] = point;
        }
    }

    private float SinFunc(float x)
    {
        return Mathf.Cos(Mathf.PI * (x + Time.time));
    }


}