using UnityEngine;

public class rand_elementi : MonoBehaviour
{
    public GameObject circlePrefab;
    public int numCircles = 10;
    public float size = 1.0f;
    public Color redColor;
    public Color yellowColor;
    public Color greenColor;

    void Start()
    {
        for (int i = 0; i < numCircles; i++)
        {
            Vector2 position = new Vector2(Random.Range(-11.1f, 11.1f), Random.Range(-5f, 5f));
            Color color = GetRandomColor();

            GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity);
            circle.transform.localScale = new Vector3(size, size, 1f);
            circle.GetComponent<SpriteRenderer>().color = color;
        }
    }

    Color GetRandomColor()
    {
        int colorIndex = Random.Range(0, 3);
        switch (colorIndex)
        {
            case 0:
                return redColor;
            case 1:
                return yellowColor;
            case 2:
                return greenColor;
            default:
                return Color.white;
        }
    }
}