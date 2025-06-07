using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ListToDropdownAttribute : PropertyAttribute
{
    public Type type;
    public string name;
    
    public ListToDropdownAttribute(Type _type, string _name = "tmpListToDropdown")
    {
        type = _type;
        name = _name;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ListToDropdownAttribute))]
public class ListToDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ListToDropdownAttribute atb = attribute as ListToDropdownAttribute;
        List<string> stringList = null;

        if (atb.type.GetField(atb.name) != null)
        {
            stringList = atb.type.GetField(atb.name).GetValue(atb.type) as List<string>;
        }

        if ((stringList != null) && (stringList.Count != 0))
        {
            int selectedIndex = Mathf.Max(stringList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
            property.stringValue = stringList[selectedIndex];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
#endif