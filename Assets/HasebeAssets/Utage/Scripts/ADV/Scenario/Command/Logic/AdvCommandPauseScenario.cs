//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------


namespace Utage
{

	/// <summary>
	/// コマンド：シナリオ中断
	/// </summary>
	internal class AdvCommandPauseScenario : AdvCommand
	{
		public AdvCommandPauseScenario(StringGridRow row)
			: base(row)
		{
		}

		public override void DoCommand(AdvEngine engine)
		{
			engine.ScenarioPlayer.Pause();
		}

		//コマンド終了待ち
		public override bool Wait(AdvEngine engine)
		{
			return engine.ScenarioPlayer.IsPausing;
		}
		//ページ区切りのコマンドか
		public override bool IsTypePageEnd() { return true; }
	}
}