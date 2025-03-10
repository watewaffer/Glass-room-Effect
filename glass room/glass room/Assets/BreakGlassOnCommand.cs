using UnityEngine;

public class BreakGlassOnCommand : MonoBehaviour
{
    public GameObject[] glassObjects; // Assign breakable glass objects in the Inspector

    void Update()
    {
        // Check if the "S" key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Loop through all breakable glass objects and trigger their breaking function
            foreach (GameObject glass in glassObjects)
            {
                if (glass != null)
                {
                    // Calls the break function from the Breakable Glass asset
                    glass.SendMessage("BreakGlass", SendMessageOptions.DontRequireReceiver);
                }
            }

            Debug.Log("Glass broken!");
        }
    }
}
