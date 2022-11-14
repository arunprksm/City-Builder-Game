using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDataBase : SingletonGenerics<BuildingsDataBase>
{
    public List<Building> buildingsDataBase = new List<Building>();
}