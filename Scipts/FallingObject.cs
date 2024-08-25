using Godot;
using System;

public partial class FallingObject : RigidBody2D
{
	public AnimationPlayer explosionAnimation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		explosionAnimation = GetNode<AnimationPlayer>("ExplosionAnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void Explode()
	{
		explosionAnimation.Play("ExplodeAnimation");
	}
}
