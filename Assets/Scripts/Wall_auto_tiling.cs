using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Wall_auto_tiling : MonoBehaviour
{
    public Vector2 tilingPerUnit = new Vector2(1, 1);

    void Start()
    {
        UpdateTiling();
    }

    void UpdateTiling()
    {
        Renderer rend = GetComponent<Renderer>();

        Material mat = rend.material;
        
        Vector3 scale = transform.localScale;

        Vector2 tiling = new Vector2(scale.z * tilingPerUnit.x, scale.y * tilingPerUnit.y);

        mat.mainTextureScale = tiling;
    }
}