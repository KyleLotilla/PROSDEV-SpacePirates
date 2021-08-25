using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.BossSystem;
using UnityEditor;

namespace DLSU.SpacePirates.Editor.LevelEditor
{
    [CustomPropertyDrawer(typeof(BossSpawnInstance))]
    public class BossSpawnInstaceDrawer : PropertyDrawer
    {
        private string BOSS_DATABASE_PATH = "Assets/Game/BossSystem/ScriptableObjects/BossDatabase.asset";
        private int TOTAL_LINES = 3;

        private BossDatabase bossDatabase;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (bossDatabase == null)
            {
                bossDatabase = (BossDatabase)AssetDatabase.LoadAssetAtPath(BOSS_DATABASE_PATH, typeof(BossDatabase));
            }

            EditorGUI.BeginProperty(position, label, property);

            Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);

            if (property.isExpanded)
            {
                Rect[] rects = new Rect[TOTAL_LINES];
                for (int i = 0; i < TOTAL_LINES; i++)
                {
                    rects[i] = new Rect(position.min.x, position.min.y + EditorGUIUtility.singleLineHeight * (i + 1), position.size.x, EditorGUIUtility.singleLineHeight);
                }

                SerializedProperty bossID = property.FindPropertyRelative("bossID");
                SerializedProperty spawnPosition = property.FindPropertyRelative("spawnPosition");
                SerializedProperty spawnRotation = property.FindPropertyRelative("spawnRotation");

                bossID.intValue = EditorGUI.Popup(rects[0], new GUIContent("Boss"), bossID.intValue, BuildEnemyGUIContent());
                spawnPosition.vector2Value = EditorGUI.Vector2Field(rects[1], "Position", spawnPosition.vector2Value);
                Vector3 eulerRotation = spawnRotation.quaternionValue.eulerAngles;
                spawnRotation.quaternionValue = Quaternion.Euler(new Vector3(0.0f, 0.0f, EditorGUI.FloatField(rects[2], "Rotation", Mathf.Round(eulerRotation.z))));
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int currentTotalLines = 2;
            if (property.isExpanded)
            {
                currentTotalLines += TOTAL_LINES;
            }
            return EditorGUIUtility.singleLineHeight * currentTotalLines;
        }

        private GUIContent[] BuildEnemyGUIContent()
        {
            List<GUIContent> contents = new List<GUIContent>();
            foreach (GameObject boss in bossDatabase.Bosses)
            {
                GUIContent content = new GUIContent();
                content.text = boss.name;
                content.image = AssetPreview.GetMiniThumbnail(boss);
                contents.Add(content);
            }
            return contents.ToArray();
        }
    }

}
