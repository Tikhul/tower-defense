using UnityEngine;

public abstract class Config : ScriptableObject
{
    [SerializeField] private string _id;
    public string Id => _id;
}
