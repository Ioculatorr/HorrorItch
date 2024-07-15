using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenmode : MonoBehaviour
{
    public void SetScreenMode(int index)
    {
        switch(index)
        {
            case 0:

                Debug.Log("Fullscreen");
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

                break;
            case 1:

                Debug.Log("ExclusiveFullscreen");
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

                break;
            case 2:

                Debug.Log("Windowed");
                Screen.fullScreenMode = FullScreenMode.Windowed;

                break;
        }
    }
}
