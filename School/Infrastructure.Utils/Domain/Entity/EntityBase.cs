using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Domain.Entity
{
    [DataContract]
    public class EntityBase:IDataErrorInfo
    {
        [NotMapped]
        [IgnoreDataMember]
        public virtual string Error
        {
            get
            {

                TypeDescriptor.AddProviderTransparent(
                    new AssociatedMetadataTypeTypeDescriptionProvider(this.GetType()), this.GetType());
                StringBuilder b = new StringBuilder();
                var context = new ValidationContext(this, serviceProvider: null, items: null);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var isValid = Validator.TryValidateObject(this, context, results, true);
                if (!isValid)
                {
                    foreach (var validationResult in results)
                    {
                        b.AppendLine(validationResult.ErrorMessage);
                    }
                }
                return b.ToString();


            }
        }

        [NotMapped]
        [IgnoreDataMember]
        public virtual string this[string columnName]
        {
            get
            {

                TypeDescriptor.AddProviderTransparent(
                    new AssociatedMetadataTypeTypeDescriptionProvider(this.GetType()), this.GetType());
                StringBuilder b = new StringBuilder();
                var context = new ValidationContext(this, serviceProvider: null, items: null)
                {
                    MemberName = columnName
                };
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                //try
                //{
                var itm = this.GetType().GetProperties()
                    .SingleOrDefault(x => x.Name == columnName);
                if (itm.CanWrite)
                {
                    var isValid = Validator.TryValidateProperty(itm.GetValue(this, null), context, results);
                    if (!isValid)
                    {
                        foreach (var validationResult in results)
                        {
                            b.AppendLine(validationResult.ErrorMessage);
                        }
                    }
                }
                //}
                //catch
                //{

                //}

                return b.ToString();
            }
        }

        [NotMapped]
        [IgnoreDataMember]
        public virtual bool IsValid
        {
            get
            {
                return String.IsNullOrEmpty(this.Error);
            }
        }
    }
}
