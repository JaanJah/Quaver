﻿using System;
using Microsoft.Xna.Framework;
using Quaver.Helpers;

namespace Quaver.Graphics.Buttons
{
    /// <inheritdoc />
    /// <summary>
    ///     This type of button is used for simple buttons that only require a single image + tint animation.
    /// </summary>
    internal class BasicButton : Button
    {
        /// <summary>
        ///     Current tween value of the object. Used for animation.
        /// </summary>
        private float HoverCurrentTween { get; set; }

        /// <summary>
        ///     Target tween value of the object. Used for animation.
        /// </summary>
        private float HoverTargetTween { get; set; }

        /// <summary>
        ///     Current Color/Tint of the object.
        /// </summary>
        private Color CurrentTint = Color.White;

        /// <summary>
        ///     This method is called when the mouse hovers over the button
        /// </summary>
        protected override void MouseOver()
        {
            HoverTargetTween = 1;
        }

        /// <summary>
        ///     This method is called when the Mouse hovers out of the button
        /// </summary>
        protected override void MouseOut()
        {
            HoverTargetTween = 0;
        }

        /// <summary>
        ///     This method will be used for button logic and animation
        /// </summary>
        internal override void Update(double dt)
        {
            HoverCurrentTween = GraphicsHelper.Tween(HoverTargetTween, HoverCurrentTween, Math.Min(dt / 40, 1));
            CurrentTint.R = (byte)((HoverCurrentTween * 0.25 + 0.75f) * 255);
            CurrentTint.G = (byte)((HoverCurrentTween * 0.25 + 0.75f) * 255);
            CurrentTint.B = (byte)((HoverCurrentTween * 0.25 + 0.75f) * 255);
            Tint = CurrentTint;
            base.Update(dt);
        }
    }
}