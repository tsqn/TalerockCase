namespace Editor
{
    using System.ComponentModel;
    using UnityEngine;

    /// <summary>
    /// Компонент отвечающий за привязку координат к сетке.
    /// </summary>
    /// <remarks>
    /// Выполняется в редакторе.
    /// </remarks>
    [ExecuteInEditMode]
    public class SnapperComponent : MonoBehaviour {
#if UNITY_EDITOR

        /// <summary>
        /// Компонент включен.
        /// </summary>
        [DefaultValue(true)]
        public bool IsEnabled;

        /// <summary>
        /// Величена ячейки сетки.
        /// </summary>
        [DefaultValue(1)]
        public float CellSize = 1;

        private void Update()
        {
            if (IsEnabled)
                transform.position = GetSnappedPosition(transform.position, CellSize);
        }

        /// <summary>
        /// Возвращает выравненную позицию объекта.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="cellSize">Размер ячейки.</param>
        private Vector3 GetSnappedPosition(Vector3 position, float cellSize)
        {
            return new Vector3
            (
                cellSize * Mathf.Round(position.x / cellSize),
                cellSize * Mathf.Round(position.y / cellSize),
                0
            );
        }
#endif
    }
}
