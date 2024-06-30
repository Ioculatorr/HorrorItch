using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryFiles : MonoBehaviour
{
    public Texture2D textureToSave;
    public int screenshotCount = 1;

    // Call this method to save the texture as a screenshot
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SaveTextureAsScreenshot();
        }
    }
    
    public void SaveTextureAsScreenshot()
    {
        // Ensure the texture to save is not null
        if (textureToSave != null)
        {
            // Convert the texture to PNG format
            byte[] bytes = textureToSave.EncodeToPNG();

            // // Generate a unique filename using a timestamp
            // string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");


            // Define the file path (in this example, saved in the Desktop)
            // Generate the filename with a dot and sequential number
            
            string fileName = "ỹ̶̧̝͕̞̦̓͑̍̄́ó̶̧̖̙̘̤͇̅u̵̹͈̓̃͗̚͘͠c̸̫̈̀̊͂̓͘a̵͓̖̦͌͒̚͜͝ṅ̴̛͚̩͉̲͖̰̏͝n̵͍̩̔͂́͊͝o̸̧̦̞͓̭̓̿̿ͅt̸̥̅̎͊r̵̥͔͇̒͆ͅu̶͍̽̕n̶̢͉͛̇̃̉̍ͅ";
            for (int i = 0; i < screenshotCount; i++)
            {
                fileName += ".";
            }
            fileName += ".png";
            
            string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/" + fileName;

            // Write the PNG data to a file
            System.IO.File.WriteAllBytes(filePath, bytes);
            
            // Increment the screenshot count for the next screenshot
            screenshotCount++;

            //Debug.Log("Screenshot saved to: " + filePath);
        }
        else
        {
            //Debug.LogWarning("No texture to save as screenshot.");
        }
    }
}
