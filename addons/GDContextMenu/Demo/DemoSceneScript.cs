using Godot;
using System;

public partial class DemoSceneScript : Control
{

    ContextMenu contextMenu;
    public override void _Ready()
    {
        base._Ready();

        contextMenu = new ContextMenu();
        contextMenu.attach_to(this);
        contextMenu.set_minimum_size(new Vector2I(400, 0));
        contextMenu.add_item("Run the Test", new Callable(this, nameof(_runTest)), false);
        contextMenu.add_checkbox_item("Enable third Button", new Callable(this, nameof(_enableThirdButton)), false);
        contextMenu.add_placeholder_item("Disabled", true);
        contextMenu.add_seperator();
        ContextMenu subMenu = contextMenu.add_submenu("Submenu");
        subMenu.add_item("Run the Submenu Test", new Callable(this, nameof(_runTest)), false);

        contextMenu.connect_to(this);
    }

    private void _runTest()
    {
        GD.Print("(C#) Context Menu is working...");
    }

    private void _enableThirdButton(bool isChecked)
    {
        if (isChecked)
        {
            contextMenu.set_item_disabled("Disabled", false);
            contextMenu.update_item_label("Disabled", "Enabled");
        }
        else
        {
            contextMenu.set_item_disabled("Disabled", true);
            contextMenu.update_item_label("Enabled", "Disabled");
        }
    }
}
