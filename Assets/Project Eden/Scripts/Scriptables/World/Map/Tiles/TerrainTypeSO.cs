using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainType", menuName = "Map/TerrainType")]
public class TerrainTypeSO : ScriptableObject
{
    public string Name;
    public bool isWalkable;
    public Texture texture;
    // public List<ResourceDataSO> SupportedResources;

}
