using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[GlobalClass]
[Tool]
public partial class ContextMenuControl : Control
{
    [ExportCategory("Context Menu Settings")]
    [Export] private Control _nodeToConnect;
    [Export] public Godot.Collections.Array<ContextMenuEntry> MenuEntries = new();

    public ContextMenu contextMenu;

    public override void _EnterTree()
    {
        base._EnterTree();

        if (!Engine.IsEditorHint())
            SetupMenu();
    }

    private void SetupMenu()
    {
        contextMenu = new ContextMenu(this);

        foreach (var entry in MenuEntries)
        {
            var actionTarget = GetNodeOrNull(entry.ActionTarget);

            if (entry != null)
            {
                if (!actionTarget.HasMethod(entry.ActionMethod))
                {
                    GD.PrintErr($"Target node does not have method '{entry.ActionMethod}'");
                }

                contextMenu.AddButton(entry.Label, actionTarget, entry.ActionMethod, entry.disabled);

                if(_nodeToConnect != null)
                {
                    contextMenu.ConnectToNode(_nodeToConnect);
                }
            }
        }
    }
}
