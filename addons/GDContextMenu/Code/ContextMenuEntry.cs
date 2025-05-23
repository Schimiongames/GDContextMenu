using Godot;
using System;

[GlobalClass]
public partial class ContextMenuEntry : Resource
{
    [Export] public string Label = "";
    [Export] public NodePath ActionTarget = null;
    [Export] public string ActionMethod = "";
    [Export] public bool disabled = false;
}
