using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesData
{
    public GameObject visualization;
    public BulletPrefabs bullets;
    public float[] bulletsPercentage;
    public float fireRate;
    public float health;
    public float score;
}

public class EnemiesPrefabs : MonoBehaviour {

    public List<EnemiesData> types;
    private EnemiesData currentType;

    public EnemiesData CurrentType
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
                    }else
                    {
                        types[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        CurrentType = types[0];
    }

    public void setCurrentType(int typeSelected)
    {
        int currentTypeIndex = types.IndexOf(currentType);
        if (currentTypeIndex < types.Count)
        {
            if(typeSelected < types.Count)
            CurrentType = types[typeSelected];
        }
    }

    
}
