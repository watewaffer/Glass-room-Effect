using UnityEngine;

public class GlassController : MonoBehaviour
{
    private BreakGlass glassScript; // Reference to BreakGlass script

    void Start()
    {
        // Get the BreakGlass script from the same GameObject
        glassScript = GetComponent<BreakGlass>();

        if (glassScript == null)
        {
            Debug.LogError("BreakGlass script not found! Make sure it's attached to the glass.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Press "S" to break the glass
        {
            if (glassScript != null)
            {
                glassScript.BreakIt();
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) // Press "D" to restore the glass
        {
            if (glassScript != null)
            {
                glassScript.RestoreGlass();
            }
        }
    }
}
