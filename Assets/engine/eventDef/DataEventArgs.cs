using System;

namespace Susie
{
	public class DataEventArgs:EventArgs
	{
		private string stringData;
		private int intData;
		private bool boolData;

		public string StringData {
			get {
				return stringData;
			}

			set {
				stringData = value;
			}
		}

		public int IntData {
			get {
				return intData;
			}

			set {
				intData = value;
			}
		}

		public bool BoolData {
			get {
				return boolData;
			}

			set {
				boolData = value;
			}
		}
	}
}

