public class EliteCombatSquare : Square
{
    internal override bool Walkable() => false;

    internal override void OnMouseDown()
    {
        if (board.IsSelectable(gridPosX, gridPosY))
            board.MovePlayer(gridPosX, gridPosY);
    }

    internal override SquareType Type() => SquareType.Combat;
}
