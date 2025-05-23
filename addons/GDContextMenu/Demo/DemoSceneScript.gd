extends Control

@onready var panel : Panel = $"."

var contextMenu : ContextMenu

func _ready() -> void:
	contextMenu = ContextMenu.new()
	add_child(contextMenu)
	
	contextMenu.AddButton("Run the Test", self, "_runTest", false)
	contextMenu.AddButton("Enable third Button", self, "_enableThirdButton", false)
	contextMenu.AddButton("Disabled", self, "", true)
	contextMenu.ConnectToNode(panel)
	
func _runTest() -> void:
	print("(GD) Context Menu is working...")
	
func _enableThirdButton() -> void:
	#Could also use:
	#contextMenu.SetButtonDisabled(2, false)
	contextMenu.SetButtonDisabledByLabel("Disabled", false)
