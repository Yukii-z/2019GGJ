using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {

	public class Library {
		public static void SetPosition2D(GameObject go, Vector2 v2) {
			go.transform.SetPositionAndRotation(new Vector3(v2.x, v2.y, 0), Quaternion.identity);
		}

		public static void SetPosition2D(GameObject go, float x, float y) {
			go.transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.identity);
		}

		public static void SetPosition3D(GameObject go, Vector3 v3) {
			go.transform.SetPositionAndRotation(new Vector3(v3.x, v3.y, v3.z), Quaternion.identity);
		}
		public static void SetPosition3D(GameObject go, float x, float y, float z) {
			go.transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.identity);
		}

		// public static void SetPosition3D(GameObject go, Vector3 v3)
		// public static void SetPosition3D(GameObject go, float x, float y, float z)

		public float AngleBetweenPoints(Vector2 a, Vector2 b) {
			return Mathf.Atan ((a.y - b.y) / (a.x - b.x));
		}

		public static void RemoveIndicesFromList<T>(List<T> prime, List<int> removalIndices) {
			removalIndices.Sort ();
			for (int ind = removalIndices.Count; ind >= 0; ind--) {
				prime.RemoveAt (removalIndices[ind]);
			}
		}

		public static void RemoveIndicesAndNullifyFromList<T>(List<T> prime, List<int> removalIndices) {
			removalIndices.Sort ();
			for (int ind = removalIndices.Count - 1; ind >= 0; ind--) {
				if (removalIndices [ind] < 0 || removalIndices [ind] >= prime.Count) {
					Debug.Log ("tried to remove invalid index from list: " + prime + " index: " + removalIndices [ind]);
					continue;
				}
				T element = prime [removalIndices [ind]];
				prime.RemoveAt (removalIndices[ind]);
				element = default(T); // cannot nullify if value type
			}
		}
	}

}
