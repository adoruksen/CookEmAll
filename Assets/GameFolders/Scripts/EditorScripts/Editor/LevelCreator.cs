using UnityEditor;
using UnityEngine;

public class LevelCreator : EditorWindow
{
    public GridSpecsForLevel levelParts;
    private Vector2 scrollPos;

    [MenuItem("Window/My Editors/Level Creator")]
    private static void CreateLevelCreator()
    {
        GetWindow(typeof(LevelCreator));
    }


    private void OnGUI()
    {
        #region Header

        GUILayout.BeginHorizontal();
        GUILayout.Label("Level Designer Tool", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        #endregion


        levelParts =
            (GridSpecsForLevel)AssetDatabase.LoadAssetAtPath(
                "Assets/GameFolders/Scripts/EditorScripts/Level/Level.asset", typeof(GridSpecsForLevel));
        if (levelParts != null)
        {
            #region Create Level Specs Button

            if (GUILayout.Button("Create Level Specifications"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject =
                    AssetDatabase.LoadAssetAtPath("Assets/Scripts/Level/Level.asset", typeof(GridSpecsForLevel)) as
                        GridSpecsForLevel;
            }

            #endregion

            if (levelParts.gridSpecifications.Count > 0)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos);

                for (var section = 1; section <= levelParts.gridSpecifications.Count; section++)
                {
                    var boardStyle = new GUIStyle("box");
                    boardStyle.padding = new RectOffset(10, 10, 10, 10);
                    boardStyle.margin.left = 32;

                    var eggStyle = new GUIStyle("popup");
                    var pancakeStyle = new GUIStyle("popup");
                    var bagelStyle = new GUIStyle("popup");
                    var baconStyle = new GUIStyle("popup");
                    var steakStyle = new GUIStyle("popup");

                    var eggPlateStyle = new GUIStyle("popup");
                    var pancakePlateStyle = new GUIStyle("popup");
                    var bagelPlateStyle = new GUIStyle("popup");
                    var baconPlateStyle = new GUIStyle("popup");
                    var steakPlateStyle = new GUIStyle("popup");

                    var shifterStyle = new GUIStyle("popup");


                    #region Board Part

                    GUILayout.BeginHorizontal(boardStyle);
                    GUILayout.BeginVertical();

                    GUILayout.Label("Level Part " + section, EditorStyles.boldLabel);
                    levelParts.gridSpecifications[section - 1].boardSize = EditorGUILayout.Vector2IntField("Board Size",
                        levelParts.gridSpecifications[section - 1].boardSize, GUILayout.ExpandWidth(false));


                    #region Build Part Button

                    GUILayout.Space(30);
                    GUILayout.Label("Level Part : " + section + " Functions", EditorStyles.boldLabel);
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Build Part : " + section))
                        SpawnManager.Spawn(levelParts.gridSpecifications[section - 1], section,
                            levelParts.gridSpecifications.Count);
                    GUILayout.EndHorizontal();

                    #endregion

                    GUILayout.EndVertical();

                    for (var row = 0; row < levelParts.gridSpecifications[section - 1].boardSize.x; row++)
                    {
                        GUILayout.BeginVertical();
                        for (var column = 0; column < levelParts.gridSpecifications[section - 1].boardSize.y; column++)
                        {
                            EditorGUILayout.BeginHorizontal();

                            if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                InteractableTypes.Pancake)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], pancakeStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.Egg)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], eggStyle);
                            
                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.Bacon)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], baconStyle);
                            
                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.Steak)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], steakStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.Bagel)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], bagelStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.EggPlate)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], eggPlateStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.PancakePlate)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], pancakePlateStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.BagelPlate)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], bagelPlateStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.BaconPlate)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], baconPlateStyle);

                            else if (levelParts.gridSpecifications[section - 1].objType[row, column] ==
                                     InteractableTypes.SteakPlate)
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], steakPlateStyle);


                            else
                                levelParts.gridSpecifications[section - 1].objType[row, column] =
                                    (InteractableTypes)EditorGUILayout.EnumPopup(
                                        levelParts.gridSpecifications[section - 1].objType[row, column], shifterStyle);
                            EditorGUILayout.EndHorizontal();
                        }

                        GUILayout.EndVertical();
                    }

                    EditorGUILayout.EndHorizontal();

                    #endregion
                }
            }
        }

        GUIUtility.ExitGUI();
    }
}