using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ContextMenu : Control
{
    private PopupMenu _menu;
    private Dictionary<int, Action> _actions = new();
    private int _nextId = 0;

    public ContextMenu(Node parent)
    {
        _menu = new PopupMenu();
        parent.AddChild(_menu, true);
        _menu.Hide();
        _menu.Connect("id_pressed", Callable.From((int id) => _on_item_pressed(id)));
    }

    public ContextMenu()
    {
        _menu = new PopupMenu();
        AddChild(_menu, true);
        _menu.Hide();
        _menu.Connect("id_pressed", Callable.From((int id) => _on_item_pressed(id)));
    }

    public void AddButton(string label, Action callback, bool disabled = false)
    {
        _menu.AddItem(label, _nextId);
        _menu.SetItemDisabled(_nextId, disabled);
        _actions[_nextId] = callback;
        _nextId++;
    }

    public void AddButton(string label, GodotObject target, string methodName, bool disabled = false)
    {
        int id = _nextId++;
        _menu.AddItem(label, id);
        _menu.SetItemDisabled(id, disabled);
        _actions[id] = () =>
        {
            if (target != null && target.HasMethod(methodName))
                target.Call(methodName);
        };
    }

    public void Show(Vector2 screenPosition)
    {
        _menu.SetPosition((Vector2I)screenPosition);
        _menu.Popup();
    }

    private void _on_item_pressed(int id)
    {
        if (_actions.TryGetValue(id, out var callback))
            callback?.Invoke();
    }

    public void ConnectToNode(Control node)
    {
        node.GuiInput += (InputEvent @event) =>
        {
            if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Right && mb.Pressed)
            {
                Show(node.GetGlobalMousePosition());
            }
        };
    }

    public void SetButtonDisabled(int id, bool disabled)
    {
        _menu.SetItemDisabled(id, disabled);
    }

    public void SetButtonDisabledByLabel(string label, bool disabled)
    {
        for (int i = 0; i < _menu.GetItemCount(); i++)
        {
            if (_menu.GetItemText(i) == label)
            {
                _menu.SetItemDisabled(i, disabled);
                break;
            }
        }
    }
}
