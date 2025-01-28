using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    public int n;
    public float size;
    public GameObject prefab;

    void Start()
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                GameObject tile = Instantiate(prefab, new Vector3(((i - 1) * size / n) - (size / 2), ((j - 1) * size / n) - (size / 2), 0), Quaternion.identity);
                tile.transform.localScale = new Vector3(size / n, size / n, size / n);
                tile.name = (i.ToString() + ", " + j.ToString());
                tile.GetComponent<Simulation>().x = i;
                tile.GetComponent<Simulation>().y = j;
                tile.GetComponent<Simulation>().n = n;
            }
        }
    }
}
