using UnityEngine;

public class InstrumentAudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the Audio Source component attached to this object
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name); // Debug message

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone!");

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Audio Started!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited by: " + other.gameObject.name); // Debug message

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone!");
            audioSource.Stop();
            Debug.Log("Audio Stopped!");
        }
    }
}
