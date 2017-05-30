using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Componentes {

	public class SpriteText : MonoBehaviour {

		void Start()
		{
			var parent = transform.parent;

			var parentRenderer = parent.GetComponent<Renderer>();
			var renderer = GetComponent<Renderer>();
			renderer.sortingLayerID = parentRenderer.sortingLayerID;
			renderer.sortingOrder = parentRenderer.sortingOrder;

			var spriteTransform = parent.transform;
			var pos = spriteTransform.position;

		}
	}

}