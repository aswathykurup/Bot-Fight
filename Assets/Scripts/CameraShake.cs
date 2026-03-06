using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 1.0f;

    Vector3 initialPosition;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

    }

    public void OnTriggerShake(float duration , float magnitude) 
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }


}
