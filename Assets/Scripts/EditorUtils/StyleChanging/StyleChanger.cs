namespace EditorUtils.StyleChanging
{
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Класс для смены стиля объектов.
    /// </summary>
    public class StyleChanger
    {
        /// <summary>
        /// Изменяет стиль объектов на сцене.
        /// </summary>
        /// <param name="style">Выбранный стиль.</param>
        public static void ChangeAllObjectStyles(Style style)
        {
            var objects = Object.FindObjectsOfType<StyleChangingComponent>();
            foreach (var styleChangingComponent in objects)
                styleChangingComponent.ChangeStyle(style);
        }

        /// <summary>
        /// Изменяет стиль выбранных в едиторе объектов.
        /// </summary>
        /// <param name="style">Выбранный стиль.</param>
        public static void ChangeSelectedObjectStyles(Style style)
        {
            var objects = Selection.gameObjects;
            foreach (var o in objects)
            {
                var styleChangingComponent = o.GetComponent<StyleChangingComponent>();
                if (styleChangingComponent != null)
                    styleChangingComponent.ChangeStyle(style);
            }
        }
    }
}