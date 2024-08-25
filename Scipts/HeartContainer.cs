using Godot;
using System;

public partial class HeartContainer : HBoxContainer
{
	private PackedScene _heartPanel;
	
	public override void _Ready()
	{
		_heartPanel = GD.Load<PackedScene>("res://Scenes/HeartPanel.tscn");
		SetHearts(3);
	}
	
	public override void _Process(double delta)
	{
	}
	
	public void SetHearts(int pNumOfHearts)
	{
		for(int i = 0; i < pNumOfHearts; i++)
		{
			Node HeartInstance = _heartPanel.Instantiate();
			AddChild(HeartInstance);
		}
	}
	
	public void RemoveHearts(int pNumOfHearts)
	{
		for(int i = 0; i < pNumOfHearts; i++)
		{
			Node child = GetChild(GetChildCount() - 1);
			RemoveChild(child);
			child.QueueFree();	//Removes the nodes to save memory.
		}
	}
}
