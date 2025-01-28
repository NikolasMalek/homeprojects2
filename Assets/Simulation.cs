using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public int x;
    public int y;
    public int n;
    public float dc;
    public float dn;
    public float diff;
    public float dt;
    public float velocity;
    public SpriteRenderer tileRenderer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddForces();
        Diffuse();
        Advect();
        Render();
        dc = dn;
    }

    float D(float x, float y)
    {
        GameObject tile = GameObject.Find(x.ToString() + ", " + y.ToString());
        if (tile)
        {
            return tile.GetComponent<Simulation>().dc;
        }
        else
        {
            return 0f;
        }
    }

    float S()
    {
        return (D(x, y + 1) + D(x + 1, y) + D(x, y - 1) + D(x - 1, y));
    }

    void AddForces()
    {

    }

    void Diffuse()
    {
        float k = Time.deltaTime * diff * n * n;
        dn = (dc + (k * S())) / (1 + (4 * k));
    }

    void Advect()
    {

    }

    void Render()
    {
        tileRenderer.material.color = new Color(dn, dn, dn);
    }
}
