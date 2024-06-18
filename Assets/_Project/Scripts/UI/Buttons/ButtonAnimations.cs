using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace valsesv._Project.Scripts.UI.Buttons
{
    public static class ButtonAnimations
    {
        private const float AnimationDuration = 0.5f;
        private const float StartScale = 0.9f;

        private static Dictionary<Transform, Tween> _buttonTweens = new();

        public static void PlayAnimation(ButtonInteractionEffectType targetType, Transform transform)
        {
            if (CanPlayTweenAnimation(transform) == false)
            {
                return;
            }

            switch (targetType)
            {
                case ButtonInteractionEffectType.None:
                    break;
                case ButtonInteractionEffectType.ScaleAnimation:
                    ScaleAnimation(transform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
        }

        private static void ScaleAnimation(Transform transform)
        {
            transform.localScale = Vector3.one * StartScale;
            _buttonTweens[transform] = transform.DOScale(Vector3.one, AnimationDuration).SetEase(Ease.OutBounce);
        }

        private static bool CanPlayTweenAnimation(Transform transform)
        {
            if (_buttonTweens.ContainsKey(transform) == false)
            {
                return false;
            }
            var animationTween = _buttonTweens[transform];
            if (animationTween.IsActive())
            {
                return false;
            }

            animationTween.Kill();
            return true;
        }
    }
}