﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Controls.DynamicData;
using DotVVM.Framework.Controls.DynamicData.Metadata;
using DotVVM.Framework.Controls.DynamicData.PropertyHandlers;
using DotVVM.Framework.Controls.DynamicData.PropertyHandlers.FormEditors;

namespace DotVVM.SampleWeb.Web.Controls
{
    public class BusinessPackTextBoxFormEditorProvider : FormEditorProviderBase
    {
        public override bool CanValidate => true;

        public override bool CanHandleProperty(PropertyInfo propertyInfo, DynamicDataContext context)
        {
            return TextBoxHelper.CanHandleProperty(propertyInfo, context);
        }

        public override void CreateControl(DotvvmControl container, PropertyDisplayMetadata property, DynamicDataContext context)
        {
            var textBox = new BusinessPack.Controls.TextBox();
            container.Children.Add(textBox);

            var cssClass = ControlHelpers.ConcatCssClasses(ControlCssClass, property.Styles?.FormControlCssClass);
            if (!string.IsNullOrEmpty(cssClass))
            {
                textBox.Attributes["class"] = cssClass;
            }

            textBox.ValueType = TextBoxHelper.GetValueType(property.PropertyInfo);
            textBox.FormatString = property.FormatString;
            textBox.SetBinding(TextBox.TextProperty, context.CreateValueBinding(property.PropertyInfo.Name));

            if (property.DataType == DataType.Password)
            {
                textBox.Type = TextBoxType.Password;
            }
            else if (property.DataType == DataType.MultilineText)
            {
                textBox.Type = TextBoxType.MultiLine;
            }

            if (textBox.IsPropertySet(DynamicEntity.EnabledProperty))
            {
                ControlHelpers.CopyProperty(textBox, DynamicEntity.EnabledProperty, textBox, TextBox.EnabledProperty);
            }
        }
    }
}