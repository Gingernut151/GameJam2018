using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianManager : MonoSingleton<CivilianManager>
{

    public List<GameObject> allCivilians;
    public GameObject BasicCiv;
    public int numOfCivs;

    private StateController m_StateController;

    private void Start()
    {
        LevelScore score = Object.FindObjectOfType<LevelScore>();
        score.SetNumOfInfectable(numOfCivs);
    }

    private void Update()
    {
        if (allCivilians.Count == 0)
        {
            PopulateAllCivilians();
        }
    }

    public void SetupAI()
    {
        foreach (GameObject i in allCivilians)
        {
            m_StateController = i.GetComponent<StateController>();
            m_StateController.SetupAI(true);
        }
    }

    public void PopulateAllCivilians()
    {
        for (int i = 0; i < (numOfCivs/2); i++)
        {
            
            allCivilians.Add(Instantiate(BasicCiv));
            allCivilians[i].transform.position = new Vector3(i+ 5, i*2, 0);
        }
        for (int i = 0; i < (numOfCivs / 2); i++)
        {

            allCivilians.Add(Instantiate(BasicCiv));
            allCivilians[i].transform.position = new Vector3(i - 5, i * 2, 0);
        }
        SetupAI();
    }
}
