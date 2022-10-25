using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ITJob.Infrastructure.Utility;
using ITJob.Infrastructure.Exceptions;

namespace ITJob.Infrastructure.Domain
{
    /// <summary>
    ///     interface class for value objects in domain.
    /// </summary>
	public interface IHaveGetBrokenRules
    {
        /// <summary>
        /// returns broken business rules
        /// </summary>
        /// <returns></returns>
        IEnumerable<BusinessRule> GetBrokenRules();

        /// <summary>
        /// Check Broken rules, if Fail throw an BrokenRulesException.
        /// </summary>
        void CheckBrokenRules();
    }

    /// <summary>
    /// Base class for value objects in domain.
    /// Value
    /// </summary>
    /// <typeparam name="TValueObject">The type of this value object</typeparam>
	[Serializable]
	public class ValueObjectBase<TValueObject> : IEquatable<TValueObject>, IHaveGetBrokenRules
        where TValueObject : ValueObjectBase<TValueObject>
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();
        private List<BusinessRule> BrokenRules
        {
            get
            {
                if (_brokenRules == null)
                    _brokenRules = new List<BusinessRule>();
                return _brokenRules;
            }
        }



        #region IEquatable and Override Equals operators

        /// <summary>
        /// <see cref="M:System.Object.IEquatable{TValueObject}"/>
        /// </summary>
        /// <param name="other"><see cref="M:System.Object.IEquatable{TValueObject}"/></param>
        /// <returns><see cref="M:System.Object.IEquatable{TValueObject}"/></returns>
        public virtual bool Equals(TValueObject other)
        {
            if ((object)other == null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            //compare all public properties
            PropertyInfo[] publicProperties = this.GetType().GetProperties();

            if ((object)publicProperties != null
                &&
                publicProperties.Any())
            {
                return publicProperties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    if (left == null && right == null)
                        return true;
                    else if (left == null || right == null)
                        return false;
                    else if (typeof(TValueObject).IsAssignableFrom(left.GetType()))
                    {
                        //check not self-references...
                        return Object.ReferenceEquals(left, right);
                    }
                    else
                        return left.Equals(right);


                });
            }
            else
                return true;
        }
        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            if ((object)obj == null)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            ValueObjectBase<TValueObject> item = obj as ValueObjectBase<TValueObject>;

            if ((object)item != null)
                return Equals((TValueObject)item);
            else
                return false;

        }
        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            int index = 1;

            //compare all public properties
            PropertyInfo[] publicProperties = this.GetType().GetProperties();

            if ((object)publicProperties != null
                &&
                publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    object value = item.GetValue(this, null);

                    if ((object)value != null)
                    {

                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();

                        changeMultiplier = !changeMultiplier;
                    }
                    else
                        hashCode = hashCode ^ (index * 13);//only for support {"a",null,null,"a"} <> {null,"a","a",null}
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);

        }

        public static bool operator !=(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            return !(left == right);
        }

        #endregion

        protected virtual void Validate()
        {
            //AddValidationAttributeBrokenRules();

        }



        //protected void AddValidationAttributeBrokenRules()
        //{
        //    // نیاز به بهینه سازی دارد 
        //    // استفاده شود Validator.TryValidateObject شاید بهتر باشد از
        //    var context = new ValidationContext(this, null, null);
        //    var result = from property in TypeDescriptor.GetProperties(this).Cast<PropertyDescriptor>()
        //                 from attribute in property.Attributes.OfType<ValidationAttribute>()
        //                 let displayAttr = property.Attributes.OfType<DisplayAttribute>().FirstOrDefault()
        //                 where !attribute.IsValid(property.GetValue(this))
        //                 select new { PropertyName = property.Name, ErrorMessage = attribute.FormatErrorMessage(displayAttr == null ? property.Name : displayAttr.GetName()), Attribute = attribute };
        //    result.ToList().ForEach(error => AddBrokenRule(new ValidationAttributeBusinessRule(error.PropertyName, error.ErrorMessage, error.Attribute)));
        //}

        public virtual void ThrowExceptionIfInvalid()
        {
            BrokenRules.Clear();
            Validate();
            if (BrokenRules.Any())
            {
                StringBuilder issues = new StringBuilder();
                foreach (BusinessRule businessRule in BrokenRules)
                    issues.AppendLine(businessRule.Rule);

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected virtual void AddBrokenRule(BusinessRule businessRule)
        {
            BrokenRules.Add(businessRule);
        }

        /// <summary>
        /// returns broken business rules
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            BrokenRules.Clear();
            Validate();
            return BrokenRules;
        }

        /// <summary>
        /// returns broken business rules
        /// </summary>
        /// <returns></returns>
        public virtual void CheckBrokenRules()
        {
            IEnumerable<BusinessRule> brokenRules = GetBrokenRules();
            if (brokenRules.Any())
                throw new BrokenRulesException(brokenRules.ToList());
        }

        public override string ToString()
        {
            return string.Join(" , ", this.GetType().GetProperties().Select(p =>
            {
                var value = p.GetValue(this, null);
                if (value is Enum)
                    return string.Format("'{0}'", EnumHelper.GetEnumDisplay(value));
                return string.Format("'{0}'", value ?? "null");
            }));
        }
    }
}
