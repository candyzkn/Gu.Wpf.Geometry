﻿namespace Gu.Wpf.Geometry.Effects
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;

    /// <summary>
    /// An effect that renders a HSL colour wheel.
    /// </summary>
    public class HslWheelEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(HslWheelEffect), 0);

        public static readonly DependencyProperty InnerRadiusProperty = DependencyProperty.Register(
            "InnerRadius",
            typeof(double),
            typeof(HslWheelEffect),
            new UIPropertyMetadata(0D, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InnerSaturationProperty = DependencyProperty.Register(
            "InnerSaturation",
            typeof(double),
            typeof(HslWheelEffect),
            new UIPropertyMetadata(0D, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty LightnessProperty = DependencyProperty.Register(
            "Lightness",
            typeof(double),
            typeof(HslWheelEffect),
            new UIPropertyMetadata(0.5D, PixelShaderConstantCallback(2)));

        private static readonly PixelShader Shader = new PixelShader
        {
            UriSource = new Uri("pack://application:,,,/Gu.Wpf.Geometry;component/Effects/HslWheelEffect.ps", UriKind.Absolute)
        };

        public HslWheelEffect()
        {
            this.PixelShader = Shader;
            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(InnerRadiusProperty);
            this.UpdateShaderValue(InnerSaturationProperty);
            this.UpdateShaderValue(LightnessProperty);
        }

        /// <summary>
        /// There has to be a property of type Brush called "Input". This property contains the input image and it is usually not set directly - it is set automatically when our effect is applied to a control.
        /// </summary>
        public Brush Input
        {
            get => (Brush)this.GetValue(InputProperty);
            set => this.SetValue(InputProperty, value);
        }

        /// <summary>The inner radius.</summary>
        public double InnerRadius
        {
            get => (double)this.GetValue(InnerRadiusProperty);
            set => this.SetValue(InnerRadiusProperty, value);
        }

        /// <summary>The inner saturation.</summary>
        public double InnerSaturation
        {
            get => (double)this.GetValue(InnerSaturationProperty);
            set => this.SetValue(InnerSaturationProperty, value);
        }

        /// <summary>The value.</summary>
        public double Lightness
        {
            get => (double)this.GetValue(LightnessProperty);
            set => this.SetValue(LightnessProperty, value);
        }
    }
}
