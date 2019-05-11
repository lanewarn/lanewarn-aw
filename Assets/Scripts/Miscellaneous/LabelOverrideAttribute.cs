using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/* Unity editor attribute to override the name of a variable
 * in the unity editor interface. Usage example:
 *
 *	[LabelOverride("Better Name")]
 *	public bool m_goodName;
 */
public class LabelOverride : PropertyAttribute
{
    public string label;
    public LabelOverride ( string label )
    {
        this.label = label;
    }

    #if UNITY_EDITOR
    [CustomPropertyDrawer( typeof(LabelOverride) )]
    public class ThisPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI ( Rect position , SerializedProperty property , GUIContent label )
        {
            // Create custom property field to override shown name.
            var propertyAttribute = this.attribute as LabelOverride;
            label.text = propertyAttribute.label;
            EditorGUI.PropertyField( position , property , label );
        }
    }
    #endif
}
