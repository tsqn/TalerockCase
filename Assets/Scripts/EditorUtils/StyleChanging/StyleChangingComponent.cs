namespace EditorUtils.StyleChanging
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Компонент для смены стиля объекта.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class StyleChangingComponent : MonoBehaviour
    {
        /// <summary>
        /// Активный в данный момент стиль.
        /// </summary>
        [HideInInspector]
        public Style ActiveStyle;

        /// <summary>
        /// Базовый стиль.
        /// </summary>
        public Sprite BaseStyleSprite;

        /// <summary>
        /// Каменный стиль.
        /// </summary>
        public Sprite StoneStyleSprite;

        /// <summary>
        /// Деревянный стиль.
        /// </summary>
        public Sprite WoodenStyleSprite;

        /// <summary>
        /// Смена стиля спрайта.
        /// </summary>
        /// <param name="style">Стиль.</param>
        public void ChangeStyle(Style style)
        {
            var sprite = new Sprite();

            switch (style)
            {
                case Style.Base:
                    if (BaseStyleSprite != null)
                        sprite = BaseStyleSprite;
                    break;
                case Style.Stone:
                    if (StoneStyleSprite != null)
                        sprite = StoneStyleSprite;
                    break;
                case Style.Wooden:
                    if (WoodenStyleSprite != null)
                        sprite = WoodenStyleSprite;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("style", sprite, null);
            }

            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
