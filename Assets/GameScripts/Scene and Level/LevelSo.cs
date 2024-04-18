using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New levelSo", menuName = "Level")]
public class LevelSo : ScriptableObject
{
    [Header("Level Info")]
    public int levelIndex;
    public string levelName;
    public string leveDescription;

    [Header("Level TextColor")]
    public Color nameColor;

    [Header("Level Bg Image")]
    public Sprite levelImage;

    [Header("Level Scene")]
    public Object SceneToLoad;
}
