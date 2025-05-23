# Godot Context Menu

[![Godot 4.4.1](https://img.shields.io/badge/Godot-4.4.1-blue)](https://godotengine.org)  
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](LICENSE)  
[![Website](https://img.shields.io/badge/website-schimiongames.de-orange)](https://schimiongames.de)  

**Godot Context Menu** is a lightweight, flexible, and easy-to-use context menu plugin for **Godot 4.4.1**, written in **C#** — designed to bring native right-click context menus to your Godot projects, whether games, tools, or custom editors.

---

## Table of Contents

- [Features](#features)  
- [Quickstart](#quickstart)  
  - [GDScript example](#gdscript-example)  
  - [C# example](#c-example)  
- [API Reference](#api-reference)  
  - [GDScript](#gdscript)  
  - [C#](#c)  
- [Installation](#installation)  
- [Requirements](#requirements)  
- [About the Developer](#about-the-developer)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Features

- ✅ Supports **C#** and **GDScript** usage  
- ✅ Easily add & customize context menus anywhere in your UI  
- ✅ Dynamically enable/disable buttons by ID or label  
- ✅ Connect menus to any Control node for right-click activation  
- ✅ Includes a ready-to-use **demo scene**  
- ✅ Introduces a new `ContextMenuControl` Control node for flexible use  

---

## Quickstart

### GDScript example

```gdscript
var contextMenu : ContextMenu

func _ready() -> void:
    contextMenu = ContextMenu.new()
    add_child(contextMenu)

    contextMenu.AddButton("Run the Test", self, "_runTest", false)
    contextMenu.AddButton("Enable third Button", self, "_enableThirdButton", false)
    contextMenu.AddButton("Disabled", self, "", true)
    contextMenu.ConnectToNode(panel)  # Node that triggers the context menu

func _runTest() -> void:
    print("(GD) Context Menu is working...")

func _enableThirdButton() -> void:
    # Or alternatively:
    # contextMenu.SetButtonDisabled(2, false)
    contextMenu.SetButtonDisabledByLabel("Disabled", false)
```

---

### C# example

```csharp
private ContextMenu contextMenu;

public override void _Ready()
{
    base._Ready();

    contextMenu = new ContextMenu(this);
    contextMenu.AddButton("Run the Test", _runTest, false);
    contextMenu.AddButton("Enable third Button", _enableThirdButton, false);
    contextMenu.AddButton("Disabled", null, true);

    contextMenu.ConnectToNode(this);  // Must be a Control node
}

private void _runTest()
{
    GD.Print("(C#) Context Menu is working...");
}

private void _enableThirdButton()
{
    contextMenu.SetButtonDisabledByLabel("Disabled", false);
}
```

---

## API Reference

### GDScript

| Method                                     | Description                                         |
|--------------------------------------------|-----------------------------------------------------|
| `AddButton(Label, Callback, Method as String, Disabled?)` | Adds a button with label, callback method, disabled state |
| `ConnectToNode(Node)`                       | Connects menu to a Control node that triggers right-click |
| `SetButtonDisabled(id, value)`              | Enables/disables a button by its index                |
| `SetButtonDisabledByLabel(label, value)`   | Enables/disables a button by its label                 |

### C#

| Method                                     | Description                                         |
|--------------------------------------------|-----------------------------------------------------|
| `AddButton(Label, Callback, Disabled?)`    | Adds a button with label and callback delegate        |
| `ConnectToNode(Node)`                       | Connects to a Control node for right-click activation  |
| `SetButtonDisabled(id, value)`              | Enables/disables a button by index                      |
| `SetButtonDisabledByLabel(label, value)`   | Enables/disables a button by label                      |

---

## Installation

1. Clone or download this repository into your Godot project folder.  
2. Add a `ContextMenuControl` node or instantiate via script as shown above.  
4. Customize buttons and connect the menu to your UI nodes.  
5. Run the provided demo scene to see it in action!

---

## Requirements

- Godot Engine **4.4.1**  
- C# support enabled (if using C#)  

---

## About the Developer

**Daniel Schimion**  
Website: [schimiongames.de](https://schimiongames.de)

---

## Contributing

Feel free to open issues or submit pull requests.  
Bug reports, feature requests, and improvements are welcome!

---

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

🚀 Happy coding with Godot Context Menu!
