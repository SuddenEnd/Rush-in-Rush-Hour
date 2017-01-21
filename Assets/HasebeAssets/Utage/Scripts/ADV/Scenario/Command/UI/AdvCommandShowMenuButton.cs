//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------


namespace Utage
{

	/// <summary>
	/// コマンド：メニューボタンを表示
	/// </summary>
	internal class AdvCommandShowMenuButton : AdvCommand
	{
		public AdvCommandShowMenuButton(StringGridRow row)
			: base(row)
		{
		}

		public override void DoCommand(AdvEngine engine)
		{
			engine.UiManager.ShowMenuButton();
		}
	}
}