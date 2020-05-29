﻿using UnityEngine.UI;


public class CrewMemberID
{
    public Image img;

    public string first_name;
    public string last_name;

    public string sex;

    public string birth_date;
    public string birth_place;

    public int size;
    public int weight;

    public string symptom1;
    public string symptom2;

    public CrewMemberID(Image _img, string _first_name, string _last_name, string _sex, string _birth_date, string _birth_place, int _size, int _weight, string _symptom1, string _symptom2)
    {
        //ID INFO
        _img = img;
        _first_name = first_name;
        _last_name = last_name;
        _sex = sex;
        _birth_date = birth_date;
        _birth_place = birth_place;
        _size = size;
        _weight = weight;

        //DOSSIER MEDICAL INFO
        _symptom1 = symptom1;
        _symptom2 = symptom2;
    }

}

