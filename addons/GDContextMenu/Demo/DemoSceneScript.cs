using Godot;
using System;

public partial class DemoSceneScript : Control
{

    ContextMenu contextMenu;
    public override void _Ready()
    {
        base._Ready();

        contextMenu = new ContextMenu(this);
        contextMenu.AddButton("Run the Test", _runTest, false);
        contextMenu.AddButton("Enable third Button", _enableThirdButton, false);
        contextMenu.AddButton("Disabled", null, true);

        contextMenu.ConnectToNode(this);
    }

    private void _runTest()
    {
        GD.Print("(C#) Context Menu is working...");
    }

    private void _enableThirdButton()
    {
        //Could also use:
        //contextMenu.SetButtonDisabled(2, false);
        contextMenu.SetButtonDisabledByLabel("Disabled", false);
    }
}
