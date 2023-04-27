using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CityConfig : ScriptableObject
{
    public int Citizens;
    public List<HouseBuilding> HouseBuildings;
    
    [Header("Roads")]
    public GameObject StraightRoad;
    [Space(10)] 
    public GameObject CornerRoadRight;
    public GameObject CornerRoadLeft;
    [Space(10)] 
    public GameObject TRoadRight;
    public GameObject TRoadLeft;
    public GameObject TRoadBoth;
    [Space(10)] 
    public GameObject CrossRoad;
}