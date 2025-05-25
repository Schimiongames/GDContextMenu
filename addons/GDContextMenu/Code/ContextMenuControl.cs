using Godot;
using Godot.Collections;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

[GlobalClass]
[Tool]
public partial class ContextMenuControl : Control
{
    [ExportCategory("Context Menu Settings")]
    [Export] private Control _nodeToConnect;
    [Export] private Vector2I _minimumSize;
    [Export] private PositionMode _positionMode = PositionMode.CURSOR;
    [Export] public Godot.Collections.Array<ContextMenuEntry> MenuEntries = new();

    public ContextMenu contextMenu;

    public override void _EnterTree()
    {
        base._EnterTree();

        if (!Engine.IsEditorHint())
            SetupMenu();
    }

    private void setupSubMenu(ContextMenu menu, ContextMenuEntry item)
    {
        ContextMenu contextMenu = menu.add_submenu(item.Label);

        foreach (var entry in item.contextMenuEntries)
        {
            var actionTarget = GetNodeOrNull(entry.ActionTarget);

            if (entry != null)
            {
                switch (entry.ItemType)
                {
                    case ContextMenuEntryType.Seperator:
                        contextMenu.add_seperator();
                        break;

                    case ContextMenuEntryType.Submenu:
                        setupSubMenu(contextMenu, entry);
                        break;

                    case ContextMenuEntryType.Checkbox:
                        if (actionTarget != null)
                            if (!actionTarget.HasMethod(entry.ActionMethod))
                            {
                                GD.PrintErr($"Target node does not have method '{entry.ActionMethod}'");
                            }

                        if (actionTarget == null)
                        {
                            contextMenu.add_checkbox_item(entry.Label, new Callable(null, null), entry.disabled, entry.isChecked, entry.Icon);
                        }
                        else
                        {
                            contextMenu.add_checkbox_item(entry.Label, new Callable(actionTarget, entry.ActionMethod), entry.disabled, entry.isChecked, entry.Icon);
                        }
                        break;

                    case ContextMenuEntryType.Item:
                        if (actionTarget != null)
                            if (!actionTarget.HasMethod(entry.ActionMethod))
                            {
                                GD.PrintErr($"Target node does not have method '{entry.ActionMethod}'");
                            }

                        if (actionTarget == null)
                        {
                            contextMenu.add_item(entry.Label, new Callable(null, null), entry.disabled, entry.Icon);
                        }
                        else
                        {
                            contextMenu.add_item(entry.Label, new Callable(actionTarget, entry.ActionMethod), entry.disabled, entry.Icon);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    private void SetupMenu()
    {
        contextMenu = new ContextMenu();
        contextMenu.attach_to(this);
        contextMenu.set_minimum_size(_minimumSize);
        contextMenu.set_position_mode(_positionMode);

        foreach (var entry in MenuEntries)
        {
            var actionTarget = GetNodeOrNull(entry.ActionTarget);

            if (entry != null)
            {
                switch (entry.ItemType)
                {
                    case ContextMenuEntryType.Seperator:
                        contextMenu.add_seperator();
                        break;

                    case ContextMenuEntryType.Submenu:
                        setupSubMenu(contextMenu, entry);
                        break;

                    case ContextMenuEntryType.Checkbox:
                        if (actionTarget != null)
                            if (!actionTarget.HasMethod(entry.ActionMethod))
                            {
                                GD.PrintErr($"Target node does not have method '{entry.ActionMethod}'");
                            }

                        if (actionTarget == null)
                        {
                            contextMenu.add_checkbox_item(entry.Label, new Callable(null, null), entry.disabled, entry.isChecked, entry.Icon);
                        }
                        else
                        {
                            contextMenu.add_checkbox_item(entry.Label, new Callable(actionTarget, entry.ActionMethod), entry.disabled, entry.isChecked, entry.Icon);
                        }
                        break;

                    case ContextMenuEntryType.Item:
                        if (actionTarget != null)
                            if (!actionTarget.HasMethod(entry.ActionMethod))
                            {
                                GD.PrintErr($"Target node does not have method '{entry.ActionMethod}'");
                            }

                        if (actionTarget == null)
                        {
                            contextMenu.add_item(entry.Label, new Callable(null, null), entry.disabled, entry.Icon);
                        }
                        else
                        {
                            contextMenu.add_item(entry.Label, new Callable(actionTarget, entry.ActionMethod), entry.disabled, entry.Icon);
                        }
                        break;

                    default:
                        break;
                }

                if (_nodeToConnect != null)
                {
                    contextMenu.connect_to(_nodeToConnect);
                }
            }
        }
    }
}
