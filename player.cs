using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public float speed = 300.0f;
    private Vector2 _velocity = new Vector2();
    private AnimatedSprite2D _animatedSprite;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }


    public override void _PhysicsProcess(double delta)
	{
        // 输入处理
        _velocity = new Vector2(); // 重置速度

        if (Input.IsActionPressed("ui_right"))
        {
            _velocity.X += 1;
            _animatedSprite.Play("right_run");
        }
        if (Input.IsActionPressed("ui_left"))
        {
            _velocity.X -= 1;
            _animatedSprite.Play("left_run");
        }
        if (Input.IsActionPressed("ui_down"))
        {
            _velocity.Y += 1;
            _animatedSprite.Play("front_run");
        }
        if (Input.IsActionPressed("ui_up"))
        {
            _velocity.Y -= 1;
            _animatedSprite.Play("back_run");
        }


        if (Input.IsActionJustReleased("ui_right"))
        {
            _animatedSprite.Play("right_idle");
        }
        if (Input.IsActionJustReleased("ui_left"))
        {
            _animatedSprite.Play("left_idle");
        }
        if (Input.IsActionJustReleased("ui_down"))
        {
            _animatedSprite.Play("front_idle");
        }
        if (Input.IsActionJustReleased("ui_up"))
        {
            _animatedSprite.Play("back_idle");
        }


        Velocity = _velocity.Normalized() * speed;
        
        MoveAndSlide();
    }
}
