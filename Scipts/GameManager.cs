using Godot;
using System;

public partial class GameManager : Node
{
	
	[Export]
	public PackedScene ObjectScene { get; set; }
	
	//private Timer objectTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//objectTimer = GetNode<Timer>($"../ObjectTimer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_object_timer_timeout()
	{
		
		GD.Print("Spawn");
	}
}

