using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SeparatorAttribute:PropertyAttribute
{
    public readonly string title;


	public SeparatorAttribute()
	{
		this.title = "";
	}

	public SeparatorAttribute(string _title)
	{
        this.title = _title;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : DecoratorDrawer
{
    SeparatorAttribute separatorAttribute { get { return ((SeparatorAttribute)attribute); } }


    public override void OnGUI(Rect _position)
    {
        if (separatorAttribute.title == "")
        {
            _position.height = 1;
            _position.y += 19;
            GUI.Box(_position, "");
        }
        else
        {
            Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent(separatorAttribute.title));
            textSize = textSize * 2;
            _position.y += 19;
            GUI.Box(new Rect(_position.xMin, _position.yMin - 8.0f, _position.width, 20), separatorAttribute.title, "box");
        }
    }

    public override float GetHeight()
    {
        return 41.0f;
    }
}
#endif