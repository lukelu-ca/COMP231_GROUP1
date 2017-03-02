using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Attributes
{
    /// <summary>
    /// This is an attribute for giving an entity property a default DateTime value
    /// Reference: 
    /// https://code.msdn.microsoft.com/A-flexible-Default-Value-11c2db19
    /// Useage:
    ///// / Evaluate to the current date at run time 
    //[DefaultDateTimeValue("Now")]
    //public DateTime? PublishOn { get; set; }

    //// Define an absolute date 
    //[DefaultDateTimeValue("01/03/2016")]
    //public DateTime? PublishOn { get; set; }

    //// Define a relative date (30 days from now) 
    //[DefaultDateTimeValue("30.00:00:00")]
    //public DateTime? PublishOn { get; set; }

    //// Define a relative date (1 hour from now) 
    //[DefaultDateTimeValue("1:00:00")]
    //public DateTime? PublishOn { get; set; }

    //// Evaluate to last date of the month 
    //[DefaultDateTimeValue("LastOfMonth")]
    //public DateTime? PublishOn { get; set; }
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DefaultDateTimeValueAttribute : ValidationAttribute
    {
        public string DefaultValue { get; set; }

        public DefaultDateTimeValueAttribute(string defaultValue)
        {
            DefaultValue = defaultValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(validationContext.MemberName);

            // Set default value only if no value is already specified
            if (value == null)
            {
                DateTime defaultValue = GetDefaultValue();
                property.SetValue(validationContext.ObjectInstance, defaultValue);
            }

            return ValidationResult.Success;
        }

        public static DateTime GetDefaultValue(Type objectType, string propertyName)
        {
            var property = objectType.GetProperty(propertyName);
            var attribute = property.GetCustomAttributes(typeof(DefaultDateTimeValueAttribute), false)
                ?.Cast<DefaultDateTimeValueAttribute>()
                ?.FirstOrDefault();

            return attribute.GetDefaultValue();
        }

        private DateTime GetDefaultValue()
        {
            // Resolve a named property of DateTime, like "Now"
            if (this.IsProperty)
            {
                return GetPropertyValue();
            }

            // Resolve a named extension method of DateTime, like "LastOfMonth"
            if (this.IsExtensionMethod)
            {
                return GetExtensionMethodValue();
            }

            // Parse a relative date
            if (this.IsRelativeValue)
            {
                return GetRelativeValue();
            }

            // Parse an absolute date
            return GetAbsoluteValue();
        }

        private bool IsProperty
            => typeof(DateTime).GetProperties()
                .Select(p => p.Name).Contains(this.DefaultValue);

        private bool IsExtensionMethod
            => typeof(DefaultDateTimeValueAttribute).Assembly
                .GetType(typeof(DateTimeExtensions).FullName)
                .GetMethods()
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false))
                .Select(p => p.Name).Contains(this.DefaultValue);

        private bool IsRelativeValue
            => this.DefaultValue.Contains(":");

        private DateTime GetPropertyValue()
        {
            var instance = Activator.CreateInstance<DateTime>();
            var value = (DateTime)instance.GetType()
                .GetProperty(this.DefaultValue)
                .GetValue(instance);

            return value;
        }

        private DateTime GetExtensionMethodValue()
        {
            var instance = Activator.CreateInstance<DateTime>();
            var value = (DateTime)typeof(DefaultDateTimeValueAttribute).Assembly
                .GetType(typeof(DateTimeExtensions).FullName)
                .GetMethod(this.DefaultValue)
                .Invoke(instance, new object[] { DateTime.Now });

            return value;
        }

        private DateTime GetRelativeValue()
        {
            TimeSpan timeSpan;
            if (!TimeSpan.TryParse(this.DefaultValue, out timeSpan))
            {
                return default(DateTime);
            }

            return DateTime.Now.Add(timeSpan);
        }

        private DateTime GetAbsoluteValue()
        {
            DateTime value;
            if (!DateTime.TryParse(this.DefaultValue, out value))
            {
                return default(DateTime);
            }

            return value;
        }
    }
}

