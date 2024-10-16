using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using Tests.Utils.Swd.BaseWebElements.Elements.Table;

namespace Tests.Utils.Swd.Helpers;

public static class InitializationHelper
{
    public static void InitializeElements(object? page)
    {
        InitializeElements(page, null);
    }

    public static void InitializeElements(object? page, BaseElement? parent)
    {
        var members = page.GetType()
            .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(FindByAttribute), true).Any());

        foreach (var member in members)
        {
            var findByAttr = member.GetCustomAttribute<FindByAttribute>(true);
            object? instanceToCreate = null;

            if (findByAttr == null) continue;

            var locator = findByAttr.GetLocator();
            switch (member)
            {
                case FieldInfo field:
                {
                    var fieldValue = field.GetValue(page);
                    if (fieldValue is null)
                    {
                        instanceToCreate = CreateElement(field.FieldType, locator, parent);
                        field.SetValue(page, instanceToCreate);
                    }

                    break;
                }
                case PropertyInfo property:
                {
                    var propertyValue = property.GetValue(page);
                    if (propertyValue is null)
                    {
                        instanceToCreate = CreateElement(property.PropertyType, locator, parent);
                        property.SetValue(page, instanceToCreate);
                    }

                    break;
                }
            }

            if (instanceToCreate != null && IsCompositeElement(instanceToCreate.GetType()))
            {
                InitializeElements(instanceToCreate, instanceToCreate as BaseElement);
            }
        }
    }

    private static object? CreateElement(Type element, By locator, BaseElement? parent)
    {
        if (!typeof(BaseElement).IsAssignableFrom(element)) throw new ArgumentException("Invalid element type");
        if (element == typeof(Element))
            return new Element { Locator = locator, Parent = parent };
        if (element == typeof(Button))
            return new Button { Locator = locator, Parent = parent };
        if (element == typeof(CheckBox))
            return new CheckBox { Locator = locator, Parent = parent };
        if (element == typeof(Input))
            return new Input { Locator = locator, Parent = parent };
        if (element == typeof(RadioButton))
            return new RadioButton { Locator = locator, Parent = parent };
        if (element == typeof(Table))
            return new Table { Locator = locator, Parent = parent };
        if (element == typeof(Row))
            return new Row { Locator = locator, Parent = parent };
        if (element == typeof(Column))
            return new Column { Locator = locator, Parent = parent };
        if (IsGenericType(element))
        {
            var elementType = element.GetGenericArguments()[0];
            return Activator.CreateInstance(
                typeof(Elements<>).MakeGenericType(elementType),
                locator, parent) as BaseElement;
        }

        throw new ArgumentException("Invalid element type");
    }

    private static bool IsCompositeElement(Type type)
    {
        return typeof(BaseElement).IsAssignableFrom(type) && type.IsClass;
    }

    private static bool IsGenericType(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Elements<>);
    }
}