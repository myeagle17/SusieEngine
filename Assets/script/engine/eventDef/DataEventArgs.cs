using System;
namespace Susie

{
	public class DataEventArgs:EventArgs
	{
		private string stringData = "null";
		private int intData;
		private bool boolData;
		private float floatData;

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

		public float FloatData {
			get {
				return floatData;
			}
			set {
				floatData = value;
			}
		}
	}
}

