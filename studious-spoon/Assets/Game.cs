using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Sprite spriteToUse;
    [SerializeField]
    GameObject nodeRoot;

	// Use this for initialization
	void Start () {
        Setup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Setup()
    {
        nodeRoot = GameObject.Find("Nodes");
        if (!nodeRoot)
        {
            nodeRoot = MakeNodes(10, 10);
        }
    }

    GameObject MakeNodes(int col, int row)
    {
        var nodeContainer = new GameObject("Nodes");
        var roottrans = nodeContainer.transform;
        roottrans.position = new Vector3(-7.5f, 4.5f);
        for (int i = 0; i < col; ++i)
        {
            var rowLabel = i.ToString("00");
            var rowContainer = new GameObject("Row" + rowLabel);
            rowContainer.transform.parent = roottrans;
            rowContainer.transform.localPosition = new Vector3(i, 0, 0);
            for (int j = 0; j < row; ++j)
            {
                var node = new GameObject("Node"+ rowLabel + j, typeof(SpriteController), typeof(Node));
                node.transform.parent = rowContainer.transform;
                node.transform.localPosition = new Vector3(0, -j, 0);
                node.AddComponent<SpriteRenderer>().sprite = spriteToUse;
            }

        }

        return nodeContainer;
    }
}
