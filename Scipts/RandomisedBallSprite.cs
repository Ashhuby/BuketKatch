using Godot;
using System;

public partial class RandomisedBallSprite : Sprite2D
{
    private const int SpriteCount = 6; // Number of sprites
    private const int SpriteWidth = 213; // Width of each sprite in the spritesheet
    private int spriteHeight; // Height of each sprite in the spritesheet

    public override void _Ready()
    {
        spriteHeight = (int)RegionRect.Size.Y; 

        if (!RegionEnabled)
        {
            //GD.Print("Enabling Region");
            RegionEnabled = true;
        }

        Random random = new Random();
        int randomIndex = random.Next(0, SpriteCount);
        //GD.Print($"Random Index: {randomIndex}");

        // Calculate the new RegionRect
        RegionRect = new Rect2(randomIndex * SpriteWidth, 0, SpriteWidth, spriteHeight);
        //GD.Print($"RegionRect: {RegionRect}");
    }
}
