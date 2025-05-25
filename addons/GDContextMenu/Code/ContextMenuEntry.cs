using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class ContextMenuEntry : Resource
{
    [Export] public ContextMenuEntryType ItemType = ContextMenuEntryType.Item;
    [Export] public string Label = "";
    [Export] public NodePath ActionTarget = null;
    [Export] public string ActionMethod = "";
    [Export] public bool disabled = false;
    [Export] public bool isChecked = false;
    [Export] public Texture2D Icon = null;

    [ExportCategory("Submenu?")]
    [Export] public Godot.Collections.Array<ContextMenuEntry> contextMenuEntries = new();


}

public enum ContextMenuEntryType
{
    Item,
    Seperator,
    Checkbox,
    Submenu
}
