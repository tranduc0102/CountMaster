using UnityEngine;
using UnityEditor;
using System;

namespace Watermelon
{
    public static class EditorDrawUtility
    {
        public static void DrawHeader(string header)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(header, EditorStyles.boldLabel);
        }

        public static bool DrawHeader(SerializedProperty property)
        {
            HeaderAttribute headerAttr = PropertyUtility.GetAttribute<HeaderAttribute>(property);
            if (headerAttr != null)
            {
                DrawHeader(headerAttr.header);
                return true;
            }

            return false;
        }

        public static void DrawPropertyField(SerializedProperty property, bool includeChildren = true)
        {
            EditorGUILayout.PropertyField(property, includeChildren);
        }

        public static bool DrawLayoutField(object value, GUIContent label)
        {
            using (new EditorGUI.DisabledScope(disabled: true))
            {
                bool isDrawn = true;

                Type valueType = value.GetType();

                if (valueType == typeof(bool))
                {
                    EditorGUILayout.Toggle(label, (bool)value);
                }
                else if (valueType == typeof(short))
                {
                    EditorGUILayout.IntField(label, (short)value);
                }
                else if (valueType == typeof(ushort))
                {
                    EditorGUILayout.IntField(label, (ushort)value);
                }
                else if (valueType == typeof(int))
                {
                    EditorGUILayout.IntField(label, (int)value);
                }
                else if (valueType == typeof(uint))
                {
                    EditorGUILayout.LongField(label, (uint)value);
                }
                else if (valueType == typeof(long))
                {
                    EditorGUILayout.LongField(label, (long)value);
                }
                else if (valueType == typeof(ulong))
                {
                    EditorGUILayout.TextField(label, ((ulong)value).ToString());
                }
                else if (valueType == typeof(float))
                {
                    EditorGUILayout.FloatField(label, (float)value);
                }
                else if (valueType == typeof(double))
                {
                    EditorGUILayout.DoubleField(label, (double)value);
                }
                else if (valueType == typeof(string))
                {
                    EditorGUILayout.TextField(label, (string)value);
                }
                else if (valueType == typeof(Vector2))
                {
                    EditorGUILayout.Vector2Field(label, (Vector2)value);
                }
                else if (valueType == typeof(Vector3))
                {
                    EditorGUILayout.Vector3Field(label, (Vector3)value);
                }
                else if (valueType == typeof(Vector4))
                {
                    EditorGUILayout.Vector4Field(label, (Vector4)value);
                }
                else if (valueType == typeof(Vector2Int))
                {
                    EditorGUILayout.Vector2IntField(label, (Vector2Int)value);
                }
                else if (valueType == typeof(Vector3Int))
                {
                    EditorGUILayout.Vector3IntField(label, (Vector3Int)value);
                }
                else if (valueType == typeof(Color))
                {
                    EditorGUILayout.ColorField(label, (Color)value);
                }
                else if (valueType == typeof(Bounds))
                {
                    EditorGUILayout.BoundsField(label, (Bounds)value);
                }
                else if (valueType == typeof(Rect))
                {
                    EditorGUILayout.RectField(label, (Rect)value);
                }
                else if (valueType == typeof(RectInt))
                {
                    EditorGUILayout.RectIntField(label, (RectInt)value);
                }
                else if (typeof(UnityEngine.Object).IsAssignableFrom(valueType))
                {
                    EditorGUILayout.ObjectField(label, (UnityEngine.Object)value, valueType, true);
                }
                else if (valueType.BaseType == typeof(Enum))
                {
                    EditorGUILayout.EnumPopup(label, (Enum)value);
                }
                else if (valueType.BaseType == typeof(System.Reflection.TypeInfo))
                {
                    EditorGUILayout.TextField(label, value.ToString());
                }
                else
                {
                    isDrawn = false;
                }

                return isDrawn;
            }
        }
    }
}