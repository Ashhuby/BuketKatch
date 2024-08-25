using Godot;
using System;

public partial class GameOverScreen : CanvasLayer
{
	private Button replayButton;
	private Button exitButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		replayButton = GetNode<Button>("RestartButton");
		exitButton = GetNode<Button>("Exit");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_restart_button_pressed()
	{
		GD.Print("Replay!");
		GetTree().CurrentScene.QueueFree();
		ChangeScene("res://Scenes/game_world.tscn");
	}


	private void _on_exit_pressed()
	{
		GD.Print("Exiting to menu...");
		ChangeScene("res://Scenes/main_menu.tscn");
	}
	
	
	 private void ChangeScene(string scenePath)
	{
		// Load the new scene
		var newScene = (PackedScene)GD.Load(scenePath);
		if (newScene == null)
		{
			GD.PrintErr($"Failed to load scene at {scenePath}");
			return;
		}
		
		var root = GetTree().Root;
		foreach (Node child in root.GetChildren())
		{
			child.QueueFree();
		}

		// Instantiate the new scene and add it to the tree
		var newSceneInstance = newScene.Instantiate();
		GetTree().Root.AddChild(newSceneInstance);
		GetTree().CurrentScene = newSceneInstance;
	}
	
}
