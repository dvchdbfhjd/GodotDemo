using Godot;
using System;

public partial class Game : Node2D
{
    private Camera2D _camera; // Camera2D节点
    private TileMapLayer _tileMap; // TileMap节点
                                   // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _camera = GetNode<Camera2D>("/root/Game/Player/Camera2D");
        _tileMap = GetParent().GetNode<TileMapLayer>("/root/Game/tilemaps/boundary");
        SetCameraLimits();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void SetCameraLimits()
    {
        // 获取TileMap的边界
        Rect2 usedRect = _tileMap.GetUsedRect();

        // 设置Camera2D的限制
        _camera.LimitLeft = (int)usedRect.Position.X * _tileMap.TileSet.TileSize.X;
        _camera.LimitTop = (int)usedRect.Position.Y * _tileMap.TileSet.TileSize.Y;
        _camera.LimitRight = (int)usedRect.End.X * _tileMap.TileSet.TileSize.X;
        _camera.LimitBottom = (int)usedRect.End.Y * _tileMap.TileSet.TileSize.Y;
    }

}
