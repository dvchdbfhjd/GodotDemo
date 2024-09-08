using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public float speed = 100.0f;
    private Vector2 _velocity = new Vector2();
    private AnimatedSprite2D _animatedSprite;
    bool isMoving = false;

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
            if (isMoving == false) {
                isMoving = true;    
                _animatedSprite.Play("right_run");

            }
        }
        if (Input.IsActionPressed("ui_left"))
        {
            _velocity.X -= 1;
            if (isMoving == false)
            {
                isMoving = true;
                _animatedSprite.Play("left_run");
            }
        }
        if (Input.IsActionPressed("ui_down"))
        {
            _velocity.Y += 1;
            if (isMoving == false)
            {
                isMoving = true;
                _animatedSprite.Play("front_run");
            }
        }
        if (Input.IsActionPressed("ui_up"))
        {
            _velocity.Y -= 1;
            if (isMoving == false)
            {
                isMoving = true;
                _animatedSprite.Play("back_run");
            }
        }

        if (Input.IsActionJustReleased("ui_right"))
        {
            _animatedSprite.Play("right_idle");
            isMoving = false;
        }
        if (Input.IsActionJustReleased("ui_left"))
        {
            _animatedSprite.Play("left_idle");
            isMoving = false;
        }
        if (Input.IsActionJustReleased("ui_down"))
        {
            _animatedSprite.Play("front_idle");
            isMoving = false;
        }
        if (Input.IsActionJustReleased("ui_up"))
        {
            _animatedSprite.Play("back_idle");
            isMoving = false;
        }

        Velocity = _velocity.Normalized() * speed;
        
        MoveAndSlide();
    }
}
