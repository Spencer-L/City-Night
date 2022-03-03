using UnityEngine;

public class LightFlickerController : MonoBehaviour
{
    [SerializeField] private Material neonLight;
    private Color _neonColor;
    private static readonly int EmissiveColor = Shader.PropertyToID("_EmissiveColor");

    // flicker time rng
    [SerializeField] private float latestTime;
    [SerializeField] private float earliestTime;
    
    // flicker intensity
    [SerializeField] private float lowestIntensity;
    [SerializeField] private float upperIntensity;

    private float _timer;
    private float _flickerTime;
    private bool _flickerState;

    void Start()
    {
        _neonColor = neonLight.color;
    }

    void Update()
    {
        // generate random flicker time between 0.5-3 seconds
        if (_flickerTime == 0.0f)
        {
            _flickerTime = Random.Range(earliestTime, latestTime);
        }

        if (_timer >= _flickerTime)
        {
            _flickerTime = 0.0f;
            _timer = 0.0f;
            FlickerLight();
        }
        
        _timer += Time.deltaTime;
    }

    private void FlickerLight()
    {
        print("Flicker! " + _flickerState);
        _flickerState = !_flickerState;
        if (_flickerState)
        {
            neonLight.SetColor(EmissiveColor, _neonColor * upperIntensity);
        }
        else
        {
            neonLight.SetColor(EmissiveColor, _neonColor * lowestIntensity);
        }
    }
}
