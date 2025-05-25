# 📦 GDContextMenu – Changelog

## [v1.1] – "The Polished Precision Patch" ✨

A major upgrade that turns your context menu into a fully-featured, clean, and flexible UI system.

---

### 🔧 API Refactor & Cleanup

- 💡 **Unified `add_item` Function**  
  GDScript and C# now share the same signature for `add_item(...)`.
  
- 🛠️ **Merged Constructors**  
  One unified constructor — cleaner and simpler initialization.

- 📌 **Introduced `attach_to()`**  
  Attach the menu to a node at runtime instead of via constructor.

- 🔄 **Renamed for clarity**  
  - `ConnectToNode(...)` → `connect_to(...)`
  - `SetButtonDisabled(...)` → `set_item_disabled(...)`

- 🗑️ **Removed**  
  - `SetButtonDisabledByLabel(...)` (redundant due to overloads)

---

### ➕ New Features

- ➖ `add_separator()`  
  Adds a visual separator between items.

- ⛔ `add_placeholder_item(label)`  
  Adds a non-interactive item for categories or grouping.

- 📐 `set_minimum_size(Vector2i)`  
  Sets a minimum size for the popup window.

- ✏️ `update_item_label(id_or_label, new_label)`  
  Change the text of an existing item dynamically.

- ✅ `add_checkbox_item(...)`  
  Adds a toggleable item with checked state.
  
  **✔ Callback Bonus**: Receives a `bool` as parameter with the checked state.

- ☑️ `set_item_checked(id_or_label, bool)`  
  Control the checked state of items manually.

- 🖼️ **Icon support**  
  `add_item(...)` and others now accept a `Texture2D` icon.

---

### 🧼 Summary

GDContextMenu v1.1 introduces a cleaner, more expressive API with powerful new features like checkbox items, icons, dynamic label updates, and simplified usage. It’s ready for serious UI work in tools or in-game contexts.

---
