using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData
{
    public float damage;
    public float speed;
    public float radius;
    public GameObject visualization;
}

public class BulletPrefabs : MonoBehaviour {

    public List<BulletData> types;
    private BulletData currentType;

    public BulletData CurrentType
    {
        get
        {
            return currentType;
        }
        set
        {
            currentType = value;
            int currentTypesIndex = types.IndexOf(currentType);

            GameObject typesVisualization = types[currentTypesIndex].visualization;
            for (int i = 0; i < types.Count; i++)
            {
                if (typesVisualization != null)
                {
                    if (i == currentTypesIndex)
                    {
                        types[i].visualization.SetActive(true);
                    }
                    else
                    {
                        types[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        CurrentType = types[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setCurrentType(int typeSelected)
    {
        int currentTypeIndex = types.IndexOf(currentType);
        if (currentTypeIndex < types.Count)
        {
            if (typeSelected < types.Count)
                CurrentType = types[typeSelected];
        }
    }
}
