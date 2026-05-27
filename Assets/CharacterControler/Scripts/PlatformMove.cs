using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlatformMove : MonoBehaviour
{
    
    public Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
    public float movementSpeed = 1f;
    public bool linearMovement = false;
    public float pauseAtEnd = 0.0f;
    
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    float time = 0f;

    int stage = 0;
    float lerpAmount = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startPosition = transform.localPosition;
        endPosition = transform.localPosition + movement;
    }

    // Update is called once per frame
    void Update() {

        if (linearMovement) {
            
            if (stage == 0) {
                lerpAmount += Time.deltaTime * movementSpeed;
                transform.localPosition = Vector3.Lerp(startPosition, endPosition, lerpAmount);
                if (lerpAmount >= 1f) {
                    stage = 1;
                    lerpAmount = 0;
                }
                return;
            }
            
            if (stage == 1) {
                lerpAmount += Time.deltaTime;
                if( lerpAmount >= pauseAtEnd) {
                    stage = 2;
                    lerpAmount = 0;
                }
                return;
            }
            
            if (stage == 2) {
                lerpAmount += Time.deltaTime * movementSpeed;
                transform.localPosition = Vector3.Lerp(endPosition, startPosition, lerpAmount);
                if (lerpAmount >= 1f) {
                    stage = 3;
                    lerpAmount = 0;
                }
                return;
            }
            
            if (stage == 3) {
                lerpAmount += Time.deltaTime;
                if( lerpAmount >= pauseAtEnd) {
                    stage = 0;
                    lerpAmount = 0;
                }
                return;
            }

        } else {
            time += movementSpeed * Time.deltaTime;
            transform.localPosition = startPosition + movement * Mathf.Sin(time);
        }
    }

}
