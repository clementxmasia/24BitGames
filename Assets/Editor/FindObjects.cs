using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        if (GUILayout.Button("Write CSV"))
        {
            string save = "OBJWithMesh.txt";
            foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            {
                Debug.Log(obj.name);
                if (obj.GetComponent<MeshFilter>().mesh != null)
                {

                    string tempName = obj.name;
                    addRecord(tempName, save);
                }
                else
                {
                    Debug.Log("Something is wrong");
                }
                //Debug.Log("Test if it gets here to point 1");
            }
            //addRecord();
            
        }
    }

    public static void addRecord(string objName, string filepath)
    {
        try {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
            {
                file.WriteLine(objName);
            }
        }

        catch(System.Exception ex){
            throw new System.ApplicationException("Problem found : ", ex);
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