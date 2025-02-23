using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal; 

public class FlickerLight2D : MonoBehaviour
{
    public Light2D lightSource; 
    public float minFlickerTime = 0.1f; 
    public float maxFlickerTime = 0.5f; 
    public float minIntensity = 0.5f; 
    public float maxIntensity = 1.2f; 

    void Start()
    {
        if (lightSource == null)
            lightSource = GetComponent<Light2D>(); 

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));

        
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
