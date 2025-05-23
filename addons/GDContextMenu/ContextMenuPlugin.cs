#if TOOLS
using Godot;
using System;

[Tool]
public partial class ContextMenuPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
        var script = GD.Load<Script>("res://addons/GDContextMenu/Code/ContextMenuControl.cs");
        var texture = GD.Load<Texture2D>("res://addons/GDContextMenu/Assets/Icon.png");

		AddCustomType("Context Menu Control", "Control", script, texture);
    }

	public override void _ExitTree()
	{
		RemoveCustomType("Context Menu Control");
	}
}
#endif
