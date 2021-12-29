using UnityEngine;

namespace u1w202112.UseCase.MainGame.Interface
{
    /// <summary>
    /// ゲーム開始時(プレイヤー情報が初期化された後)に呼ばれる処理。実装群がReadyStateUseCaseで呼ばれる。
    /// </summary>
    public interface IStartGameUseCase
    {
        void OnStartGame();
    }
}
