using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	private Vector2 ScreenSize; // Size of the game window.
	public static int score = 0;
	private Label scoreLabel;
	private AudioStreamPlayer audioPlayer;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>($"../ScoreLabel");
		audioPlayer = GetNode<AudioStreamPlayer>("CatchSound");
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("MoveRight"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("MoveLeft"))
		{
			velocity.X -= 1;
		}
		
		// Apply the speed and delta to the movement
		Position += velocity * Speed * (float)delta;

		// Ensure the player doesn't move out of the screen bounds
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 50, ScreenSize.X - 50),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}
	
	public void AddScore()
	{
		score++;
		scoreLabel.Text = score.ToString();
	}
	public void CatchSound()
	{
		audioPlayer.PitchScale = (float)GD.RandRange(1.2f,1.6f);
		audioPlayer.Play();
	}

	private void _on_body_entered(Node2D body)
	{
		body.QueueFree();
		AddScore();
		CatchSound();
	}
}
