using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class FindObjects : EditorWindow
{

    [MenuItem("Window/FindObjectsMeshes")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FindObjects));
    }

    public void OnGUI()
    {

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Find object with Meshes"))
        {

            foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            {
               
                Debug.Log(obj.name);
                if (obj.GetComponent<MeshFilter>().mesh != null)
                {
                    Debug.Log(" : Yes, I have a mesh! ");
                    rootVisualElement.Add(new Label(obj.name));
                }
                else
                {
                    Debug.Log(" : Nope /wrist");
                }
                //Debug.Log("Test if it gets here to point 1");

            }
        }
    }

    /*private static void FindObjects()
    {

        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            Debug.Log(obj.name);
            if (obj.GetComponent<MeshFilter>().mesh != null)
            {
                Debug.Log(" : Yes, I have a mesh! ");
            }
            else
            { 
                Debug.Log(" : Nope /wrist");
            }
            //Debug.Log("Test if it gets here to point 1");
        }


    }*/
}