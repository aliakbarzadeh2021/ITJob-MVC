using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ITJob.Infrastructure.Domain
{
	[Serializable]
	public abstract class EntityBase<TId> : IHaveGetBrokenRules
    {

        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();
        //[Required]
        public virtual TId Id { get; set; }

        protected virtual void Validate()
        {
            //AddValidationAttributeBrokenRules();
            AddNestedPropertiesBrokenRules();
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

        private void AddNestedPropertiesBrokenRules()
        {
            var result = TypeDescriptor.GetProperties(this).Cast<PropertyDescriptor>().Where(p => typeof(IHaveGetBrokenRules).IsAssignableFrom(p.PropertyType))
                       .Select(p => new { Property = p.Name, Value = p.GetValue(this) }).Where(p => p.Value != null)
                       .SelectMany(p => ((IHaveGetBrokenRules)p.Value).GetBrokenRules().Select(r =>
                       {
                           r.Property = p.Property + "." + r.Property;
                           return r;
                       }));
            result.ToList().ForEach(AddBrokenRule);
        }


        public virtual void CheckBrokenRules()
        {
            IEnumerable<BusinessRule> brokenRules = GetBrokenRules();
            if (brokenRules.Any())
                throw new BrokenRulesException(brokenRules.ToList());
        }

        /// <summary>
        /// returns broken rules
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<TId>
               && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode()
        {
            if (this.Id == null)
                return 0;
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1,
           EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1,
            EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
