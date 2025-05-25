extends Control

@onready var panel : Panel = $"."

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
