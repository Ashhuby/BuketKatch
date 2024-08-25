using Godot;
using System;

public partial class KillZone : Area2D
{
	private int _currentHealth;
	private HeartContainer healthBox;
	private AudioStreamPlayer missedBallSFX;
	private GameOverScreen gameOverScreen;
	private AudioStreamPlayer gameOverSFX;
	private ObjectSpawner objectSpawner;
	private Player player;
	private Camera2D shakyCam;

	public int CurrentHealth 
	{
		get { return _currentHealth; } 
		private set { _currentHealth = value; }
	}
	
	public override void _Ready()
	{
		CurrentHealth = 3;
		healthBox = GetNode<HeartContainer>("HeartLayer/HeartsContainer");
		missedBallSFX = GetNode<AudioStreamPlayer>("MissedBallSFX");
		gameOverScreen = GetNode<GameOverScreen>("myGameOverScreen");
		gameOverSFX = GetNode<AudioStreamPlayer>("myGameOverScreen/GameOverSFX");
		objectSpawner = GetNode<ObjectSpawner>("../ObjectSpawner");
		player = GetNode<Player>("../Player");
		shakyCam = GetNode<Camera2D>("../ShakyCamera");
	}
	public void Death()
	{
		gameOverScreen.Show();
		objectSpawner.is_Spawning = false;
		player.is_Dead = true;
		//GD.Print(player.is_Dead);
	}
	
	// This method is called when another body enters the KillZone area
	private void _on_body_entered(Node2D body)
	{
		if (body is FallingObject fallingObject)
		{
			GD.Print("It's an object!!");
			fallingObject.Explode();
			GD.Print("Did it work?");
		}
		if(player.is_Dead == false)
		{	
			if(CurrentHealth > 1)
			{
				if(shakyCam is ShakyCamera shakyCamera)
				{
					shakyCamera.StartShake(0.5f, 5.0f);
					GD.Print("SHAKEEE");
				}
				CurrentHealth--;
				healthBox.RemoveHearts(1);
				missedBallSFX.Play();
				GD.Print(CurrentHealth);
			}
			else 
			{
				if(shakyCam is ShakyCamera shakyCamera)
				{
					shakyCamera.StartShake(2.5f, 9.5f);
					GD.Print("SHAKEEE");
				}
				healthBox.RemoveHearts(1);
				gameOverSFX.Play();
				while(gameOverSFX.Playing)
				{
					//GD.Print("Still Playing Cant Pause YET :3");
				}
				Death();
				if(player.is_Dead == true)
				{
					player.Speed = 0;
				}
				GD.Print("U ded!");
			}
		}
	}
}
