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
	contextMenu.attach_to(self)
	contextMenu.set_minimum_size(Vector2i(400, 0))
	contextMenu.add_item("Run the Test", Callable(self, "_runTest"), false, null)
	contextMenu.add_checkbox_item("Enable third Button", Callable(self, "_enableThirdButton"), false, false, null)
	contextMenu.add_placeholder_item("Disabled", true, null)
	contextMenu.add_seperator()
	var subMenu : ContextMenu = contextMenu.add_submenu("Submenu")
	subMenu.add_item("Run the Submenu Test", Callable(self, "_runTest"), false, null)
	
	contextMenu.connect_to(panel)
	
func _runTest() -> void:
	print("(GD) Context Menu is working...")
	
func _enableThirdButton(isChecked : bool) -> void:
	if(isChecked):
		contextMenu.set_item_disabled("Disabled", false)
		contextMenu.update_item_label("Disabled", "Enabled")
	else:
		contextMenu.set_item_disabled("Disabled", true)
		contextMenu.update_item_label("Enabled", "Disabled")
```

---

### C# example

```csharp
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
```

---

## API Reference

## 📘 API Reference – GDContextMenu v1.1

All functions below are available in both **GDScript** and **C#**.

| Method | Description |
|--------|-------------|
| `add_item(label, callback, disabled = false, icon = null)` | Adds a clickable menu item with optional disabled state and icon. |
| `add_checkbox_item(label, callback, disabled = false, is_checked = false, icon = null)` | Adds a checkbox item. The callback will receive a `bool` representing its state. |
| `add_separator()` | Adds a horizontal separator line between menu items. |
| `add_placeholder_item(label)` | Adds a non-interactive label (useful for grouping or headers). |
| `update_item_label(id_or_label, new_label)` | Changes the label of an existing menu item. |
| `set_item_disabled(id_or_label, disabled)` | Enables or disables a menu item by index or label. |
| `set_item_checked(id_or_label, checked)` | Sets the checked state of a checkbox item. |
| `set_minimum_size(Vector2i)` | Defines the minimum size of the context menu. |
| `attach_to(target_node)` | Attaches the context menu to a node (typically the scene root or a container). |
| `connect_to(control_node)` | Enables right-click activation on the given Control node. |

> 🧠 **Note**: `id_or_label` can be either an `int` (item ID) or a `String` (label).

---

## Installation

1. Clone or download this repository into your Godot project folder.  
2. Add a `ContextMenuControl` node or instantiate via script as shown above.  
4. Customize buttons and connect the menu to your UI nodes.  
5. Run the provided demo scene to see it in action!

---

## Requirements

- Godot Engine **4.4.1** MONO
- C# support enabled

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
