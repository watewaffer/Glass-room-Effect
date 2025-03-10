using UnityEngine;
using System.Collections.Generic;

public class BreakGlass : MonoBehaviour
{
    public List<GameObject> BrokenGlassGO; // The broken glass prefab list
    private GameObject BrokenGlassInstance;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private bool isBroken = false;

    public bool BreakSound = true;
    public GameObject SoundEmitter;
    public float SoundEmitterLifetime = 2.0f;
    public float ShardsLifetime = 3.0f; 
    public float ShardMass = 0.5f;
    public Material ShardMaterial;

    public bool BreakByVelocity = false;
    public float BreakVelocity = 2.0f;

    public bool BreakByImpulse = false;
    public float BreakImpulse = 2.0f;

    public bool BreakByClick = false;
    public float SlowdownCoefficient = 0.6f;

    private GameObject originalGlassInstance; // Store a reference to the original glass object

    void Start()
    {
        // Store the original glass object's transform properties
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;

        // Clone the original glass so we can restore it later
        originalGlassInstance = Instantiate(gameObject, transform.position, transform.rotation);
        originalGlassInstance.SetActive(false); // Hide the backup until needed
    }

    public void BreakIt()
    {
        if (isBroken) return; // Prevent multiple breaks

        isBroken = true;

        // Instantiate shattered glass
        BrokenGlassInstance = Instantiate(BrokenGlassGO[Random.Range(0, BrokenGlassGO.Count)], transform.position, transform.rotation);
        BrokenGlassInstance.transform.localScale = transform.lossyScale;

        foreach (Transform t in BrokenGlassInstance.transform)
        {
            t.GetComponent<Renderer>().material = ShardMaterial;
            t.GetComponent<Rigidbody>().mass = ShardMass;
        }

        if (BreakSound)
            Destroy(Instantiate(SoundEmitter, transform.position, transform.rotation), SoundEmitterLifetime);

        // Hide the original glass instead of destroying it
        gameObject.SetActive(false);

        // Destroy the broken shards after a few seconds
        if (ShardsLifetime > 0)
            Destroy(BrokenGlassInstance, ShardsLifetime);
    }

    public void RestoreGlass()
    {
        if (!isBroken) return; // Prevent unnecessary restores

        isBroken = false;

        // Destroy any remaining broken glass
        if (BrokenGlassInstance != null)
        {
            Destroy(BrokenGlassInstance);
        }

        // Re-enable the original glass
        originalGlassInstance.SetActive(true);
    }

    void OnMouseDown()
    {
        if (BreakByClick) BreakIt();
    }
}
