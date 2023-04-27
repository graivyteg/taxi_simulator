using System.Collections;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

[ExecuteAlways]
public class CityBuilder : MonoBehaviour
{
    [Header("Inputs")] 
    [SerializeField] private CityConfig _config;
    [SerializeField] private Vector2 _cellSize = Vector2.one;

    public Vector2 GetCellSize(Building building)
    {
        if (building.Size.x % _cellSize.x > 0 || building.Size.y % _cellSize.y > 0)
        {
            Debug.LogWarning($"Cell Size of {building.name} is not dividable, that can cause problems in generation"); 
        }
        return new Vector2(
            Mathf.Ceil(building.Size.x / _cellSize.x),
            Mathf.Ceil(building.Size.y / _cellSize.y)
        );
    }

    [Button("Generate City")]
    public void Generate()
    {
        StartCoroutine(Generation(_config));
    }

    private IEnumerator Generation(CityConfig config)
    {
        var houses = config.HouseBuildings.OrderBy(b => b.CitizensCapacity).ToList();
        yield return null;

        var order = new CityBuildOrder(config);
        var citizensLeft = config.Citizens;
        
        foreach (var house in houses)
        {
            if (citizensLeft == 0) break;
            
            int toBuild = Random.Range(0, Mathf.CeilToInt((float)citizensLeft / house.CitizensCapacity) + 1);
            citizensLeft -= Mathf.Min(citizensLeft, toBuild * house.CitizensCapacity);
            
            Debug.Log("To Build: " + toBuild);
            Debug.Log("Citizens Left: " + citizensLeft);
            
            for (int i = 0; i < toBuild; i++) order.Buildings.Add(house);
            yield return null;
        }
        
        BuildCity(order);
    }

    public void BuildCity(CityBuildOrder order)
    {
        var cityParent = new GameObject("City");
        int max = order.Buildings.Count;

        for (int x = 0; x < max; x++)
        {
            //Getting random house
            int buildingId = Random.Range(0, order.Buildings.Count);
            var building = order.Buildings[buildingId];
            order.Buildings.RemoveAt(buildingId);
            
            Instantiate(building.gameObject,
                new Vector3(x * building.Size.x, 0, 0), 
                Quaternion.identity,
                cityParent.transform);
        }
        Debug.Log("City successfully built!");
    }
}