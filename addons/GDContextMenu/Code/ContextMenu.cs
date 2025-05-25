using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

[GlobalClass]
public partial class ContextMenu : Control
{
    private PopupMenu _menu;
    private PositionMode _currentPositionMode = PositionMode.CURSOR;

    private Dictionary<int, Callable?> _actions = new();
    private Dictionary<int, Callable?> _checkboxActions = new();

    private int _nextId = 0;

    public ContextMenu()
    {
        _menu = new PopupMenu();
       
        _menu.Hide();
        _menu.Connect("id_pressed", Callable.From((int id) => _on_item_pressed(id)));
    }

    #region "Public Functions"
    public void attach_to(Node parent)
    {
        parent.AddChild(_menu, true);
    }

    public void add_item(string label, Callable callback, bool disabled = false, Texture2D icon = null)
    {
        _menu.AddItem(label, _nextId);
        _menu.SetItemDisabled(_nextId, disabled);

        if (icon != null)
        {
            _menu.SetItemIcon(_nextId, icon);
        }

        _actions[_nextId] = callback;

        _nextId++;
    }

    public void add_checkbox_item(string label, Callable callback, bool disabled = false, bool isChecked = false, Texture2D icon = null)
    {
        _menu.AddCheckItem(label, _nextId);

        _menu.SetItemDisabled(_nextId, disabled);
        _menu.SetItemChecked(_nextId, isChecked);

        if (icon != null)
        {
            _menu.SetItemIcon(_nextId, icon);
        }

        _checkboxActions[_nextId] = callback;

        _nextId++;
    }

    public void add_placeholder_item(string label, bool disabled = false, Texture2D icon = null)
    {
        _menu.AddItem(label, _nextId);
        _menu.SetItemDisabled(_nextId, disabled);

        if (icon != null)
        {
            _menu.SetItemIcon(_nextId, icon);
        }

        _nextId++;
    }

    public void add_seperator()
    {
        _menu.AddSeparator();
    }

    public void connect_to(Control node)
    {
        node.GuiInput += (InputEvent @event) =>
        {
            if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Right && mb.Pressed)
            {
                show_item(node);
            }
        };
    }

    public void set_minimum_size(Vector2I size)
    {
        _menu.Size = size;
    }

    public void set_item_disabled(Variant id, bool disabled)
    {
        if(id.VariantType == Variant.Type.Int)
        {
            _menu.SetItemDisabled((int)id, disabled);
        }
        
        if(id.VariantType == Variant.Type.String)
        {
            for (int i = 0; i < _menu.GetItemCount(); i++)
            {
                if (_menu.GetItemText(i) == id.ToString())
                {
                    _menu.SetItemDisabled(i, disabled);
                    break;
                }
            }
        }
    }

    public void set_item_checked(Variant id, bool isChecked)
    {
        if (id.VariantType == Variant.Type.Int)
        {
            _menu.SetItemChecked((int)id, isChecked);
        }

        if (id.VariantType == Variant.Type.String)
        {
            for (int i = 0; i < _menu.GetItemCount(); i++)
            {
                if (_menu.GetItemText(i) == id.ToString())
                {
                    _menu.SetItemChecked((int)i, isChecked);
                    break;
                }
            }
        }
    }
    
    public void set_position_mode(PositionMode mode)
    {
        _currentPositionMode = mode;
    }

    public ContextMenu add_submenu(string label)
    {
        var submenu = new ContextMenu();
        submenu.Name = $"submenu_{_nextId}";

        _menu.AddChild(submenu._menu);

        _menu.AddSubmenuNodeItem(label, submenu._menu);

        _nextId++;
        return submenu;
    }

    public void update_item_label(Variant id, string newLabel)
    {
        if (id.VariantType == Variant.Type.Int)
        {
            _menu.SetItemText((int)id, newLabel);
        }

        if (id.VariantType == Variant.Type.String)
        {
            for (int i = 0; i < _menu.GetItemCount(); i++)
            {
                if (_menu.GetItemText(i) == id.ToString())
                {
                    _menu.SetItemText((int)i, newLabel);
                    break;
                }
            }
        }
    }
    #endregion

    #region "Private Functions"
    private void show_item(Control parent)
    {
        Vector2 position;

        switch (_currentPositionMode)
        {
            case PositionMode.CURSOR:
                position = parent.GetGlobalMousePosition();
                break;
            case PositionMode.NODE_CENTER:
                position = parent.GetGlobalRect().Size / 2;
                break;
            case PositionMode.NODE_BOTTOM:
                var rect = parent.GetGlobalRect();
                position = new Vector2(rect.Position.X, rect.Position.Y + rect.Size.Y);
                break;
            default:
                position = GetGlobalMousePosition();
                break;
        }

        _menu.SetPosition((Vector2I)position);
        _menu.Popup();
    }

    private void _on_item_pressed(int id)
    {
        if (_checkboxActions.TryGetValue(id, out var checkboxCallback) && checkboxCallback != null)
        {
            _menu.SetItemChecked(id, !_menu.IsItemChecked(id));
            bool isChecked = _menu.IsItemChecked(id);
            checkboxCallback?.CallDeferred(isChecked);
        }
        else if (_actions.TryGetValue(id, out var callback) && callback != null)
        {
            callback?.CallDeferred();
        }
    }
    #endregion
}
