public class RerrollSquare : Square
{
    internal override bool Walkable() => false;

    internal override void OnMouseDown()
    {
        if (board.IsSelectable(gridPosX, gridPosY))
        {
            board.MovePlayer(gridPosX, gridPosY);
            GameData.instance.AddRerroll();
            BoardMenu.instance.UpdateRerrolls();
        }
    }

    internal override SquareType Type() => SquareType.Rerroll;
}
