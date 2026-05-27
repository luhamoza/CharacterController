using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlatformSpin : MonoBehaviour
{
    
    public Vector3 spinSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 currentRotation = new Vector3(0.0f, 0.0f, 0.0f);
    //Rigidbody thisRigidBody;

    void Awake() {
        //thisRigidBody = GetComponent<Rigidbody>();
        currentRotation = transform.eulerAngles;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
        currentRotation += spinSpeed * Time.deltaTime;
        if( currentRotation.x > 180) currentRotation.x -= 360;
        if( currentRotation.y > 180) currentRotation.y -= 360;
        if( currentRotation.z > 180) currentRotation.z -= 360;
        if( currentRotation.x < -180) currentRotation.x += 360;
        if( currentRotation.y < -180) currentRotation.y += 360;
        if( currentRotation.z < -180) currentRotation.z += 360;
        
        Quaternion spinRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);
        transform.localRotation = spinRotation;
    }
    
}
