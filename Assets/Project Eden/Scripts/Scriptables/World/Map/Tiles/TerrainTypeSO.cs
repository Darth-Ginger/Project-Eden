using UnityEngine;

[CreateAssetMenu(fileName = "TerrainType", menuName = "Map/TerrainType")]
public class TerrainTypeSO : ScriptableObject
{
    public string Name;
    public bool isWalkable;
    public texture texture;
    public ResourceDataSO[] SupportedResources;

}
