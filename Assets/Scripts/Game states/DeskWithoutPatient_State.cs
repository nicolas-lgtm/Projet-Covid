﻿using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DeskWithoutPatient_State : MonoBehaviour
{
    [SerializeField] GameObject callPatientButton;
    GameObject buttonRightScreen;
    GameObject buttonLeftScreen;

    CinemachineVirtualCamera DeskCam;

    [SerializeField] GameObject currentCrewDisplayer_txt;
    [SerializeField] GameObject currentLevelDisplayer_txt;

    [SerializeField] GameObject okButton;
    [SerializeField] GameObject crewArrow;

    bool firstTimeInThisState = true;

    private void OnEnable()
    {
        buttonRightScreen = GameObject.Find("button_crewMember_screen_view");
        buttonLeftScreen = GameObject.Find("button_to_ship_screen");
        DeskCam = GameObject.Find("DeskViewCam").GetComponent<CinemachineVirtualCamera>();

        if(!firstTimeInThisState) GameManager.ActiveButton(callPatientButton);

        if (DeskCam.Priority < 1) DeskCam.Priority = 1;

        GameManager.DeactiveButton(buttonRightScreen);
        GameManager.DeactiveButton(buttonLeftScreen);


        if (!currentCrewDisplayer_txt.activeInHierarchy && firstTimeInThisState) currentCrewDisplayer_txt.SetActive(true);
        if (!currentLevelDisplayer_txt.activeInHierarchy && firstTimeInThisState) currentLevelDisplayer_txt.SetActive(true);

        if (firstTimeInThisState)
        {
            okButton.SetActive(true);
            crewArrow.SetActive(true);
            firstTimeInThisState = false;
        }
    }

    private void OnDisable()
    {
        DeskCam.Priority = 0;

        //if (GameManager._GAME_STATE != GameManager.eGameState.DeskWithPatient) 
        //    DeskCam.Priority = 0;

        GameManager.DeactiveButton(callPatientButton);
    }
}
