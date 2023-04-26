using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DistantLands.Cozy;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DistantLands.Cozy.Data
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Cozy/Block Schedule", order = 361)]
    public class BlockProfile : ScriptableObject
    {

        [System.Flags]
        public enum TimeBlocks { dawn = 1, morning = 2, day = 4, afternoon = 8, evening = 16, twilight = 32, night = 64 }

        public TimeBlocks timeBlocks;
        public bool blockSettings;

        [Tooltip("Transitions from 4am to 5:30am")]
        [Blocks]
        public List<ColorBlock> dawn;
        [Tooltip("Transitions from 5:30am to 7am")]
        [Blocks]
        public List<ColorBlock> morning;
        [Tooltip("Transitions from 9am to 10am")]
        [Blocks]
        public List<ColorBlock> day;
        [Tooltip("Transitions from 1pm to 2pm")]
        [Blocks]
        public List<ColorBlock> afternoon;
        [Tooltip("Transitions from 4pm to 6pm")]
        [Blocks]
        public List<ColorBlock> evening;
        [Tooltip("Transitions from 8pm to 9pm")]
        [Blocks]
        public List<ColorBlock> twilight;
        [Tooltip("Transitions from 9pm to 10pm")]
        [Blocks]
        public List<ColorBlock> night;

    }
#if UNITY_EDITOR
    [CustomEditor(typeof(BlockProfile))]
    [CanEditMultipleObjects]
    public class E_BlockProfile : Editor
    {

        BlockProfile t;

        void OnEnable()
        {

            t = (BlockProfile)target;

        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();



            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeBlocks"), true);
            EditorGUILayout.Space();

            EditorGUI.indentLevel++;

            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.dawn))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("dawn"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.morning))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("morning"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.day))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("day"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.afternoon))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("afternoon"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.evening))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("evening"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.twilight))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("twilight"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.night))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("night"), true);

            EditorGUI.indentLevel--;


            serializedObject.ApplyModifiedProperties();

        }

        public void EditInline(BlocksModule mod)
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeBlocks"), true);
            EditorGUILayout.Space();

            EditorGUI.indentLevel++;

            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.dawn))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("dawn"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.morning))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("morning"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.day))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("day"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.afternoon))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("afternoon"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.evening))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("evening"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.twilight))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("twilight"), true);
            if (t.timeBlocks.HasFlag(BlockProfile.TimeBlocks.night))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("night"), true);

            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {

                mod.GetBlocks();
                serializedObject.ApplyModifiedProperties();

            }
        }

    }
    #endif
}