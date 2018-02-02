using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopManager : MonoSingleton<CopManager> {

    public List<GameObject> allCops;
    public GameObject BasicCop;
    public int numOfCops;
    public List<Transform> allWaypoints;

    private StateController m_StateController;

    private void Update()
    {
        if (allCops.Count == 0)
        {
            PopulateAllCivilians();
        }
    }

    public void SetupAI()
    {
        
        foreach (GameObject i in allCops)
        {
            m_StateController = i.GetComponent<StateController>();
            m_StateController.SetupAI(true, allWaypoints);
        }
    }

    public void PopulateAllCivilians()
    {
        for (int i = 0; i < numOfCops; i++)
        {

            allCops.Add(Instantiate(BasicCop));
            allCops[i].transform.position = new Vector3(Random.Range(-10f,10f) * 4, i * 2, 0);
        }
        SetupAI();
    }
}
