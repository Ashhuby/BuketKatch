using Godot;
using System;

public partial class main_menu : Node
{
	private Button playBtn;
	private Button exitBtn;

	public override void _Ready()
	{
		// Initialize the buttons
		playBtn = GetNode<Button>("Buttons/PlayButton");
		exitBtn = GetNode<Button>("Buttons/ExitButton");
	}

	private void _on_play_button_pressed()
	{
		GD.Print("Play Button Pressed!");
		ChangeScene("res://Scenes/game_world.tscn");
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

		// Get the root of the scene tree and replace the current scene
		var currentScene = GetTree().CurrentScene;
		if (currentScene != null)
		{
			currentScene.QueueFree();  // Optionally free the current scene
		}

		// Instantiate the new scene and add it to the tree
		var newSceneInstance = newScene.Instantiate();
		GetTree().Root.AddChild(newSceneInstance);
		GetTree().CurrentScene = newSceneInstance;
	}

	private void _on_exit_button_pressed()
	{
		GD.Print("Exit Button Pressed!");
		GetTree().Quit();
	}
}
