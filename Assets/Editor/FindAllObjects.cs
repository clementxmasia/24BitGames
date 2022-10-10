using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FindAllObjects : EditorWindow {

	
	private GameObject[] AllGo;
	const string clientList = "unity-scene.txt";

	[MenuItem("Window/Finder/AllObjects")]
	public static void ShowWindow ()
	{
		GetWindow<FindAllObjects>("Finder");
	}

	void OnGUI ()
	{
		GUILayout.Label("Click To Find All Objects and List", EditorStyles.boldLabel);

		

		if (GUILayout.Button("FIND!"))
		{
            FindAllObj();
		}
	}
 /*   void Test()
    { 
        
    }
 */


    //This finds all the objects and displays them in the console log
	void FindAllObj ()
	{
		List<GameObject> rootObjects = new List<GameObject>();
		Scene scene = SceneManager.GetActiveScene();
		scene.GetRootGameObjects(rootObjects);

		string filename = Path.Combine(Application.dataPath, clientList);

		using (StreamWriter writer = new StreamWriter(filename, false))
		{
			for (int i = 0; i < rootObjects.Count; ++i)
			{
				GameObject gameObject = rootObjects[i];

				Debug.Log(gameObject.name);

				DumpGameObject(gameObject, writer, "/", "");

			}
		}
		AssetDatabase.Refresh();
	}

    private static void DumpGameObject(GameObject gameObject, StreamWriter writer, string indent, string parentName)
    {
        foreach (Component component in gameObject.GetComponents<Component>())
        {
            /*if (gameObject.GetComponent<MeshFilter>().mesh != null)
            {
                Debug.Log("Ping");
            }*/
            if (component == null)
            {
                Debug.Log("NULL");
            }
            else
            {
                if ((component.GetType().Name == "Text") || (component.GetType().Name == "Button"))
                {
                    if ((component.GetType().Name == "Text"))
                    {
                        Text text = gameObject.GetComponent<Text>();
                        writer.WriteLine(text.text + " = " + parentName + gameObject.name);
                    }
                    else if ((component.GetType().Name == "Button"))
                    {
                        writer.WriteLine(gameObject.name + " = " + parentName + gameObject.name);
                    }
                }
            }
        }
        if (gameObject.transform.childCount > 0)
        {
            if (parentName != "")
            {
                if (!parentName.EndsWith("/"))
                    parentName = parentName + "/";
            }
            parentName = parentName + gameObject.name;
        }
        else
        {
            parentName = parentName + gameObject.name;

        }
        if (parentName.EndsWith("/"))
        {
            writer.WriteLine(parentName + gameObject.name);
        }
        else
        {
            writer.WriteLine(parentName);
        }
        foreach (Transform child in gameObject.transform)
        {
            if (!parentName.EndsWith("/"))
                parentName = parentName + "/";
            DumpGameObject(child.gameObject, writer, indent, parentName);
        }
    }

}
