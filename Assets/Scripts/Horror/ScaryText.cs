using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScaryText : MonoBehaviour
{
    public string fileName = "example.txt";
    private string fileContents;

    public TextAsset textAsset; // Reference to the imported text file

    private void Start()
    {
        // If the textAsset is assigned, use its text content
        if (textAsset != null)
        {
            fileContents = textAsset.text;
            SaveFileToDesktop();
        }
        else
        {
            Debug.LogError("TextAsset is not assigned. Please assign a text file in the Unity Editor.");
        }
    }

    public void SaveFileToDesktop()
    {
        // Get the path to the user's desktop
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        // Combine the desktop path with the file name
        string filePath = Path.Combine(desktopPath, fileName);

        try
        {
            // Write the file contents to the specified file path
            File.WriteAllText(filePath, fileContents);
            Debug.Log("File saved to desktop: " + filePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save file: " + ex.Message);
        }
    }
}
