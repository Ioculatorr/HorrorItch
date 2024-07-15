using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resolutions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        // Fetch all available resolutions
        resolutions = Screen.resolutions;

        // Clear the dropdown options
        resolutionDropdown.ClearOptions();

        // Create a list to hold unique resolution options
        List<string> options = new List<string>();
        HashSet<string> uniqueResolutions = new HashSet<string>();

        int currentResolutionIndex = 0;

        // Populate the options list with available resolutions
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            // Add unique resolutions to the list
            if (uniqueResolutions.Add(option))
            {
                options.Add(option);

                // Check if this is the current resolution
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = options.Count - 1;
                }
            }
        }

        // Add options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Set the dropdown to the current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener for when the dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(resolutionDropdown.value); });
    }

    public void OnResolutionChange(int resolutionIndex)
    {
        // Get the selected resolution
        string[] dimensions = resolutionDropdown.options[resolutionIndex].text.Split('x');
        int width = int.Parse(dimensions[0].Trim());
        int height = int.Parse(dimensions[1].Trim());

        // Change the screen resolution
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
