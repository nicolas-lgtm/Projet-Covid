﻿using UnityEngine;

public class PatientManager : MonoBehaviour
{
    static public int currentPatient = 0;
    static public GameObject patientParent = null;
    static public GameObject currentPatient_go = null;

    [SerializeField] GameObject id_GO = null;
    DisplayPatientInfoOnID displayInfo_Script = null;

    [SerializeField] GameObject medicInfo_GO = null;
    DisplayPatientMedicalInfo displayMedicalInfo_Script = null;

    private void Start()
    {
        displayInfo_Script = id_GO.GetComponent<DisplayPatientInfoOnID>();
        displayMedicalInfo_Script = medicInfo_GO.GetComponent<DisplayPatientMedicalInfo>();
    }

    private void Update()
    {
        patientParent = GameObject.Find("Lvl " + GameManager.currentLvl.ToString());

        if (GameManager._GAME_STATE == GameManager.eGameState.End) currentPatient = 0;
    }
    public void SendBackPatient()
    {
        currentPatient_go.GetComponent<CrewMemberMovement>().SendBack();
    }

    public void CallNewPatient()
    {
        patientParent = GameObject.Find("Lvl " + GameManager.currentLvl.ToString());

        if (currentPatient + 1 <= patientParent.transform.childCount)//S'il y a encore des patients à examiner dans cet équipage
        {
            currentPatient_go = patientParent.transform.GetChild(currentPatient).gameObject;
            currentPatient_go.GetComponent<CrewMemberMovement>().enabled = true;
            currentPatient++;
            UpdateIDInfo();
            UpdateMedicalInfo();
        }
        else//Sinon on change l'état du jeu
        {
            GameManager._GAME_STATE = GameManager.eGameState.End;
        }
    }

    void UpdateIDInfo()
    {
        if (!displayInfo_Script.enabled) displayInfo_Script.enabled = true;
        displayInfo_Script.currentPatientInfo = currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;
        displayInfo_Script.UpdateInfo();
    }

    void UpdateMedicalInfo()
    {
        if (!displayMedicalInfo_Script.enabled) displayMedicalInfo_Script.enabled = true;
        displayMedicalInfo_Script.currentPatientInfo = currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;
        displayMedicalInfo_Script.UpdateInfo();
    }
}
