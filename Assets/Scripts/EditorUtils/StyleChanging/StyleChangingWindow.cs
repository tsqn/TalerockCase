namespace EditorUtils.StyleChanging
{
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// ���� ����� �����.
    /// </summary>
    public class StyleChangerWindow : EditorWindow
    {
        /// <summary>
        /// ��������� �����.
        /// ���� ���������� ��� ����������� ���������� ����� � ����������.
        /// </summary>
        private Style _style = Style.Base;

        /// <summary>
        /// ���������� �����.
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
        /// ���������� ����.
        /// </summary>
        [MenuItem("Window/Style Changing")]
        public static void ShowWindow()
        {
            var styleChangerWindow = GetWindow<StyleChangerWindow>(false, "Style Changing Window");
            styleChangerWindow.minSize = new Vector2(300, 80);
        }
    }
}