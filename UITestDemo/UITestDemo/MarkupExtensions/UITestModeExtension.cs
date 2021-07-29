using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace UITestDemo.MarkupExtensions
{
    public class UITestModeExtension : IMarkupExtension
    {
        public string Id { get; set; }
        public static bool IsInUiTestMode { get; set; } = false;

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            if (IsInUiTestMode)
                return Id;
            else
                return null;
        }
    }
}
