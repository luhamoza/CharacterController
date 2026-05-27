using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlatformStratch : MonoBehaviour
{
    
    public Vector2 stretch = new Vector2(0.0f, 0.0f);
    public float stretchSpeed = 1f;
    
    Vector3 originalScale = Vector3.one;
    float time = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        originalScale =transform.localScale;
    }

    // Update is called once per frame
    void Update() {

        time += stretchSpeed * Time.deltaTime;
        Vector3 localScale = transform.localScale;
        localScale.x = originalScale.x + stretch.x * Mathf.Sin(time);
        localScale.z = originalScale.z + stretch.y * Mathf.Cos(time);
        transform.localScale = localScale;
    }
    
}
