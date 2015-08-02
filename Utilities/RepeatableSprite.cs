using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class RepeatableSprite : MonoBehaviourBase
{
	SpriteRenderer sprite;

	public bool repeatX;
	public bool repeatY;

	void Awake()
	{
		sprite = this.GetComponent<SpriteRenderer>();

		// Generate prefab.
		var childPrefab = new GameObject();
		var childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childSprite.sprite = sprite.sprite;

		// Create additional children
		GameObject child;
		for (int i = 0, m = repeatX ? Mathf.RoundToInt(transform.localScale.x) : 1; i < m; i++)
			for (int j = 0, n = repeatY ? Mathf.RoundToInt(transform.localScale.y) : 1; j < n; j++)
			{
				child = (GameObject)Instantiate(childPrefab);
				child.transform.position = transform.position + new Vector3(i * sprite.bounds.size.x, j * sprite.bounds.size.y, 0);
				child.transform.parent = transform;
			}

		// Clean up prefab.
		Destroy(childPrefab);

		// Disable original sprite drawing.
		sprite.enabled = false;
	}
}
