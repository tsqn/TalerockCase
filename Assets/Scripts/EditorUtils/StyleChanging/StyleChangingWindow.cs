namespace EditorUtils.StyleChanging
{
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Окно смены стиля.
    /// </summary>
    public class StyleChangerWindow : EditorWindow
    {
        /// <summary>
        /// Выбранный стиль.
        /// Поле необходимо для отображения выбранного стиля в инспекторе.
        /// </summary>
        private Style _style = Style.Base;

        /// <summary>
        /// Приминение стиля.
        /// </summary>
        private void ApplyStyle()
        {
            _style = (Style)EditorGUILayout.EnumPopup("Chose style:", _style);

            if (GUILayout.Button("Apply style to selected objects"))
                StyleChanger.ChangeSelectedObjectStyles(_style);

            if (GUILayout.Button("Apply style to scene"))
                StyleChanger.ChangeAllObjectStyles(_style);

        }

        private void OnGUI()
        {
            ApplyStyle();
        }

        /// <summary>
        /// Отобразить окно.
        /// </summary>
        [MenuItem("Window/Style Changing")]
        public static void ShowWindow()
        {
            var styleChangerWindow = GetWindow<StyleChangerWindow>(false, "Style Changing Window");
            styleChangerWindow.minSize = new Vector2(300, 80);
        }
    }
}