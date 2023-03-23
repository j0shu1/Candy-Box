using UnityEngine;
using UnityEditor;

public class Exit_Script : MonoBehaviour
{
    public void button_exit()
    {
    
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();

    }
}
