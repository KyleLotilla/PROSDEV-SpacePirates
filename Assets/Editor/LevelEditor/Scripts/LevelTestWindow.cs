using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.EnemySpawn;
using UnityEditor.SceneManagement;
using DLSU.SpacePirates.BossSystem;

public class LevelTestWindow : EditorWindow
{
    private int toolbar = 0;
    private Level level = null;
    private int encounterSelected = 0;
    private string LEVEL_TEST_SCENE_PATH = "Assets/Editor/LevelEditor/Scenes/LevelTest.unity";
    private string ENCOUNTER_TEST_SCENE_PATH = "Assets/Editor/LevelEditor/Scenes/EncounterTest.unity";
    private string BOSS_TEST_SCENE_PATH = "Assets/Editor/LevelEditor/Scenes/BossTest.unity";

    [SerializeField]
    private LevelVariable testLevel;
    [SerializeField]
    private EncounterVariable testEncounter;
    [SerializeField]
    private BossSpawnInstanceVariable testBoss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [MenuItem("Level Editor/Level Test")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelTestWindow)).Show();
    }

    private void OnGUI()
    {
        toolbar = GUILayout.Toolbar(toolbar, new string[] { "Level Test", "Encounter Test", "Level Boss Test"});
        if (toolbar == 0)
        {
            ShowLevelTestGUI();
        }
        else if (toolbar == 1)
        {
            ShowEncounterTestGUI();
        }
        else if (toolbar == 2)
        {
            ShowBossTestGUI();
        }
    }

    private void ShowLevelTestGUI()
    {
        level = (Level)EditorGUILayout.ObjectField("Level", level, typeof(Level), false);
        EditorGUI.BeginDisabledGroup(level == null);
        if (GUILayout.Button("Test Level"))
        {
            TestLevel();
        }
        EditorGUI.EndDisabledGroup();
    }

    private void TestLevel()
    {
        testLevel.Value = level;
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        Debug.Assert(LEVEL_TEST_SCENE_PATH.Length > 0, "Level Test Scene Path is not set");
        EditorSceneManager.OpenScene(LEVEL_TEST_SCENE_PATH);
        EditorApplication.isPlaying = true;
        if (SceneView.sceneViews.Count > 0)
        {
            SceneView sceneView = (SceneView)SceneView.sceneViews[0];
            sceneView.Focus();
        }
        Close();
    }

    private void ShowEncounterTestGUI()
    {
        level = (Level)EditorGUILayout.ObjectField("Level", level, typeof(Level), false);
        if (level != null)
        {
            if (level.EncounterCount > 0)
            {
                string[] encounterLabels = new string[level.EncounterCount];
                for (int i = 0; i < level.EncounterCount; i++)
                {
                    encounterLabels[i] = i.ToString();
                }
                if (encounterSelected >= level.EncounterCount)
                {
                    encounterSelected = 0;
                }
                encounterSelected = EditorGUILayout.Popup("Encounter Selected", encounterSelected, encounterLabels);
                if (GUILayout.Button("Test Encounter"))
                {
                    TestEncounter();
                }
            }
            else
            {
                EditorGUILayout.LabelField("No Encounters in Level");
            }
        }
        else
        {
            EditorGUILayout.LabelField("No Level Selected");
        }
    }

    private void TestEncounter()
    {
        testEncounter.Value = level.Encounters[encounterSelected];
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        Debug.Assert(LEVEL_TEST_SCENE_PATH.Length > 0, "Encounter Test Scene Path is not set");
        EditorSceneManager.OpenScene(ENCOUNTER_TEST_SCENE_PATH);
        EditorApplication.isPlaying = true;
        if (SceneView.sceneViews.Count > 0)
        {
            SceneView sceneView = (SceneView)SceneView.sceneViews[0];
            sceneView.Focus();
        }
        Close();
    }

    private void ShowBossTestGUI()
    {
        level = (Level)EditorGUILayout.ObjectField("Level", level, typeof(Level), false);
        EditorGUI.BeginDisabledGroup(level == null);
        if (GUILayout.Button("Test Level Boss"))
        {
            TestBossLevel();
        }
        EditorGUI.EndDisabledGroup();
    }

    private void TestBossLevel()
    {
        testBoss.Value = level.Boss;
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        Debug.Assert(LEVEL_TEST_SCENE_PATH.Length > 0, "Boss Test Scene Path is not set");
        EditorSceneManager.OpenScene(BOSS_TEST_SCENE_PATH);
        EditorApplication.isPlaying = true;
        if (SceneView.sceneViews.Count > 0)
        {
            SceneView sceneView = (SceneView)SceneView.sceneViews[0];
            sceneView.Focus();
        }
        Close();
    }
}
