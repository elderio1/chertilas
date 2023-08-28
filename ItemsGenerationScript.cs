using static class InventoryScript;
using System;

public static string path = "../models"

public class ItemsGenerationScript : MonoBehaviour {
    public static string[] GetFiles (string path);

    foreach (var item in GetFiles)
    {
        InventoryScript.items.Add(item);
    }
}