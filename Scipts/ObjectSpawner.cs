using Godot;
using System;

public partial class ObjectSpawner : Node2D
{
	[Export] PackedScene fallingObject_scn;
	[Export] Node2D[] spawn_Points;
	[Export] float eps = 1.2f;
	 float spawn_Rate;
	 float time_until_spawn = 0;
	 public bool is_Spawning = true;

	 public override void _Ready()
	 {
		spawn_Rate = 1 / eps;
	 }

	 public override void _Process(double delta)
	 {	
		if(is_Spawning == true)
		{
			if (time_until_spawn > spawn_Rate) 
			{
				Spawn();
				time_until_spawn = 0;
			}
			else
			{
				time_until_spawn += (float)delta;
			}
		}
	 }

	 private void Spawn()
	 {
		RandomNumberGenerator rng = new RandomNumberGenerator();
		Vector2 location = spawn_Points[rng.Randi() % spawn_Points.Length].GlobalPosition;
		FallingObject fallingobject = (FallingObject)fallingObject_scn.Instantiate();
		fallingobject.GlobalPosition = location;
		GetTree().Root.AddChild(fallingobject);
	 }


}
