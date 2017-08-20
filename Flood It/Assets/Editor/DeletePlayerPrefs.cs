using UnityEditor;
using UnityEngine;

public class DeletePlayerPreferences {

    [MenuItem("Edit/Reset Playerprefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        Screen.SetResolution(800, 800, false);
    }
}
