using UnityEngine;
using UnityEngine.Events;

public class AudioEvents : MonoBehaviour
{
    [SerializeField] 
    private AudioSource audioSource;
    private bool WasPlaying;
    [SerializeField]
    private UnityEvent OnStop; 

    // Start is called before the first frame update
    void Start()
    {
        WasPlaying = audioSource.isPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying && WasPlaying)
        {
            OnStop.Invoke();
        }
        WasPlaying = audioSource.isPlaying;
    }
}
