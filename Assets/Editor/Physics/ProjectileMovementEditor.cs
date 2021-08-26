using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DLSU.SpacePirates.Physics;

namespace DLSU.SpacePirates.Editor.Physics
{
    [CustomEditor(typeof(ProjectileMovement))]
    [CanEditMultipleObjects]
    public class ProjectileMovementEditor : UnityEditor.Editor
    {
        private SerializedProperty projectileRigidbody;
        private SerializedProperty velocity;
        private SerializedProperty hasAcceleration;
        private SerializedProperty minSpeed;
        private SerializedProperty maxSpeed;
        private SerializedProperty acceleration;
        private SerializedProperty accelerationRate;

        private void OnEnable()
        {
            projectileRigidbody = serializedObject.FindProperty("projectileRigidbody");
            velocity = serializedObject.FindProperty("velocity");
            hasAcceleration = serializedObject.FindProperty("hasAcceleration");
            minSpeed = serializedObject.FindProperty("minSpeed");
            maxSpeed = serializedObject.FindProperty("maxSpeed");
            acceleration = serializedObject.FindProperty("acceleration");
            accelerationRate = serializedObject.FindProperty("accelerationRate");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(projectileRigidbody);
            EditorGUILayout.PropertyField(velocity);
            EditorGUILayout.PropertyField(hasAcceleration);
            if (hasAcceleration.boolValue)
            {
                EditorGUILayout.PropertyField(minSpeed);
                EditorGUILayout.PropertyField(maxSpeed);
                EditorGUILayout.PropertyField(acceleration);
                EditorGUILayout.PropertyField(accelerationRate);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }

}
