using ElfGames.Extensions;
using R3;

public class GameState : Singleton<GameState>
{
    private ReactiveProperty<int> score = new(0);
    public ReadOnlyReactiveProperty<int> Score => score;

    public void AddScore(int amount)
    {
        score.Value += amount;
    }
}
