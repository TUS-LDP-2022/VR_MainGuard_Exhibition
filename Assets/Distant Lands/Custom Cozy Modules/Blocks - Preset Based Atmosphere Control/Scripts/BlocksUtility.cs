using System.IO;
using System;
using UnityEngine;
using System.Collections.Generic;
using DistantLands.Cozy.Data;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DistantLands.Cozy
{

#if UNITY_EDITOR

    [UnityEditor.CustomPropertyDrawer(typeof(BlocksAttribute))]

    public class BlocksAttributeDrawer : PropertyDrawer
    {


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {


            float height = EditorGUIUtility.singleLineHeight;
            var unitARect = new Rect(position.x, position.y, position.width, height);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(unitARect, property, GUIContent.none);

            position = new Rect(position.x + 30, position.y, position.width - 30, position.height);

            if (property.objectReferenceValue != null)
            {
                ColorBlock profile = (ColorBlock)property.objectReferenceValue;
                (Editor.CreateEditor(profile) as E_ColorBlock).RenderInWindow(position);

            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineCount = 1;

            if (property.objectReferenceValue != null)
            {
                ColorBlock profile = (ColorBlock)property.objectReferenceValue;
                lineCount += 0.5f + (Editor.CreateEditor(profile) as E_ColorBlock).GetLineHeight();

            }
            return EditorGUIUtility.singleLineHeight * lineCount + EditorGUIUtility.standardVerticalSpacing * (lineCount - 1);
        }

    }

    [UnityEditor.CustomPropertyDrawer(typeof(TimeAttribute))]
    public class TimeDrawer : PropertyDrawer
    {

        TimeAttribute _attribute;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            _attribute = (TimeAttribute)attribute;
            float space = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            float height = EditorGUIUtility.singleLineHeight;

            EditorGUI.BeginProperty(position, label, property);



            float min = property.FindPropertyRelative("blockTime").floatValue - property.FindPropertyRelative("blockWidth").floatValue / 2;
            float max = property.FindPropertyRelative("blockTime").floatValue + property.FindPropertyRelative("blockWidth").floatValue / 2;


            var timeRect = new Rect(position.x, position.y, position.width, height);
            var widthRect = new Rect(position.x, position.y + space, position.width, height);
            var fillRect = new Rect();

            position.width -= 40;
            position.x += 20;

            var barRect = new Rect(position.x, position.y + space + space + space / 2 + 7, position.width, height * 2 - 14);
            fillRect.position = new Vector2(position.x + (position.width * Mathf.Clamp01(min)), position.y + space + space + space / 2);
            fillRect.width = position.width * property.FindPropertyRelative("blockWidth").floatValue + 2;
            if (min < 0)
                fillRect.width = position.width * (property.FindPropertyRelative("blockWidth").floatValue - Mathf.Abs(min)) + 2;
            if (max > 1)
                fillRect.width = position.width * (property.FindPropertyRelative("blockWidth").floatValue + (1 - max)) + 2;

            fillRect.height = height * 2;

            var unitRect = new Rect(position.x + 157, position.y, position.width - 155, position.height);



            EditorGUI.PropertyField(timeRect, property.FindPropertyRelative("blockTime"), new GUIContent("Block Median"));
            EditorGUI.PropertyField(widthRect, property.FindPropertyRelative("blockWidth"), new GUIContent("Block Width"));
            EditorGUI.PropertyField(widthRect, property.FindPropertyRelative("blockWidth"), new GUIContent("Block Width"));



            EditorGUI.DrawRect(barRect, new Color(0.12f, 0.12f, 0.12f, 0.5f));

            if (fillRect.width > 0)
                GUI.DrawTexture(fillRect, Repaint(property.FindPropertyRelative("displayColor").colorValue.gamma, property.FindPropertyRelative("secondaryDisplayColor").colorValue.gamma, Mathf.RoundToInt(fillRect.width), Mathf.RoundToInt(fillRect.height)));


            EditorGUI.EndProperty();
        }

        private static Texture2D Repaint(Color color)
        {
            return null;
        }

        public static Texture2D Repaint(Color color, Color secondary, int width, int height)
        {

            var gradTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
            gradTex.filterMode = FilterMode.Bilinear;
            float inv = 1f / (height - 1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var t = y * inv;
                    Color col = Color.Lerp(color, secondary, t);

                    gradTex.SetPixel(x, y, new Color(col.r, col.g, col.b, 1));

                }
            }
            gradTex.Apply();
            return gradTex;
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineCount = 5;


            return EditorGUIUtility.singleLineHeight * lineCount + EditorGUIUtility.standardVerticalSpacing * 2f * (lineCount - 1);
        }
    }


#endif


    public class BlocksAttribute : PropertyAttribute { }
    
    public class TimeAttribute : PropertyAttribute { public TimeAttribute() { } }


}