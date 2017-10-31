namespace EditorUtils.RenderLayersSorting
{
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Окно соритровки очерёдности отрисовки слоёв.
    /// </summary>
    public class RenderLayerSortingWindow : EditorWindow
    {
        /// <summary>
        /// Сорировка отрисовки файлов.
        /// </summary>
        private void SortLayers()
        {
            if (GUILayout.Button("Sort Sprites"))
                RenderLayersSorter.SortAllObjects();
        }

        private void OnGUI()
        {
            SortLayers();
        }

        /// <summary>
        /// Отобразить окно.
        /// </summary>
        [MenuItem("Window/Render Layers Sorter")]
        public static void ShowWindow()
        {
            var styleChangerWindow = GetWindow<RenderLayerSortingWindow>(false, "Render Layers Sorter Window");
            styleChangerWindow.minSize = new Vector2(300, 80);
        }
    }
}