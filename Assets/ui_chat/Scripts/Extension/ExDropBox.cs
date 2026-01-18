using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyExtension
{
    public static class ExDropDown
    {
		/// <summary>
		/// ドロップボックスの選択肢をクリアしてから追加する
		/// </summary>
		/// <param name="dropdown">dropBox</param>
		/// <param name="options">追加する選択肢(string)のリスト</param>
		public static void ClearAddOptions(this Dropdown dropdown, List<string> options)
		{
			dropdown.ClearOptions();
			dropdown.AddOptions(options);
		}
	}
}
