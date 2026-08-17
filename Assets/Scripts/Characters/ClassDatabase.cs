using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ClassDatabase",
    menuName = "Far Horizons/RPG/Class Database"
)]
public class ClassDatabase : ScriptableObject
{
    public List<ClassData> classes = new List<ClassData>();

    public ClassData GetClass(CharacterClass characterClass)
    {
        foreach (ClassData classData in classes)
        {
            if (classData.classType == characterClass)
            {
                return classData;
            }
        }

        Debug.LogError(
            $"Class {characterClass} was not found in ClassDatabase."
        );

        return null;
    }
}