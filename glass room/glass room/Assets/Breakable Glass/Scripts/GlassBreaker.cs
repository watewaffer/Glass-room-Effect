using UnityEngine;

public class GlassBreaker : MonoBehaviour
{
    public BreakGlass[] glassObjects; // Manually assign breakable glass objects in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Loop through all breakable glass objects and break them
            foreach (BreakGlass g in glassObjects)
            {
                if (g != null)
                {
                    g.BreakIt(); // Break the glass
                }
            }
            Debug.Log("Glass broken with 'S' key!");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            // Loop through all breakable glass objects and restore them
            foreach (BreakGlass g in glassObjects)
            {
                if (g != null)
                {
                    g.RestoreGlass(); // Restore the glass
                }
            }
            Debug.Log("Glass restored with 'D' key!");
        }
    }
}

