using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : MonoBehaviour {
    public Transform prefab;
    public KeyCode createKey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    List<Transform> objects;
    string savePath;
    // Use this for initialization
    void Start () {
		
	}
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
        objects = new List<Transform>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(createKey))
        {
            CreateObject();
        }
        else if (Input.GetKey(newGameKey))
        {
            BeginNewGame();
        }
    }
    void BeginNewGame() {
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i].gameObject);
        }
        objects.Clear();
    }
    void CreateObject()
    {
        Transform t = Instantiate(prefab);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
        objects.Add(t);
    }
    void Save()
    {
        var writer = new BinaryWriter(File.Open(savePath, FileMode.Create));
    }
}