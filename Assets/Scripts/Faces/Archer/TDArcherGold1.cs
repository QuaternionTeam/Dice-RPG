using System.Linq;

internal class ArcherGold1 : Face
{
    public ArcherGold1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [Neutral]
    internal void FirstAttack() => AttackAllEnemies(1);

    [Neutral]
    internal void SecondAttack() => AttackAllEnemies(1);
}