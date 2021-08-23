using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DLSU.SpacePirates.EnemySpawn;
using UnityEngine.UIElements;

namespace DLSU.SpacePirates.Editor.LevelEditor
{
    [CustomPropertyDrawer(typeof(EnemySpawnInstance))]
    public class EnemySpawnInstanceDrawer : PropertyDrawer
    {
        private string ENEMY_DATABASE_PATH = "Assets/Game/EnemySpawn/ScriptableObjects/EnemyDatabase.asset";
        private int TOTAL_LINES = 4;

        private EnemyDatabase enemyDatabase;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (enemyDatabase == null)
            {
                enemyDatabase = (EnemyDatabase)AssetDatabase.LoadAssetAtPath(ENEMY_DATABASE_PATH, typeof(EnemyDatabase));
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

                SerializedProperty enemyID = property.FindPropertyRelative("enemyID");
                SerializedProperty spawnDelayTime = property.FindPropertyRelative("spawnDelayTime");
                SerializedProperty spawnPosition = property.FindPropertyRelative("spawnPosition");
                SerializedProperty spawnRotation = property.FindPropertyRelative("spawnRotation");

                enemyID.intValue = EditorGUI.Popup(rects[0], new GUIContent("Enemy"), enemyID.intValue, BuildEnemyGUIContent());
                spawnDelayTime.floatValue = EditorGUI.FloatField(rects[1], "Spawn Time", spawnDelayTime.floatValue);
                spawnPosition.vector2Value = EditorGUI.Vector2Field(rects[2], "Position", spawnPosition.vector2Value);
                Vector2 eulerRotation = spawnRotation.quaternionValue.eulerAngles;
                spawnRotation.quaternionValue = Quaternion.Euler((Vector3)(EditorGUI.Vector2Field(rects[3], "Rotation", eulerRotation)));
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
            foreach (GameObject enemy in enemyDatabase.Enemies)
            {
                GUIContent content = new GUIContent();
                content.text = enemy.name;
                content.image = AssetPreview.GetMiniThumbnail(enemy);
                contents.Add(content);
            }
            return contents.ToArray();
        }
    }

}
