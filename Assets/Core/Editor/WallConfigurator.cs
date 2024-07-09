using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class WallConfigurator
{
    [MenuItem("Tools/Configure Walls")]
    public static void ConfigureWalls() {
        string[] tiles = AssetDatabase.FindAssets("t:Tile");
        foreach (string tileGuid in tiles) {
            Tile tile = AssetDatabase.LoadAssetAtPath<Tile>(AssetDatabase.GUIDToAssetPath(tileGuid));
            var list = tile.sprite.texture.GetPixels((int)tile.sprite.rect.x, (int)tile.sprite.rect.y, (int)tile.sprite.rect.width, (int)tile.sprite.rect.height);
            tile.colliderType = (list.Distinct().Count() == 1) ? Tile.ColliderType.None : Tile.ColliderType.Grid;
        }
    }
}
