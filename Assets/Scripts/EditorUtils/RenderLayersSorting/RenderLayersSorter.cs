namespace EditorUtils.RenderLayersSorting
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// ����� ��� ���������� ���������� ��������� ����.
    /// </summary>
    internal class RenderLayersSorter
    {
        /// <summary>
        /// ���������� � ���������� ������ ������������ ����� ������� �������.
        /// </summary>
        /// <param name="spriteRenderer">������ ��������.</param>
        /// <param name="pixelPerUnit">�������� �� �������.</param>
        private static Vector3 GetBottomNotAlphaPoint(SpriteRenderer spriteRenderer, int pixelPerUnit = 64)
        {
            var croppedRect = new Rect(
                (spriteRenderer.sprite.textureRectOffset.x - spriteRenderer.sprite.rect.width / 2f) / pixelPerUnit,
                (spriteRenderer.sprite.textureRectOffset.y - spriteRenderer.sprite.rect.height / 2f) / pixelPerUnit,
                spriteRenderer.sprite.textureRect.width / pixelPerUnit,
                spriteRenderer.sprite.textureRect.height / pixelPerUnit);

            return spriteRenderer.transform.TransformPoint(croppedRect.min);
        }

        /// <summary>
        /// ��������� ���� �������� �� �����.
        /// </summary>
        public static void SortAllObjects()
        {
            var objects = Object.FindObjectsOfType<SpriteRenderer>().ToList();

            SortRenderLayers(objects);

        }

        /// <summary>
        /// ��������� ����.
        /// </summary>
        /// <param name="renderers">��������� ��������������.</param>
        private static void SortRenderLayers(List<SpriteRenderer> renderers)
        {
            var sortedCollection = renderers.OrderByDescending(renderer => GetBottomNotAlphaPoint(renderer).y);

            var layersDictionary = new Dictionary<string, int>();

            foreach (var spriteRenderer in sortedCollection)
            {
                if (!layersDictionary.ContainsKey(spriteRenderer.sortingLayerName))
                    layersDictionary.Add(spriteRenderer.sortingLayerName, 0);

                spriteRenderer.sortingOrder = layersDictionary[spriteRenderer.sortingLayerName]++;
            }
        }
    }
}